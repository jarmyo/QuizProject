namespace QuizProject.Areas.Admin.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly QuizContext _context;
        public IndexModel(QuizContext context)
        {
            _context = context;
        }
        public IList<Team> Teams { get;set; }
        public async Task OnGetAsync()
        {
            Teams = await _context.Teams.ToListAsync();
        }
    }
}