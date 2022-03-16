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
    public class IndexModel : PageModel
    {
        private readonly QuizProject.Databases.QuizContext _context;

        public IndexModel(QuizProject.Databases.QuizContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get;set; }

        public async Task OnGetAsync()
        {
            Question = await _context.Questions
                .Include(q => q.IdCategoryNavigation).ToListAsync();
        }
    }
}
