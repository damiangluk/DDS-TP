using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClienteLiviano.Pages
{
    public class IncidentesModel : PageModel
    {
        private readonly ILogger<IncidentesModel> _logger;

        public IncidentesModel(ILogger<IncidentesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}