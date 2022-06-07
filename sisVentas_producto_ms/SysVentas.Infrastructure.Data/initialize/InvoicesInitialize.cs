using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using SysVentas.Domain.Entities.Categorys;
using SysVentas.Domain.Entities.Invoices;

namespace SysVentas.Infrastructure.Data.initialize
{
    public static partial class InvoicesInitialize
    {
        public static void InitializeInvoice(ProductDataContext productDataContext) {
            #region categoryTechnology
            var categoryTechnology = productDataContext.Categories.Include(t=> t.Products).FirstOrDefault(t => t.Code == "Tec-001");
            var productLaptopAcer = categoryTechnology.Products.FirstOrDefault(t=> t.Code == "Acer-15");
            var productLaptopLenovo = categoryTechnology.Products.FirstOrDefault(t => t.Code == "Len-15");
            var productLaptopHp = categoryTechnology.Products.FirstOrDefault(t => t.Code == "HP-15");

            #endregion             

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


            #region categoryClothing
            var categoryClothing = productDataContext.Categories.Include(t => t.Products).FirstOrDefault(t => t.Code == "Clo-002");
            var productClothingShirt = categoryTechnology.Products.FirstOrDefault(t => t.Code == "Pan-01");
            var productClothingPants = categoryTechnology.Products.FirstOrDefault(t => t.Code == "Shi-11");

            #endregion

            #region InvoicesHelmer
                var clientHelmer = productDataContext.Clients.FirstOrDefault(t => t.Identification == "10650145781");

                var invoiceHelmer1 = new InvoiceMaster(clientHelmer.Id);
                invoiceHelmer1.AddDetail(productClothingShirt.Id, 5, productClothingShirt.Price);
                categoryClothing.UpdateStockProduct(productClothingShirt.Id, -5);
                productDataContext.InvoiceMasters.Add(invoiceHelmer1);

                var invoiceHelmer2 = new InvoiceMaster(clientHelmer.Id);
                invoiceHelmer2.AddDetail(productClothingPants.Id, 7, productClothingPants.Price);
                categoryClothing.UpdateStockProduct(productClothingPants.Id, -7);
                invoiceHelmer2.CreatedAt = new DateTime(2000, 03, 17);
                productDataContext.InvoiceMasters.Add(invoiceHelmer2);

                var invoiceHelmer3 = new InvoiceMaster(clientHelmer.Id);
                invoiceHelmer3.AddDetail(productLaptopHp.Id, 1, productLaptopHp.Price);
                categoryTechnology.UpdateStockProduct(productLaptopLenovo.Id, -1);
                invoiceHelmer3.CreatedAt = new DateTime(2000, 03, 13);
                productDataContext.InvoiceMasters.Add(invoiceHelmer3);

                var invoiceHelmer4 = new InvoiceMaster(clientHelmer.Id);
                invoiceHelmer4.AddDetail(productLaptopHp.Id, 2, productLaptopHp.Price);
                categoryTechnology.UpdateStockProduct(productLaptopLenovo.Id, -2);
                invoiceHelmer4.CreatedAt = new DateTime(2000, 04, 12);
                productDataContext.InvoiceMasters.Add(invoiceIvan4);

            #endregion
            InitializeDuvanInvoices(productDataContext);
            productDataContext.SaveChanges();
        }
    }
}
