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
    public class InvestigationIndexModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public InvestigationIndexModel(FCAssist.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Investigation> Investigations { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Investigation != null)
            {
                Investigations = await _context.Investigation.ToListAsync();
            }
        }
    }
}
