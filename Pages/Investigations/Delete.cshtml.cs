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
    public class DeleteModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public DeleteModel(FCAssist.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Investigation == null)
            {
                return NotFound();
            }
            var investigation = await _context.Investigation.FindAsync(id);

            if (investigation != null)
            {
                Investigation = investigation;
                _context.Investigation.Remove(Investigation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
