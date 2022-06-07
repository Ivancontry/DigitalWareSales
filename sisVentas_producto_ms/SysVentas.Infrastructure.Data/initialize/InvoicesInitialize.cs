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
                productDataContext.InvoiceMasters.Add(invoiceIvan1);

                var invoiceIvan2 = new InvoiceMaster(clientIvan.Id);
                invoiceIvan2.AddDetail(productLaptopLenovo.Id, 7, productLaptopLenovo.Price);
                categoryTechnology.UpdateStockProduct(productLaptopLenovo.Id, -7);
                invoiceIvan2.CreatedAt = new DateTime(2000,02,1);
                productDataContext.InvoiceMasters.Add(invoiceIvan2);

                var invoiceIvan3 = new InvoiceMaster(clientIvan.Id);
                invoiceIvan3.AddDetail(productLaptopHp.Id, 2, productLaptopHp.Price);
                categoryTechnology.UpdateStockProduct(productLaptopLenovo.Id, -2);
                invoiceIvan3.CreatedAt = new DateTime(2000, 02, 5);
                productDataContext.InvoiceMasters.Add(invoiceIvan3);

                var invoiceIvan4 = new InvoiceMaster(clientIvan.Id);
                invoiceIvan4.AddDetail(productLaptopHp.Id, 6, productLaptopHp.Price);
                categoryTechnology.UpdateStockProduct(productLaptopLenovo.Id, -6);
                invoiceIvan4.CreatedAt = new DateTime(2000, 06, 5);
                productDataContext.InvoiceMasters.Add(invoiceIvan4);

            #endregion

            productDataContext.SaveChanges();
        }
    }
}
