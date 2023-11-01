using System.ComponentModel.DataAnnotations;

namespace FCAssist.Models;

public class FileContext
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Context { get; set; }
}