using DTOS.IdentitiesDTO;
using Infastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UPG.Core.Common;

namespace Web.Configuration;

public static class Config
{
    public static void SeedDatabase(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDBContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        context.Database.Migrate();

        SeedDataAsync(context, userManager, roleManager).Wait();
    }

    private static async Task SeedDataAsync(AppDBContext context,
                                            UserManager<ApplicationUser> userManager,
                                            RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<IdentityRole>
        {
                new IdentityRole { Name = IdentityRoles.SUPER_ADMIN },
                new IdentityRole { Name = IdentityRoles.ADMIN },
                new IdentityRole { Name = IdentityRoles.USER }
            };

        var roleExists = roleManager.Roles.Any();
        if (!roleExists)
        {
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }

        var superAdmin = new ApplicationUser
        {
            FirstName = "Super",
            LastName = "Admin",
            Email = "+998908618018",
            UserName = "+998908618018",
            PhoneNumber = "+998908618018"
        };

        var result = await userManager.CreateAsync(superAdmin, "Admin.123$");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(superAdmin, IdentityRoles.SUPER_ADMIN);
        }
    }
}
