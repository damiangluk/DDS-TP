using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClienteLiviano.Pages
{
    public class ComunidadesModel : PageModel
    {
        private readonly ILogger<ComunidadesModel> _logger;

        public ComunidadesModel(ILogger<ComunidadesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}