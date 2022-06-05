
using SysVentas.Products.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysVentas.Products.Domain.Entities.Categorys;
using SysVentas.Products.Infrastructure.Data.Base;

namespace SysVentas.Products.Infrastructure.Data.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Products), ProductDataContext.DefaultSchema);
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.Price).CurrencyValue();
        }
    }
}
