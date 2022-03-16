using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizProject.Databases;

namespace QuizProject.Areas.Admin.Pages.Answers
{
    public class DeleteModel : PageModel
    {
        private readonly QuizProject.Databases.QuizContext _context;

        public DeleteModel(QuizProject.Databases.QuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Answer Answer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Answer = await _context.Answers
                .Include(a => a.IdQuestionNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Answer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Answer = await _context.Answers.FindAsync(id);

            if (Answer != null)
            {
                _context.Answers.Remove(Answer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
