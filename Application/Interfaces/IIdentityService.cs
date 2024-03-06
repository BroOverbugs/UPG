using DTOS.IdentitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IIdentityService
{
    Task CreateAsync(RegisterUser registerUser);
    Task CreateAdminAsync(RegisterAdmin registerAdmin);
    Task<LoginResult> LoginAsync(LoginUser loginUser);
    Task LogoutAsync(LogoutUser logoutUser);

    Task ChangePasswordAsync(ChangePasswordUser changePasswordUser);
    Task DeleteAccountAsync(LoginUser loginUser);
}
