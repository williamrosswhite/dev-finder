using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevFinder.Data
{
  [Table("User")]
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    // Ultimately will need a more robust password system
    // Use the built-in PasswordHasher<TUser> from Microsoft.AspNetCore.Identity for simplicity and security
    [Required]
    [StringLength(100)]
    public string Password { get; set; } = null!;
  }
}