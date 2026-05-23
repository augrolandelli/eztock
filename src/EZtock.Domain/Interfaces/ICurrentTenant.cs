using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Interfaces
{
    public interface ICurrentTenant
    {
        public Guid TenantId { get; set; }
        public string SchemaName { get; set; }
    }
}
