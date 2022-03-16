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
    public class IndexModel : PageModel
    {
        private readonly QuizProject.Databases.QuizContext _context;

        public IndexModel(QuizProject.Databases.QuizContext context)
        {
            _context = context;
        }

        public IList<Team> Teams { get;set; }

        public async Task OnGetAsync()
        {
            Teams = await _context.Teams.ToListAsync();
        }
    }
}
