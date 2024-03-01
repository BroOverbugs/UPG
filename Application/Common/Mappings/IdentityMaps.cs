using DTOS.IdentitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
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
                PhoneNumber = registerUser.PhoneNumber,
                EmailConfirmed = false,
            };
        }
    }
}
