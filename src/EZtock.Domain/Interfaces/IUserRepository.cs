using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
