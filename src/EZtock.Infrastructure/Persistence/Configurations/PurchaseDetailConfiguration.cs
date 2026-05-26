using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
    {    
        public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
        {
            builder.ToTable("purchase_details");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.PriceCost).IsRequired();
            builder.HasOne(x => x.Purchase).WithMany().HasForeignKey(x => x.PurchaseId);
            builder.HasOne(x => x.Article).WithMany().HasForeignKey(x => x.ArticleId);
        }
    }
}
