using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysVentas.Domain.Entities.Invoices;
namespace SysVentas.Infrastructure.Data.Configurations
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
