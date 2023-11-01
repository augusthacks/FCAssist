using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FCAssist.Data;
using FCAssist.Models;

namespace FCAssist.Pages.Investigations.Files
{
    public class DeleteModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public DeleteModel(FCAssist.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TaskFile InvestigationFile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InvestigationFile == null)
            {
                return NotFound();
            }

            var investigationfile = await _context.InvestigationFile.FirstOrDefaultAsync(m => m.Id == id);

            if (investigationfile == null)
            {
                return NotFound();
            }
            else 
            {
                InvestigationFile = investigationfile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.InvestigationFile == null)
            {
                return NotFound();
            }
            var investigationfile = await _context.InvestigationFile.FindAsync(id);

            if (investigationfile != null)
            {
                InvestigationFile = investigationfile;
                _context.InvestigationFile.Remove(InvestigationFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
