using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysVentas.Infrastructure.Data.Base;
namespace SysVentas.Infrastructure.Data.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Categorys.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Categorys.Product> builder)
        {
            builder.ToTable(nameof(Product), ProductDataContext.DefaultSchema);
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.Price).CurrencyValue();
        }
    }
}
