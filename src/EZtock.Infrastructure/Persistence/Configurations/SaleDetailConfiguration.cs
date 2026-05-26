using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder) {
            builder.ToTable("sale_details");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SaleId).IsRequired();
            builder.Property(x => x.ArticleId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.Discount).IsRequired();
            builder.Ignore(x => x.SubTotal);
            builder.Ignore(x => x.Total);
            builder.HasOne(x => x.Sale).WithMany().HasForeignKey(x => x.SaleId);
            builder.HasOne(x => x.Article).WithMany().HasForeignKey(x => x.ArticleId);
        }
    }
}
