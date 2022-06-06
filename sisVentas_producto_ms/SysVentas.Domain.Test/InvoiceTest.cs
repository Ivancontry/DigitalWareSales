using NUnit.Framework;
using System;
using SysVentas.Domain.Entities.Categorys;
using SysVentas.Domain.Entities.Clients;
using SysVentas.Domain.Entities.Invoices;
using SysVentas.Domain.Services;

namespace SysVentas.Domain.Test
{
    public class InvoiceTest
    {
        private readonly ICancelInvoiceMasterService _cancelInvoiceMasterService;
        public InvoiceTest(ICancelInvoiceMasterService cancelInvoiceMasterService)
        {
            _cancelInvoiceMasterService = cancelInvoiceMasterService;
        }
        [Test]
        public void CreateInvoiceSuccessful()
        {
            #region Category
                var categoryTechnology = new Category(DateTime.Now, "Tec-001", "Tecnología");
                var productLaptopAcer = new Product(DateTime.Now, "Acer Aspire 15", "Acer-15", 20, 1800000);
                productLaptopAcer.Id = 1;
                var productXiaomi = new Product(DateTime.Now, "Celular Xiaomi Redmi 9", "Xia-09", 20, 800000);
                productXiaomi.Id = 2;
                categoryTechnology.Products.Add(productLaptopAcer);
                categoryTechnology.Products.Add(productXiaomi);
            #endregion

            #region Client
                var clientIvan = new Client("1003195636", "Ivan Contreras", "3004558041", "22", "Mz C Casa 19 San Jeronimo", "ivancontry.13@gmail.com");
                clientIvan.Id = 1;
            #endregion

            var invoice = new InvoiceMaster(DateTime.Now,clientIvan.Id);
            invoice.AddDetail(productLaptopAcer.Id,1,productLaptopAcer.Price);            
            invoice.AddDetail(productXiaomi.Id, 1, productXiaomi.Price);
            Assert.AreEqual(2600000, invoice.Total);
            
        }
    }
}
