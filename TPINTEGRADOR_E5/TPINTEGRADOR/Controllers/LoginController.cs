using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPINTEGRADOR.Models;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;

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
        public async Task LoginAuth(string returnUrl = "/")
        {
            string toMove = string.IsNullOrEmpty(returnUrl) ? Url?.Action("Index", "Home") ?? "" : returnUrl;
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                      .WithRedirectUri(Url?.Action("Index", "Home") ?? "")
                      .Build();
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);

        }

        /*public async Task LoginAuth(string returnUrl = "/")
        {
            string toMove = string.IsNullOrEmpty(returnUrl) ? Url?.Action("Index", "Home") ?? "" : returnUrl;
            var authenticationApiClient = new AuthenticationApiClient("your-auth0-domain");

            var authorizeUrl = authenticationApiClient.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Code)
                .WithRedirectUrl("your-redirect-uri")
                .WithScope("openid profile email")
                .Build();

            // Redirect the user to the authorize URL to start the authentication process
            var tokenRequest = new AuthorizationCodeTokenRequest
            {
                ClientId = "your-client-id",
                ClientSecret = "your-client-secret",
                Code = code,
                RedirectUri = "your-redirect-uri"
            };

            var tokenResponse = await authenticationApiClient.GetTokenAsync(tokenRequest);

            // Use the access token to get the user information
            var userInfoRequest = new UserInfoRequest
            {
                Address = tokenResponse.AccessToken
            };

            var userInfo = await authenticationApiClient.GetUserInfoAsync(userInfoRequest);
        }*/

        public async Task LogoutAuth()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url?.Action("Login", "Login") ?? "")
                .Build();
            // Logout from Auth0
            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            // Logout from the application
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        }
        #region routes

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
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