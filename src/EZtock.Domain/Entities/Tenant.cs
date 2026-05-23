using EZtock.Domain.Common;
using EZtock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class Tenant : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SchemaName { get; set; }
        public bool IsActive { get; set; }
        public PlanType Plan { get; set; }
    }
}
