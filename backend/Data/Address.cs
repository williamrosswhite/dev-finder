using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevFinder.Data
{
  [Table("Addresses")]
  public class Address
  {
    [Key]
    public int Id { get; set; }

    [MaxLength(10)]
    public string? Unit { get; set; }

    [Required]
    [MaxLength(100)]
    public string StreetAddress { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public required string City { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Province { get; set; }

    [Required]
    [MaxLength(8)]
    public required string PostalCode { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Country { get; set; }
  }
}