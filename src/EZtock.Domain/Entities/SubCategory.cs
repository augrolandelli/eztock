using EZtock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class SubCategory : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
