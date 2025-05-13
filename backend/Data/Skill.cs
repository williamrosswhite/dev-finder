using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevFinder.Data
{
  [Table("Skills")]
  public class Skill
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Years { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Level { get; set; } = null!;

    [MaxLength(100)]
    public string? Note { get; set; } = null!;
  }
}