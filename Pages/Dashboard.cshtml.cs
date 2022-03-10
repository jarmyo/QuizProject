using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizProject.Pages
{
    public class DashboardyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        public DashboardyModel(ILogger<PrivacyModel> logger,
              UserManager<IdentityUser> userManager)
        {
            _logger = logger;
        }

        public string TeamName { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            return Page();
        }
    }
}