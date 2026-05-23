using EZtock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class Purchase : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid ProviderId { get; set; }
        public Client Provider { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
