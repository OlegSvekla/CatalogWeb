using CatalogWeb.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogWeb.Infrastructure.EntitesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);

            // Устанавливаем точность и масштаб для свойства Price
            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            builder.Navigation(p => p.Category).AutoInclude();
        }
    }
}
