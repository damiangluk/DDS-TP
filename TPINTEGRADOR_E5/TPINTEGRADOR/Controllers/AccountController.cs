﻿using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPINTEGRADOR.Models;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using System.Security.Claims;
using TPINTEGRADOR.Models.daos.auxClasses;

namespace TPINTEGRADOR.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        { 
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task LoginAuth()
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                      .WithRedirectUri(Url?.Action("LoginCallback", "Account") ?? "")
                      .WithScope("email profile")
                      .Build();
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> LoginCallback()
        {
            _logger.Log(LogLevel.Information, "Entre al callback");
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            if (User != null && User.Identity.IsAuthenticated)
            {
                await SessionManager.Login(User);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task LogoutAuth()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url?.Action("Login", "Account") ?? "")
                .Build();
            // Logout from Auth0
            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            // Logout from the application
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            await SessionManager.Logout();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                await SessionManager.Login(User);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ContraseniaSugerida = Validador.GetVerificador().GenerarContraseniaSugerida();

			return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}