using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
    }
}
