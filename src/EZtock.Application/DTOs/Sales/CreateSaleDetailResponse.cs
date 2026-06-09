using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.Sales
{
    public class CreateSaleDetailResponse
    {
        public Guid ArticleId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
