namespace QuizProject.Areas.Admin.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly QuizContext _context;

        public IndexModel(QuizContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category= new List<Category>();
            foreach (var c in await _context.Categories.ToListAsync())
            {
                c.Questions = _context.Questions.Where(x => x.IdCategory == c.Id).ToList();
                Category.Add(c);
            }
        }
    }
}