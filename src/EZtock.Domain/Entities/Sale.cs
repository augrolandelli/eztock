using EZtock.Domain.Common;
using EZtock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class Sale : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total => (SubTotal - ((SubTotal*Discount)/100));
        public List<SaleDetail> Details { get; set; } = new List<SaleDetail>();
    }
}
