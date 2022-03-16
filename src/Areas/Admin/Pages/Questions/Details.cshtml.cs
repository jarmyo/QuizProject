using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizProject.Databases;

namespace QuizProject.Areas.Admin.Pages.Questions
{
    public class DetailsModel : PageModel
    {
        private readonly QuizProject.Databases.QuizContext _context;

        public DetailsModel(QuizProject.Databases.QuizContext context)
        {
            _context = context;
        }

        public Question Question { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Questions
                .Include(q => q.IdCategoryNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Question == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
