using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevFinder.Data
{
  [Table("External Links")]
  public class Links
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string LinkAddress { get; set; } = null!;
  }
}