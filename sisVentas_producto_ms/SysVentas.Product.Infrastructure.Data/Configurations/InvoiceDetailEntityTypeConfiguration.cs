using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysVentas.Domain.Entities.Invoices;
using SysVentas.Infrastructure.Data.Base;
namespace SysVentas.Infrastructure.Data.Configurations
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
