using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizProject.Pages
{
    public class RulesModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public RulesModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}