using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.Sales
{
    public class CreateSaleDetailRequest
    {
        public Guid ArticleId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
