using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions;

public class CustomException(string message)
        : Exception
{
    public new string Message { get; } = message;
}