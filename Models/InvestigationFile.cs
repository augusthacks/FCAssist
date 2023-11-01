using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FCAssist.Models;

public class InvestigationFile   
{
    [Key]
    public int Id { get; set; }
    public string Location { get; set; }
    public string CaseId { get; set; }
    public string TaskId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int UploadedBy { get; set; }
    public string Format { get; set; }
    public string Context { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime UploadDateTime { get; set; }
}