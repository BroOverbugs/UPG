using DTOS.IdentitiesDTO;

namespace Application.Common.Mappings;

public static class IdentityMaps
{
    public static ApplicationUser ToApplicationUser(this RegisterUser registerUser)
    {
        return new ApplicationUser
        {
            UserName = registerUser.Email,
            Email = registerUser.Email,
            FirstName = registerUser.FirstName,
            LastName = registerUser.LastName,
            EmailConfirmed = false,
        };
    }

    public static ApplicationUser ToApplicationUserForAdmin(this RegisterAdmin registerAdmin)
    {
        return new ApplicationUser
        {
            UserName = registerAdmin.Email,
            Email = registerAdmin.Email,
            FirstName = registerAdmin.FirstName,
            LastName = registerAdmin.LastName,
            PhoneNumber = registerAdmin.PhoneNumber,
            EmailConfirmed = false,
        };
    }
}