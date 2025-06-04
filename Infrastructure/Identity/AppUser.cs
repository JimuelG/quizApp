using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string Role { get; set; } = "Student";
    public required string FullName { get; set; }
}
