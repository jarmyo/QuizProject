using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizProject.Databases;

namespace QuizProject.Areas.Admin.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly QuizContext _context;

        public CreateModel(QuizContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdCategory"] = new SelectList(_context.Categories, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Questions.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}