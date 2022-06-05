using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVentas.Products.Domain;
using SysVentas.Products.Domain.Entities.Categorys;
using SysVentas.Products.Domain.Entities.Invoices;
using SysVentas.Products.Infrastructure.Data.Base;
using SysVentas.Products.Infrastructure.Data.Configurations;

namespace SysVentas.Products.Infrastructure.Data
{
    public class ProductDataContext: DbContextBase
    {
        public ProductDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product> Clients { get; set; }
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
