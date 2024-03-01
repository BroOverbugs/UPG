using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers;

public static class TimeUzb
{
    public static DateTime Now => DateTime.UtcNow.AddHours(5);
}
