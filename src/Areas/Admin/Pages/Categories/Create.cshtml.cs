using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizProject.Areas.Admin.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly QuizContext _context;
        private IWebHostEnvironment _environment;
        public CreateModel(QuizContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult OnGet()
        {
            Category = new()
            {
                AviabilityDate = DateTime.Now //default
            };
            return Page();
        }
        [BindProperty]
        public Category Category { get; set; }
        public IFormFile Upload { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Category.Id = Guid.NewGuid().ToString();

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
            if (Upload != null)
                await CategoryImageHelper.CreateImage(Category.Id, Upload, _environment);
            return RedirectToPage("./Index");
        }
    }
}