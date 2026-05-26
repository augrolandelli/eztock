using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("purchases");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.InvoiceNumber).IsRequired();
            builder.HasOne(x => x.Provider).WithMany().HasForeignKey(x => x.ProviderId);
        }
    }
}
