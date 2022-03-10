using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizProject.Pages
{
    [Authorize]
    public class ActivitiesModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly QuizContext _context;
        public ActivitiesModel(ILogger<PrivacyModel> logger,
              UserManager<IdentityUser> userManager,
              QuizContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public string TeamName { get; set; }
        public string TeamId { get; set; }
        public int Score { get; set; }

        public List<Category> Flags { get; set; }
        public List<ActivitiesAndswers> Questions { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var teams = _context.Teams.Where(t => t.LoginGUID == user.Id);
            if (teams.Any())
            {
                var team = teams.First();
                TeamName = team.TeamName;
                Score = team.Score;
                TeamId = team.Id;
            }
            Flags = _context.Categories.ToList();

            Questions = new List<ActivitiesAndswers>();
            foreach (var qu in _context.Questions)
            {
                var da = new ActivitiesAndswers()
                {
                    Id = qu.Id,
                    Name = qu.Name,
                    Points = qu.Points,
                    Earned = false
                };

                da.Earned = (_context.TeamAnswers.Any(a => a.IdTeam == TeamId && a.IdQuestion == qu.Id));                
                Questions.Add(da);
            }

            return Page();
        }
    }

    public class ActivitiesAndswers
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HtmlBody { get; set; }
        public int Points { get; set; }
        public bool Earned { get; set; }
    }
}