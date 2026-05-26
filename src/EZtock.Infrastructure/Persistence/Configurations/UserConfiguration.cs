using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "public");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Dni).IsUnique();
            builder.Property(x=>x.FullName).IsRequired();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.PasswordHashed).IsRequired();
            builder.Property(x => x.Role).IsRequired();
            builder.HasOne(x=>x.Tenant).WithMany().HasForeignKey(x=>x.TenantId);

        }
    }
}
