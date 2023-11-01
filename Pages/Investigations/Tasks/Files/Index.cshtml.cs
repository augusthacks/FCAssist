﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public IndexModel(FCAssist.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskFile> InvestigationFile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.InvestigationFile != null)
            {
                InvestigationFile = await _context.InvestigationFile.ToListAsync();
            }
        }
    }
}
