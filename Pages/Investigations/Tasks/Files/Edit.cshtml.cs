using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FCAssist.Data;
using FCAssist.Models;

namespace FCAssist.Pages.Investigations.Files
{
    public class EditModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public EditModel(FCAssist.Data.ApplicationDbContext context)
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

            var investigationfile =  await _context.InvestigationFile.FirstOrDefaultAsync(m => m.Id == id);
            if (investigationfile == null)
            {
                return NotFound();
            }
            InvestigationFile = investigationfile;
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

            _context.Attach(InvestigationFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigationFileExists(InvestigationFile.Id))
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

        private bool InvestigationFileExists(int id)
        {
          return (_context.InvestigationFile?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
