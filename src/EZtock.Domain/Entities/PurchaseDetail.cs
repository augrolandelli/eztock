using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class PurchaseDetail
    {
        public Guid Id { get; set; }
        public Guid PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public decimal Quantity { get; set; }
        public decimal PriceCost { get; set; }
    }
}
