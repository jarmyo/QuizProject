namespace QuizProject.Areas.Admin.Pages.Teams
{
    public class CreateModel : PageModel
    {
        private readonly QuizContext _context;
        public CreateModel(QuizContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Team Teams { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Teams.Add(Teams);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}