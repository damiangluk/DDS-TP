using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        { 
            _logger = logger;
        }
        #region routes

        public IActionResult Login()
        {
            ViewBag.ContraseniaSugerida = Validador.GetVerificador().GenerarContraseniaSugerida();

			return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        [HttpPost]
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
        }
    }
}