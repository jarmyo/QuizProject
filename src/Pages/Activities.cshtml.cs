using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public List<Category> Flags { get; set; }
     //   public List<ActivitiesAndswers> Questions { get; set; }
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

            Flags = new List<Category>();
            foreach (var flag in _context.Categories)
            {
                flag.Questions = new List<Question>();
                foreach(var qu in  _context.Questions.Where(q => q.IdCategory == flag.Id))
                {
                   // da.Earned = _context.TeamAnswers.Any(a => a.IdTeam == TeamId && a.IdQuestion == qu.Id);
                 //   flag.Questions.Add(qu);
                }

                Flags.Add(flag);
            }
            
           // Questions = new List<ActivitiesAndswers>();

            //foreach (var qu in _context.Questions)
            //{
            //    var da = new ActivitiesAndswers()
            //    {
            //        Id = qu.Id,
            //        Name = qu.Name,
            //        Description = qu.Description,
            //        Points = qu.Points,
            //        Earned = false
            //    };

                
            //    Questions.Add(da);
            //}

            return Page();
        }
    }

 //   public class ActivitiesAndswers
    //{
    //    public string Id { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public string HtmlBody { get; set; }
    //    public int Points { get; set; }
    //    public bool Earned { get; set; }
    //}
}