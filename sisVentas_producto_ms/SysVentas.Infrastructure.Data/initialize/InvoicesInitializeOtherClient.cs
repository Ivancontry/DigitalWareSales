using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SysVentas.Domain.Entities.Invoices;
namespace SysVentas.Infrastructure.Data.initialize
{
    public static partial class InvoicesInitialize
    {
        public static void InitializeDuvanInvoices(ProductDataContext productDataContext)
        {

            var categoryFootWear = productDataContext.Categories
                .Include(t => t.Products).FirstOrDefault(t => t.Code == "Foo-003");
            var productFootWearBlack = categoryFootWear.Products.FirstOrDefault(t => t.Code == "Zap-14");
            var productFootWearBlue = categoryFootWear.Products.FirstOrDefault(t => t.Code == "Zap-15");
            var productFootWearWhite = categoryFootWear.Products.FirstOrDefault(t => t.Code == "Zap-19");

            #region InvoicesIvan
            var clientDuvan = productDataContext.Clients.FirstOrDefault(t => t.Identification == "1065135735");

            var invoiceDuvan1 = new InvoiceMaster(clientDuvan.Id);

            invoiceDuvan1.AddDetail(productFootWearBlack.Id, 10, productFootWearBlack.Price);
            categoryFootWear.UpdateStockProduct(productFootWearBlack.Id, -10);            
            productDataContext.InvoiceMasters.Add(invoiceDuvan1);

            var invoiceDuvan2 = new InvoiceMaster(clientDuvan.Id);
            invoiceDuvan2.AddDetail(productFootWearBlue.Id, 15, productFootWearBlue.Price);
            categoryFootWear.UpdateStockProduct(productFootWearBlue.Id, -15);            
            productDataContext.InvoiceMasters.Add(invoiceDuvan2);

            var invoiceDuvan3 = new InvoiceMaster(clientDuvan.Id);
            invoiceDuvan3.AddDetail(productFootWearWhite.Id, 2, productFootWearWhite.Price);
            categoryFootWear.UpdateStockProduct(productFootWearWhite.Id, -2);            
            productDataContext.InvoiceMasters.Add(invoiceDuvan3);

            var invoiceDuvan4 = new InvoiceMaster(clientDuvan.Id);
            invoiceDuvan4.AddDetail(productFootWearWhite.Id, 16, productFootWearWhite.Price);
            categoryFootWear.UpdateStockProduct(productFootWearWhite.Id, -16);            
            productDataContext.InvoiceMasters.Add(invoiceDuvan4);
            #endregion

            invoiceDuvan1.CreatedAt = new DateTime(2000, 01, 28);
            invoiceDuvan2.CreatedAt = new DateTime(2000, 02, 1);
            invoiceDuvan3.CreatedAt = new DateTime(2000, 02, 5);
            invoiceDuvan4.CreatedAt = new DateTime(2000, 06, 5);
            
        }
    }
}
