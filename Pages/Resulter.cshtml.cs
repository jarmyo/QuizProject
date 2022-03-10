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
        public IActionResult OnPost([FromBody] ResponseModel response)
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

        internal static class Verificator
        {
            internal static (bool IsCorrect, double Score) Check(List<Answer> answers, string response)
            {
                response = response.Trim();

                foreach (var validAnswers in answers)
                {
                    Dictionary<string, string> Variations = new Dictionary<string, string>()
                    {
                        [validAnswers.Text.ToLower()] = response.ToLower(),
                        [validAnswers.Text.ToLowerInvariant()] = response.ToLowerInvariant(),
                        [validAnswers.Text.ToUpper()] = response.ToUpper(),
                        [validAnswers.Text.ToUpperInvariant()] = response.ToUpperInvariant(),
                    };

                    System.Diagnostics.Debug.WriteLine(validAnswers.Text + "->" + response);

                    var Similitude = MinimumSimilarity(validAnswers.Text,1);

                    foreach (var variation in Variations)
                    {
                        //DIRECT UPPERCASE and LOWERCASE variarions
                        if (variation.Key == variation.Value)
                        {
                            return (true, 1); //its the same
                        }                        
                        var score = CalculateSimilarity(variation.Key,variation.Value);                        
                        if (score >= Similitude)
                        {
                            System.Diagnostics.Debug.WriteLine(variation.Value + " -> " + variation.Key + " = " + score );
                            return (true, score); //its the same
                        }
                    }
                }
                return (false, 0);
            }
            //Max two letters
            /// <summary>
            /// Calculate the percentaje of minimum similarity of a word
            /// </summary>
            /// <param name="answer">The string to calculate</param>
            /// <param name="chars">the numbers of chars could be omited</param>
            /// <returns></returns>
            public static double MinimumSimilarity(string answer, int chars)
            {
                double percent = 1.00 / (double)answer.Length;
                 return ((double)(answer.Length-chars) * percent);
            }
            public static int ComputeLevenshteinDistance(string source, string target)
            {
                if ((source == null) || (target == null)) return 0;
                if ((source.Length == 0) || (target.Length == 0)) return 0;
                if (source == target) return source.Length;

                int sourceWordCount = source.Length;
                int targetWordCount = target.Length;

                // Step 1
                if (sourceWordCount == 0)
                    return targetWordCount;

                if (targetWordCount == 0)
                    return sourceWordCount;

                int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

                // Step 2
                for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
                for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

                for (int i = 1; i <= sourceWordCount; i++)
                {
                    for (int j = 1; j <= targetWordCount; j++)
                    {
                        // Step 3
                        int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                        // Step 4
                        distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                    }
                }

                return distance[sourceWordCount, targetWordCount];
            }
            internal static double CalculateSimilarity(string source, string target)
            {
                if ((source == null) || (target == null)) return 0.0;
                if ((source.Length == 0) || (target.Length == 0)) return 0.0;
                if (source == target) return 1.0;

                int stepsToSame = ComputeLevenshteinDistance(source, target);
                return 1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length));
            }
        }

        public class ResponseModel
        {
            public string Question { get; set; }
            public string Response { get; set; }
        }
    }
}