using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace DTOS.IdentitiesDTO;

public class ApplicationUser : IdentityUser
{
    [Required, StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(50)]
    public string? LastName { get; set; }
}
