using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FCAssist.Models;

namespace FCAssist.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FCAssist.Models.Investigation> Investigation { get; set; } = default!;
        public DbSet<FCAssist.Models.InvestigationFile> InvestigationFile { get; set; } = default!;
        public DbSet<FCAssist.Models.InvestigationTask> InvestigationTask { get; set; } = default!;
        public DbSet<FCAssist.Models.FileFormat> InvestigationFileFormat { get; set; } = default!;
        public DbSet<FCAssist.Models.FileContext> InvestigationFileContext { get; set; } = default!;
    }
}