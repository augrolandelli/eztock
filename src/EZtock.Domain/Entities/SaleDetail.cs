using EZtock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class SaleDetail
    {
        public Guid Id { get; set; }
        public Guid SaleId { get; set; }
        public Sale Sale { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal => Quantity * UnitPrice ;
        public decimal Total => (SubTotal - ((SubTotal * Discount)/100));
    }
}
