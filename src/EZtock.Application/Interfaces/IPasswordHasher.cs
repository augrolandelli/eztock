using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string hashedPassword);

    }
}
