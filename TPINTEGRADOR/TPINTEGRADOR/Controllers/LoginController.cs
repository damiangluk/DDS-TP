using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            ViewBag.ContraseniaSugerida = Validador.GetVerificador().GenerarContraseniaSugerida();

			return View();
        }

		[HttpPost]
		public IActionResult Login(string username, string password)
		{
            (bool, string) resultado = Validador.GetVerificador().EsClaveSegura(password);
			if (resultado.Item1)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.ContraseniaSugerida = Validador.GetVerificador().GenerarContraseniaSugerida();
				ViewBag.MensajeError = resultado.Item2;
				return View("Index");
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}