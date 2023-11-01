using FCAssist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Identity.Client;

namespace FCAssist.Pages.Investigations.Files
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public SelectList InvestigationFileFormats { get; set; }
        public SelectList InvestigationFileContexts { get; set; }

        public CreateModel(IWebHostEnvironment environment, FCAssist.Data.ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;

            InvestigationFileFormats = new SelectList(_context.InvestigationFileFormat.Select(x => x.Format).ToList());
            InvestigationFileContexts = new SelectList(_context.InvestigationFileContext.Select(x => x.Context).ToList());
        }

        public SelectList TeamMembers { get; set; }
        [BindProperty]
        public List<InvestigationFile> InvestigationFiles { get; set; } = default!;
        public List<FileInfo> UploadedFiles { get; set; }

        public IActionResult OnGet(string udir)
        {
            UploadedFiles = new DirectoryInfo(Path.Combine(_environment.ContentRootPath, "TempUploads", udir)).GetFiles().ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //InvestigationDocuments.UploadedBy = User.Identity.Name;
            foreach (InvestigationFile investigationFile in InvestigationFiles)
            {
                if (!ModelState.IsValid || _context.InvestigationFile == null || InvestigationFiles == null)
                {
                    return Page();
                }

                investigationFile.UploadDateTime = DateTime.Now;

                _context.InvestigationFile.Add(investigationFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}