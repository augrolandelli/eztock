using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class SaleBatchAllocationConfiguration : IEntityTypeConfiguration<SaleBatchAllocation>
    {
        public void Configure(EntityTypeBuilder<SaleBatchAllocation> builder)
        {
            builder.ToTable("sale_batch_allocations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.SaleDetail).WithMany().HasForeignKey(x => x.SaleDetailId);
            builder.HasOne(x => x.Batch).WithMany().HasForeignKey(x => x.BatchId);
        }
    }
}
