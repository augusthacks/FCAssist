using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FCAssist.Models;
using FCAssist.Data;

namespace FCAssist.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, FCAssist.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // On get, return list of investigations the requested user is a member of.
        public IList<InvestigationTask> InvestigationTasks { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.InvestigationTask != null)
            {
                InvestigationTasks = await _context.InvestigationTask.ToListAsync();
            }
        }
    }
}