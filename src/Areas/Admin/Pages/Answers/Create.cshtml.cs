namespace QuizProject.Areas.Admin.Pages.Answers
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
            ViewData["IdQuestion"] = new SelectList(_context.Questions, "Id", "Id");
            return Page();
        }
        [BindProperty]
        public Answer Answer { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Answers.Add(Answer);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}