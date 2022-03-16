using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizProject.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin, Editor")]
    public class AdminModel : PageModel
    {       
        public AdminModel()
        {
        }

        public void OnGet()
        {     
        }
    }
}
