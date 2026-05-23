using EZtock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class Batch : AuditableEntity
    {
        public Guid Id { get; set; }
        public int BatchNumber { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public Guid PurchaseDetailId { get; set; }
        public PurchaseDetail PurchaseDetail { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public decimal InitialQuantity { get; set; }
        public decimal CurrentQuantity { get; set; }
        public bool IsActive { get; set; }
        


    }
}
