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
    public class DetailsModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public DetailsModel(FCAssist.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
