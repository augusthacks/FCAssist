using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FCAssist.Models;

public class InvestigationTask
{
    [Key]
    public int Id { get; set; }
    public int CaseId { get; set; }
    public int TaskNumber { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<InvestigationFile>? TaskFiles { get; set; }
    public string? CreatedBy { get; set; }
    public string? AssignedBy { get; set; }
    public string? AssignedTo { get; set; }
    public DateTime CreationDateTime { get; set; }
}