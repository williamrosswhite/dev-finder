using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevFinder.Backend.Enums;

namespace DevFinder.Data
{
  [Table("Profiles")]
  public class Profile
  {
    [Key]
    public int Id { get; set; }

    // Foreign key property
    [Required]
    public int UserId { get; set; }

    [Required]
    public User User { get; set; } = null!;

    public Salutation? Salutation { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string? MiddleName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string? PreferredFirstName { get; set; }

    [StringLength(50)]
    public string? Pronouns { get; set; }

    [Required]
    [Phone]
    [StringLength(10)]
    public string Phone { get; set; } = null!;

    [Phone]
    [StringLength(6)]
    public string? PhoneExtension { get; set; }

    [StringLength(2048)]
    public string? ProfileImageUrl { get; set; }

    [Required]
    public WorkStatus WorkStatus { get; set; }

    public Address? Address { get; set; }

    public ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    
    public ICollection<Education> Educations { get; set; } = new List<Education>();

    public ICollection<Links> Links { get; set; } = new List<Links>();
  }
}