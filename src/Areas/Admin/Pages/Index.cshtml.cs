namespace QuizProject.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin, Editor")]
    public class AdminModel : PageModel
    {
        public AdminModel() { }
        public void OnGet() { }
    }
}