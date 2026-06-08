using EZtock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Configurations.Tenant
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CostPrice).IsRequired();
            builder.Property(x => x.SalePrice).IsRequired();
            builder.Property(x => x.Iva).IsRequired();
            builder.Property(x => x.CostPriceIva).IsRequired();
            builder.Property(x => x.SalePriceIva).IsRequired();
            builder.HasIndex(x => x.Code).IsUnique();
            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId);
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Provider).WithMany().HasForeignKey(x => x.ProviderId);
            builder.HasOne(x => x.SubCategory).WithMany().HasForeignKey(x => x.SubCategoryId);
        }
    }
}
