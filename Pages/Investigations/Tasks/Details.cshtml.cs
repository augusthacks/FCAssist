using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FCAssist.Data;
using FCAssist.Models;

namespace FCAssist.Pages.Investigations.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public DetailsModel(FCAssist.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public InvestigationTask InvestigationTask { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InvestigationTask == null)
            {
                return NotFound();
            }

            var investigationtask = await _context.InvestigationTask.FirstOrDefaultAsync(m => m.Id == id);
            if (investigationtask == null)
            {
                return NotFound();
            }
            else 
            {
                InvestigationTask = investigationtask;
            }
            return Page();
        }
    }
}
