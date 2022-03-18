namespace QuizProject.Areas.Admin.Pages.Questions
{
    public class DetailsModel : PageModel
    {
        private readonly QuizContext _context;

        public DetailsModel(QuizContext context)
        {
            _context = context;
        }

        public Question Question { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Questions
                .Include(q => q.IdCategoryNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Question == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}