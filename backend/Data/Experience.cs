using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevFinder.Data
{
  [Table("Experiences")]
  public class Experience
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Company { get; set; } = null!;

    [Required]
    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Required]
    [MaxLength(100)]
    public string Position { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Location { get; set; } = null!;
  }
}