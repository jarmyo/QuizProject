using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizProject.Databases;

namespace QuizProject.Areas.Admin.Pages.Answers
{
    public class CreateModel : PageModel
    {
        private readonly QuizProject.Databases.QuizContext _context;

        public CreateModel(QuizProject.Databases.QuizContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdQuestion"] = new SelectList(_context.Questions, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Answer Answer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Answers.Add(Answer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
