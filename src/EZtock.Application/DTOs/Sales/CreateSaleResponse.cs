using EZtock.Domain.Entities;
using EZtock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.Sales
{
    public class CreateSaleResponse
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime Date {  get; set; }
        public InvoiceType InvoiceType { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public List<CreateSaleDetailResponse> Details { get; set; }
    }
}
