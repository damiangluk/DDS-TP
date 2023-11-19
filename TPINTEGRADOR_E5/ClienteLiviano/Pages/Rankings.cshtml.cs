using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClienteLiviano.Pages
{
    public class RankingsModel : PageModel
    {
        private readonly ILogger<RankingsModel> _logger;

        public RankingsModel(ILogger<RankingsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}