using Microsoft.EntityFrameworkCore;
using SysVentas.Domain.Entities.Categorys;
using SysVentas.Domain.Entities.Clients;
using SysVentas.Domain.Entities.Invoices;
using SysVentas.Infrastructure.Data.Base;
using SysVentas.Infrastructure.Data.Configurations;
namespace SysVentas.Infrastructure.Data
{
    public class ProductDataContext: DbContextBase
    {
        public ProductDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.Entities.Categorys.Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<InvoiceMaster> InvoiceMasters { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public static string DefaultSchema => "SysSales";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceMasterEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceDetailEntityTypeConfiguration());
        }
    }
}
