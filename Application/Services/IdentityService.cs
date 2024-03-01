using Application.Common.Exceptions;
using Application.Common.Mappings;
using Application.Helpers;
using Application.Interfaces;
using DTOS.IdentitiesDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class IdentityService(UserManager<ApplicationUser> userManager,
                                 IConfiguration configuration)
        : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task ChangePasswordAsync(ChangePasswordUser changePasswordUser)
    {
        if (changePasswordUser is null)
        {
            throw new ArgumentNullException(nameof(changePasswordUser));
        }

        var user = await _userManager.FindByEmailAsync(changePasswordUser.Email);
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        var result = await _userManager.ChangePasswordAsync(user, changePasswordUser.CurrentPassword, changePasswordUser.NewPassword);
        if (!result.Succeeded)
        {
            throw new CustomException($"Password change failed:\n{result.Errors.ToErrorString()}");
        }
    }

    public async Task CreateAsync(RegisterUser registerUser)
    {
        if (registerUser is null)
        {
            throw new ArgumentNullException(nameof(registerUser));
        }

        var user = registerUser.ToApplicationUser();

        var result = await _userManager.CreateAsync(user, registerUser.Password);
        if (!result.Succeeded)
        {
            throw new CustomException($"User creation failed:\n{result.Errors.ToErrorString()}");
        }

        foreach (var role in registerUser.Roles)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }

    public async Task DeleteAccountAsync(LoginUser loginUser)
    {
        if (loginUser is null)
        {
            throw new ArgumentNullException(nameof(loginUser));
        }

        var user = await _userManager.FindByEmailAsync(loginUser.Email);
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        await RemoveAccessToken(user);
        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            throw new CustomException($"User deletion failed:\n{result.Errors.ToErrorString()}");
        }
    }

    public async Task<LoginResult> LoginAsync(LoginUser loginUser)
    {
        if (loginUser is null)
        {
            throw new ArgumentNullException(nameof(loginUser));
        }

        var user = await _userManager.FindByEmailAsync(loginUser.Email);
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        var result = await _userManager.CheckPasswordAsync(user, loginUser.Password);
        if (!result)
        {
            throw new CustomException("Invalid password");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var token = JwtHelper.GenerateJwtToken(user, roles, _configuration);
        await RemoveAccessToken(user);
        await SetAccessToken(user, token);

        return new LoginResult
        {
            FullName = $"{user.FirstName} {user.LastName}",
            Email = user.Email!,
            Token = token,
            ExpireAt = TimeUzb.Now.AddMonths(1)
        };
    }

    public async Task LogoutAsync(LogoutUser logoutUser)
    {
        if (logoutUser is null)
        {
            throw new ArgumentNullException(nameof(logoutUser));
        }

        var user = await _userManager.FindByEmailAsync(logoutUser.Email);
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        await RemoveAccessToken(user);
    }

    private async Task RemoveAccessToken(ApplicationUser user)
    {
        var result = await _userManager.RemoveAuthenticationTokenAsync(user, "Application", "AccessToken");
        if (!result.Succeeded)
        {
            throw new CustomException($"Access token removal failed:\n{result.Errors.ToErrorString()}");
        }
    }

    private async Task SetAccessToken(ApplicationUser user, string token)
    {
        var result = await _userManager.SetAuthenticationTokenAsync(user, "Application", "AccessToken", token);
        if (!result.Succeeded)
        {
            throw new CustomException($"Access token setting failed:\n{result.Errors.ToErrorString()}");
        }
    }
}
