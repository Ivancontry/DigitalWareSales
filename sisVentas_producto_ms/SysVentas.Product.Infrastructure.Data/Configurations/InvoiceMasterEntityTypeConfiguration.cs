
using SysVentas.Products.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysVentas.Products.Domain.Entities.Categorys;
using SysVentas.Products.Domain.Entities.Invoices;

namespace SysVentas.Products.Infrastructure.Data.Configurations
{
    public class InvoiceMasterEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceMaster>
    {
        public void Configure(EntityTypeBuilder<InvoiceMaster> builder)
        {
            builder.ToTable(nameof(InvoiceMaster),ProductDataContext.DefaultSchema);
            builder.HasKey(t => t.Id);
        }
    }
}
