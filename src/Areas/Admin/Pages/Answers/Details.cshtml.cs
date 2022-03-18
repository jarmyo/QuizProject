namespace QuizProject.Areas.Admin.Pages.Answers
{
    public class DetailsModel : PageModel
    {
        private readonly QuizContext _context;

        public DetailsModel(QuizContext context)
        {
            _context = context;
        }

        public Answer Answer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Answer = await _context.Answers
                .Include(a => a.IdQuestionNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Answer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}