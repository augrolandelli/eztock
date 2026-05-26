using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("sales");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.SubTotal).IsRequired();
            builder.Property(x => x.Discount).IsRequired();
            builder.Ignore(x => x.Total);
            builder.Property(x => x.InvoiceType).IsRequired();
            builder.HasOne(x => x.Client).WithMany().HasForeignKey(x => x.ClientId);
        }
    }
}
