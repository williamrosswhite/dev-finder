using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevFinder.Backend.Enums;

namespace DevFinder.Data
{
  [Table("Educations")]
  public class Education
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Institution { get; set; } = null!;

    [Required]
    public DegreeType Degree { get; set; }

    [MaxLength(100)]
    public string? DegreeTypeOther { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [Required]
    [MaxLength(100)]
    public string Major { get; set; } = null!;

    public string? Minor { get; set; }

    [Required]
    [MaxLength(100)]
    public string Location { get; set; } = null!;
  }
}