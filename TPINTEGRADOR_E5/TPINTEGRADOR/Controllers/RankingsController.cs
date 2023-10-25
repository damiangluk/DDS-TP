using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Controllers
{
    public class RankingsController : Controller
    {
        private readonly ILogger<RankingsController> _logger;

        public RankingsController(ILogger<RankingsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}