using EZtock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.Sales
{
    public class CreateSaleRequest
    {
        public Guid ClientId { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public decimal Discount { get; set; }
        public List<CreateSaleDetailRequest> Details { get; set; } = new List<CreateSaleDetailRequest>();
    }
}
