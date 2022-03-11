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

            //Create the cats
            /*
            var idFlag = Guid.NewGuid().ToString();
            _context.Categories.Add(new Category() { Id = idFlag, Title = "International Space Station", AviabilityDate = new DateTime(2022, 3, 1), IsAviable = true, Description = "The ISS supports a wide range of scientific inquiry. Enter the laboratory." });
            _context.Categories.Add(new Category() { Id = Guid.NewGuid().ToString(), Title = "Down to Earth", AviabilityDate = new DateTime(2022, 4, 1), IsAviable = true, Description = "The ISS supports a wide range of scientific inquiry. Enter the laboratory." });
            _context.Categories.Add(new Category() { Id = Guid.NewGuid().ToString(), Title = "Deep Space Patrol", AviabilityDate = new DateTime(2022, 5, 1), IsAviable = true, Description = "The ISS supports a wide range of scientific inquiry. Enter the laboratory." });
            _context.Categories.Add(new Category() { Id = Guid.NewGuid().ToString(), Title = "Mission to Mars", AviabilityDate = new DateTime(2022, 6, 1), IsAviable = false, Description = "The ISS supports a wide range of scientific inquiry. Enter the laboratory." });
            _context.Categories.Add(new Category() { Id = Guid.NewGuid().ToString(), Title = "Adventures in Aeronautics", AviabilityDate = new DateTime(2022, 7, 1), IsAviable = false, Description = "The ISS supports a wide range of scientific inquiry. Enter the laboratory." });
            _context.Categories.Add(new Category() { Id = Guid.NewGuid().ToString(), Title = "Fun with technology", AviabilityDate = new DateTime(2022, 8, 1), IsAviable = false, Description = "The ISS supports a wide range of scientific inquiry. Enter the laboratory." });
            var idQuestion = Guid.NewGuid().ToString();
            _context.Questions.Add(new Question() { Id = idQuestion, Name = "Going the Distance", Description = "Astronauts in space must exercise at least two hours a day to keep their bones and muscles healthy.Some astronauts, though, take it a step further.Can you decipher the coded message that Astronaut Suni Williams sent to let folks know what she did while she was on the space station ? ", IdCategory = idFlag, HtmlBody = " <h1>empty<h1>", Points = 3 });
            _context.Questions.Add(new Question() { Id = Guid.NewGuid().ToString(), Name = "Space Station Training Mixup", Description = "Going the Distance", IdCategory = idFlag, HtmlBody = "<h1>empty<h1>", Points = 5 });
            _context.Questions.Add(new Question() { Id = Guid.NewGuid().ToString(), Name = "World Cup Expectations", Description = "Going the Distance", IdCategory = idFlag, HtmlBody = "<h1>empty<h1>", Points = 10 });
            _context.Questions.Add(new Question() { Id = Guid.NewGuid().ToString(), Name = "Breathing Easy IS Simple", Description = "Going the Distance", IdCategory = idFlag, HtmlBody = "<h1>empty<h1>", Points = 4 });
            _context.Questions.Add(new Question() { Id = Guid.NewGuid().ToString(), Name = "How to Flee Orbital Debris", Description = "Going the Distance", IdCategory = idFlag, HtmlBody = "<h1>empty<h1>", Points = 13 });
            _context.Questions.Add(new Question() { Id = Guid.NewGuid().ToString(), Name = "If You Build It...", Description = "Going the Distance", IdCategory = idFlag, HtmlBody = "<h1>empty<h1>", Points = 20 });

            var idAnser = Guid.NewGuid().ToString();
            _context.Answers.Add(new Answer() { Id = idAnser, IdQuestion = idQuestion, Text = "Marathon" });
            var idTeams = Guid.NewGuid().ToString();
            _context.Teams.Add(new Teams() { Id = idTeams, City = "Houston", Score = 70, LoginGUID = "4eaf7e5c-99ce-4936-b588-245f06bcc11d", SpondorLastName = "John", SponsorFirstName = "McKay", TeamName = "Texas Team", ZipCode = "12345", State = "TX" });
            _context.Teams.Add(new Teams() { Id = Guid.NewGuid().ToString(), City = "Houston", Score = 90, LoginGUID = "553c91cc-2edb-4e9f-bbbe-1b3635041b0c", SpondorLastName = "John", SponsorFirstName = "McKay", TeamName = "Instruments Team", ZipCode = "12345", State = "TX" });

            _context.TeamAnswers.Add(new TeamAnswers() { Id = Guid.NewGuid().ToString(), IdAnswer = idAnser, IdTeam = idTeams, IdQuestion = idQuestion, Answer = "MARATHON" });

            _context.SaveChanges();

            */
        }
    }
    public record Scores(string Name, int Score);
}