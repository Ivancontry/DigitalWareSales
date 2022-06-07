using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using SysVentas.Domain.Entities.Categorys;
using SysVentas.Domain.Entities.Invoices;

namespace SysVentas.Infrastructure.Data.initialize
{
    public static class InvoicesInitialize
    {
        public static void InitializeInvoice(ProductDataContext productDataContext) {
            #region categoryTechnology
            var categoryTechnology = productDataContext.Categories.Include(t=> t.Products).FirstOrDefault(t => t.Code == "Tec-001");
            var productLaptopAcer = categoryTechnology.Products.FirstOrDefault(t=> t.Code == "Acer-15");
            var productLaptopLenovo = categoryTechnology.Products.FirstOrDefault(t => t.Code == "Len-15");
            var productLaptopHp = categoryTechnology.Products.FirstOrDefault(t => t.Code == "HP-15");

            #region InvoicesIvan
                var clientIvan = productDataContext.Clients.FirstOrDefault(t => t.Identification == "1003195636");

                var invoiceIvan1 = new InvoiceMaster(clientIvan.Id);
                invoiceIvan1.AddDetail(productLaptopAcer.Id, 2, productLaptopAcer.Price);
                categoryTechnology.UpdateStockProduct(productLaptopAcer.Id,-2);
                invoiceIvan1.AddDetail(productLaptopLenovo.Id, 7, productLaptopLenovo.Price);
                categoryTechnology.UpdateStockProduct(productLaptopAcer.Id, -2);
                invoiceIvan1.CreatedAt = new DateTime(2000,02,1);

                var invoiceIvan2 = new InvoiceMaster(clientIvan.Id);
                invoiceIvan1.AddDetail(productLaptopHp.Id, 2, productLaptopHp.Price);
                invoiceIvan1.CreatedAt = new DateTime(2000, 02, 5);

                var invoiceIvan3 = new InvoiceMaster(clientIvan.Id);
                invoiceIvan1.AddDetail(productLaptopHp.Id, 6, productLaptopHp.Price);
                invoiceIvan1.CreatedAt = new DateTime(2000, 06, 5);

            #endregion

            productDataContext.SaveChanges();
        }
    }
}
