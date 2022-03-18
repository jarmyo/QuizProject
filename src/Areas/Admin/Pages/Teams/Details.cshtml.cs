namespace QuizProject.Areas.Admin.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly QuizContext _context;
        public DetailsModel(QuizContext context)
        {
            _context = context;
        }
        public Team Teams { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teams = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            if (Teams == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}