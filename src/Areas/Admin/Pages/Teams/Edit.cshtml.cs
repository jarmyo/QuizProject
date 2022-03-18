namespace QuizProject.Areas.Admin.Pages.Teams
{
    public class EditModel : PageModel
    {
        private readonly QuizContext _context;

        public EditModel(QuizContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Teams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamsExists(Teams.Id))
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

        private bool TeamsExists(string id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
