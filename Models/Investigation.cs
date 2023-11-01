using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FCAssist.Models;

public class Investigation
{
    [Key]
    public int Id { get; set; }
    public int CaseNumber { get; set; }
    public string? OperationName { get; set; }
    public string? Description { get; set; }
    public string FileCoordinatorId { get; set; }
    public string FileCoordinatorNormalizedUsername { get; set; }
    public IList<string>? TeamMembers { get; set; }
    public IList<string>? TeamMembersNormalizedUsernames { get; set; }
    public IList<InvestigationTask>? InvestigationTasks { get; set; }
    public IList<TaskFile>? InvestigationFiles { get; set; }
    public DateTime PROSCreationDate { get; set; }
    public DateTime FCACreationDate { get; set; }
}