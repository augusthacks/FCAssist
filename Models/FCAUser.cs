using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FCAssist.Models
{
    public class FCAUser : IdentityUser
    {
        public ICollection<Investigation> Investigations { get; set; }
        public ICollection<InvestigationTask> AssignedTasks { get; set; }
        public ICollection<InvestigationFile> UploadedFiles { get; set; }
    }
}
