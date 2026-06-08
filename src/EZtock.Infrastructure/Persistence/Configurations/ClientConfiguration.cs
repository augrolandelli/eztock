using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations.Tenant
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.FullName).IsRequired().HasMaxLength(200);
            builder.HasIndex(x => x.Dni).IsUnique();
            builder.Property(x => x.Type).IsRequired();
            builder.HasOne(x=>x.Province).WithMany().HasForeignKey(x=>x.ProvinceId);
            builder.HasOne(x => x.Zone).WithMany().HasForeignKey(x => x.ZoneId);
        }
    }
}
