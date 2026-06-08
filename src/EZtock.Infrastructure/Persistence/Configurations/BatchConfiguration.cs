using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations.Tenant
{
    public class BatchConfiguration : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder) {
            builder.ToTable("batches");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.BatchNumber).IsRequired();
            builder.Property(x=>x.CurrentQuantity).IsRequired();
            builder.Property(x=>x.InitialQuantity).IsRequired();
            builder.Property(x => x.ExpirationDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.PurchaseDetailId).IsRequired();
            builder.Property(x => x.ArticleId).IsRequired();
            builder.HasOne(x=>x.Article).WithMany(a => a.Batches).HasForeignKey(x=>x.ArticleId);
            builder.HasOne(x => x.PurchaseDetail).WithMany().HasForeignKey(x => x.PurchaseDetailId);
        }
    }
}
