using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant> 
    {
        Task<Tenant?> GetBySchemaNameAsync(string schemaName);
    }
}
