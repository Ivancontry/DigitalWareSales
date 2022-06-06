using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using SysVentas.Domain.Contracts;
using SysVentas.Infrastructure.Data;
using SysVentas.Infrastructure.Data.Base;

namespace SysVentas.Application.Test
{
    public class Class1
    {
        private ProductDataContext _context;
        private IUnitOfWork _unitOfWork;


        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<ProductDataContext>().
                UseInMemoryDatabase("CancelInvoice").Options;

            _context = new ProductDataContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);

        }
    }
}
