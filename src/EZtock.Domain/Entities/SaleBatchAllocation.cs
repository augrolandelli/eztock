using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class SaleBatchAllocation
    {
        public Guid Id { get; set; }
        public Guid SaleDetailId { get; set; }
        public SaleDetail SaleDetail { get; set; }
        public Guid BatchId { get; set; }
        public Batch Batch { get; set; }
        public decimal Quantity { get; set; }
    }
}
