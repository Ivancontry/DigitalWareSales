using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SysVentas.Infrastructure.Data;
using SysVentas.Infrastructure.Data.Base;

namespace SysVentas.Application.Test
{
    public class Class1
    {
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<ProductDataContext>().
                UseInMemoryDatabase("CancelInvoice").Options;

            var context = new ProductDataContext(optionsInMemory);
            _=new UnitOfWork(context);

        }
    }
}
