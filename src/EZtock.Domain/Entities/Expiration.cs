using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class Expiration
    {
        public Guid Id { get; set; }
        public Guid BatchId { get; set; }
        public Batch Batch { get; set; }
        public decimal SystemExpectedQuantity { get; set; }
        public decimal? ActualQuantityReported { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? CompletedBy { get; set; }
    }
}
