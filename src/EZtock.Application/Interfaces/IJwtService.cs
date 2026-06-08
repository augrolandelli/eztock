using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
