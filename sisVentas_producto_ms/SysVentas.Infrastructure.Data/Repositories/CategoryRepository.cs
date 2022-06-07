using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SysVentas.Domain.Entities.Categorys;
using SysVentas.Domain.Repositories;
using SysVentas.Infrastructure.Data.Base;
namespace SysVentas.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbContext context): base(context)
        {

        }

        public Product GetProduct(long productId)
        {
            var context = Db as ProductDataContext;
            var product = context.Products.Include(p=> p.Category)
                                          .FirstOrDefault(t => t.Id == productId && t.Status != "IN");
            return product;
        }

        public List<Product> GetProducts()
        {
            var context = Db as ProductDataContext;
            var products = context.Products.Include(p => p.Category)
                                          .Where(t => t.Status != "IN")
                                          .ToList();
            return products;
        }

        public Product GetProductForCode(string code)
        {
            var context = Db as ProductDataContext;
            var product = context.Products.FirstOrDefault(t => t.Code == code && t.Status != "IN");
            return product;
        }
    }
}
