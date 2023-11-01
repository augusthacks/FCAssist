using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FCAssist.Models;

public class Investigation
{
    [Key]
    public int Id { get; set; }
    public int CaseId { get; set; }
    public string? OperationName { get; set; }
    public string? Description { get; set; }
    public string FileCoordinatorId { get; set; }
    public string FileCoordinatorNormalizedUsername { get; set; }
    public List<string>? TeamMemberIds { get; set; }
    public List<string>? TeamMembersNormalizedUsernames { get; set; }
    public IList<InvestigationTask>? InvestigationTasks { get; set; }
    public IList<InvestigationFile>? InvestigationFiles { get; set; }
    public DateTime PROSCreationDate { get; set; }
    public DateTime FCACreationDate { get; set; }
}