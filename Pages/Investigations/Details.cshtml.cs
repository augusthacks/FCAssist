using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FCAssist.Data;
using FCAssist.Models;

namespace FCAssist.Pages.Investigations
{
    public class DetailsModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public DetailsModel(FCAssist.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Investigation Investigation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Investigation == null)
            {
                return NotFound();
            }

            var investigation = await _context.Investigation.FirstOrDefaultAsync(m => m.Id == id);
            if (investigation == null)
            {
                return NotFound();
            }
            else 
            {
                Investigation = investigation;
            }
            return Page();
        }
    }
}
