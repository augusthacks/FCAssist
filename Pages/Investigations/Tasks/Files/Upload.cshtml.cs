using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FCAssist.Pages.Investigations.Files
{
    [Authorize]
    public class UploadModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        private readonly ILogger<IndexModel> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly FCAssist.Data.ApplicationDbContext _context;

        public UploadModel(ILogger<IndexModel> logger, IWebHostEnvironment environment, FCAssist.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _environment = environment;
            _context = context;
        }

        [BindProperty]
        public List<IFormFile> UploadedDocuments { get; set; }

        public IActionResult OnPost(List<IFormFile> UploadedDocuments)
        {
            DirectoryInfo TempDirectory = Directory.CreateDirectory(Path.Combine(_environment.ContentRootPath, "TempUploads", Path.GetRandomFileName()));

            foreach (IFormFile document in UploadedDocuments)
            {
                if (document == null)
                {
                    return Content("No file was selected or the file is empty");
                }

                var filepath = Path.Combine(TempDirectory.FullName, document.FileName);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    document.CopyToAsync(fileStream);
                }
            }

            return RedirectToPage("/Investigations/Files/Create", new { udir = TempDirectory.Name });
        }
    }
}