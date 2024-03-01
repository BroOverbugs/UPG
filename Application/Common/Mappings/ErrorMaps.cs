using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public static class ErrorMaps
    {
        public static string ToErrorString(this IEnumerable<IdentityError> errors)
        {
            return string.Join('\n', errors.Select(e => e.Description));
        }
    }
}
