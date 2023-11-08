using Auth0.AspNetCore.Authentication;
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
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        { 
            _logger = logger;
        }

        [AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        public async Task LoginAuth()
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                      .WithRedirectUri(Url?.Action("LoginCallback", "Login") ?? "")
                      .WithScope("email profile")
                      .Build();
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<IActionResult> LoginCallback()
        {
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
                .WithRedirectUri(Url?.Action("Login", "Login") ?? "")
                .Build();
            // Logout from Auth0
            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            // Logout from the application
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            await SessionManager.Logout();
        }
        #region routes

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
        #endregion

        /*[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
            (bool, string) resultado = Validador.GetVerificador().EsClaveSegura(model.Password);
			if (resultado.Item1)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.ContraseniaSugerida = Validador.GetVerificador().GenerarContraseniaSugerida();
				ViewBag.MensajeError = resultado.Item2;
				return View("login", model);
			}
        } */
    }
}