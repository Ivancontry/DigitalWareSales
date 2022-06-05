﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVentas.Products.Domain.Base;
using SysVentas.Products.Domain.Entities.Categorys;

namespace SysVentas.Products.Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Product GetProduct(long productId);
    }
}
