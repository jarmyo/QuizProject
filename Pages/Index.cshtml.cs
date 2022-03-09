using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizProject.Pages
{

    public class IndexModel : PageModel
    {
        private readonly QuizContext _context;
        private readonly ILogger<IndexModel> _logger;

        public List<Scores> ScoreList { get; set; } = new List<Scores>();

        public IndexModel(ILogger<IndexModel> logger, QuizContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            _context.Database.EnsureCreated();
            foreach (var team in _context.Teams.OrderByDescending(t => t.Score).Take(10))
            {
                ScoreList.Add(new Scores(team.TeamName, team.Score));
            }
        }
    }
    public record Scores(string Name, int Score);
}