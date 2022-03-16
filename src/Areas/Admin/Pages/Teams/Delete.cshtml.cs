using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizProject.Databases;

namespace QuizProject.Areas.Admin.Pages.Teams
{
    public class DeleteModel : PageModel
    {
        private readonly QuizProject.Databases.QuizContext _context;

        public DeleteModel(QuizProject.Databases.QuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Teams { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teams = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            if (Teams == null)
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

            Teams = await _context.Teams.FindAsync(id);

            if (Teams != null)
            {
                _context.Teams.Remove(Teams);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
