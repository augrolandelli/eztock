using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class ExpirationConfiguration :IEntityTypeConfiguration<Expiration>
    {
        public void Configure(EntityTypeBuilder<Expiration> builder)
        {
            builder.ToTable("expirations");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Batch).WithMany().HasForeignKey(x => x.BatchId);
            builder.Property(x => x.SystemExpectedQuantity).IsRequired();
        }
    }
}
