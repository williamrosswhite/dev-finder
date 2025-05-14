using Microsoft.AspNetCore.Identity;

namespace DevFinder.Data
{
    // Inherit from IdentityUser<int> for ASP.NET Core Identity integration with int keys
    public class User : IdentityUser<int>
    {
        // Add any custom properties below as needed.
        // For example:
        // public string? DisplayName { get; set; }
        // public DateTime RegisteredAt { get; set; }
    }
}