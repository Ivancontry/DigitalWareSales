
using SysVentas.Products.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysVentas.Products.Domain.Entities.Categorys;
using SysVentas.Products.Domain.Entities.Invoices;
using SysVentas.Products.Infrastructure.Data.Base;

namespace SysVentas.Products.Infrastructure.Data.Configurations
{
    public class InvoiceDetailEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable(nameof(InvoiceDetail), ProductDataContext.DefaultSchema);
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.InvoiceMaster)
                .WithMany(t => t.Details)
                .HasForeignKey(t => t.InvoiceMasterId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.Price).CurrencyValue();
            builder.Property(t => t.Total).CurrencyValue();
        }
    }
}
