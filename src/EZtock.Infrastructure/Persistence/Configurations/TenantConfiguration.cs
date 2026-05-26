using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("tenants", "public");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.SchemaName).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Plan).IsRequired();
        }
    }
}
