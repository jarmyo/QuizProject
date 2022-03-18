namespace QuizProject.Areas.Admin.Pages.Answers
{
    public class IndexModel : PageModel
    {
        private readonly QuizContext _context;
        public IndexModel(QuizContext context)
        {
            _context = context;
        }
        public IList<Answer> Answer { get;set; }
        public async Task OnGetAsync()
        {
            Answer = await _context.Answers
                .Include(a => a.IdQuestionNavigation).ToListAsync();
        }
    }
}