using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizProject.Pages
{
    public class ResulterModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly QuizContext _context;
        public ResulterModel(ILogger<PrivacyModel> logger,
              UserManager<IdentityUser> userManager,
              QuizContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult OnPost([FromBody] ResultResponseModel response)
        {
            //Get the current Team.

            var answer = response.Response;
            var validAnswers = _context.Answers.Where(a => a.IdQuestion == response.Question).ToList();
            var check = Verificator.Check(validAnswers, answer);
            if (check.IsCorrect)
            {
                //Move
                return new JsonResult(new { Result = "Correct", Score = check.Score });
            }
            return new JsonResult(new { Result = "Incorrect", Score = check.Score });
        }

        public class ResultResponseModel
        {
            public string Question { get; set; }
            public string Response { get; set; }
        }
    }
}