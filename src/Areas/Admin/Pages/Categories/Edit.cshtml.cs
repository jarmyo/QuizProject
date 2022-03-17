using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace QuizProject.Areas.Admin.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly QuizContext _context;
        private IWebHostEnvironment _environment;
        public EditModel(QuizContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [BindProperty]
        public Category Category { get; set; }
        public IFormFile Upload { get; set; }
        public bool HasImage { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null) return NotFound();            

            Category = await _context.Categories.FindAsync(id);

            if (Category == null) return NotFound();            
            else
            {
                HasImage = CategoryImageHelper.ExistImage(Category.Id,  _environment);
                Category.Questions = _context.Questions.Where(q => q.IdCategory == id).ToList();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                if (Upload != null)
                {
                    await CategoryImageHelper.CreateImage(Category.Id, Upload, _environment);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryExists(string id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}