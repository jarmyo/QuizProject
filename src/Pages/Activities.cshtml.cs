namespace QuizProject.Pages
{
    [Authorize]
    public class ActivitiesModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly QuizContext _context;
        public ActivitiesModel(UserManager<IdentityUser> userManager,
              QuizContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public string TeamName { get; set; }
        public string TeamId { get; set; }
        public int Score { get; set; }
        public List<Category> Categories { get; set; }
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
            else return NotFound(); //Team not registred                                    

            Categories = new List<Category>();
            foreach (var category in _context.Categories)
            {
                if (category.IsAviable)
                {
                    category.Questions = _context.Questions.Where(q => q.IdCategory == category.Id).ToList();
                    foreach (var qu in category.Questions.ToList())
                    {
                        qu.Teams = _context.TeamAnswers.Where(q => q.IdTeam == TeamId && q.IdQuestion == qu.Id).ToList();
                    }
                }

                Categories.Add(category);
            }
            return Page();
        }
    }
}