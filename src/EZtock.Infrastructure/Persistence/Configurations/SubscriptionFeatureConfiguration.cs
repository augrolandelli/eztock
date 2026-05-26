using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations
{
    public class SubscriptionFeatureConfiguration : IEntityTypeConfiguration<SubscriptionFeature>
    {
        public void Configure(EntityTypeBuilder<SubscriptionFeature> builder) {
            builder.ToTable("subscription_features", "public");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.FeatureId).IsRequired();
            builder.Property(x => x.TenantId).IsRequired();
            builder.HasOne(x=>x.Feature).WithMany().HasForeignKey(x=>x.FeatureId);
            builder.HasOne(x => x.Tenant).WithMany().HasForeignKey(x => x.TenantId);
        }
    }
}
