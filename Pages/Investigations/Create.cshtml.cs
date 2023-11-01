using FCAssist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FCAssist.Pages.Investigations
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly FCAssist.Data.ApplicationDbContext _context;
        public readonly UserManager<IdentityUser> _userManager;

        public CreateModel(FCAssist.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public MultiSelectList Members { get; set; }
        public ICollection<IdentityUser> Members { get; set; }
        public IActionResult OnGet()
        {
            Members = _userManager.Users.ToList(); 
            //Select(x => x.UserName).ToList());
            return Page();
        }

        [BindProperty]
        public Investigation Investigation { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Investigation == null || Investigation == null)
            {
                return Page();
            }
            if (_context.Investigation.Any(i => i.OperationName == Investigation.OperationName || i.CaseId == Investigation.CaseId))
            {
                ModelState.AddModelError("name number", "An investigation with this name/number already exists.");
                return RedirectToPage("/Error", ModelState);
            }

            _context.Investigation.Add(Investigation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}