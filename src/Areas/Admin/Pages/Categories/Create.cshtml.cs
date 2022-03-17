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
            //default
            Category = new()
            {
                AviabilityDate = DateTime.Now
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
            var newFileName = Category.Id + Path.GetExtension(Upload.FileName);
            var file = Path.Combine(_environment.ContentRootPath, @"wwwroot\img", newFileName );
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}