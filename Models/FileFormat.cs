using System.ComponentModel.DataAnnotations;

namespace FCAssist.Models;

public class FileFormat
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Format { get; set; }
}