using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FCAssist.Data;
using FCAssist.Models;

namespace FCAssist.Pages.Investigations.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public CreateModel(FCAssist.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InvestigationTask InvestigationTask { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.InvestigationTask == null || InvestigationTask == null)
            {
                return Page();
            }

            _context.InvestigationTask.Add(InvestigationTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
