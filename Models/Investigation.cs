using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FCAssist.Models;

public class Investigation
{
    [Key]
    public int Id { get; set; }
    public int CaseId { get; set; }
    public string? OperationName { get; set; }
    public string? Description { get; set; }
    public string FileCoordinator { get; set; }
    public List<FCAUser>? TeamMembers { get; set; }
    public IList<InvestigationTask>? InvestigationTasks { get; set; }
    public IList<InvestigationFile>? InvestigationFiles { get; set; }
    public DateTime PROSCreationDate { get; set; }
    public DateTime FCACreationDate { get; set; }
}