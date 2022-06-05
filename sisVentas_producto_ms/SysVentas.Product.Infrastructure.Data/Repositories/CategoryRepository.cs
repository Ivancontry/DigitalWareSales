using Microsoft.EntityFrameworkCore;
using System.Linq;
using SysVentas.Products.Domain.Entities.Categorys;
using SysVentas.Products.Domain.Repositories;
using SysVentas.Products.Infrastructure.Data.Base;

namespace SysVentas.Products.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbContext context): base(context)
        {

        }

        public Domain.Entities.Categorys.Product GetProduct(long productId)
        {
            var context = Db as ProductDataContext;
            var product = context.Products.Include(p=> p.Category)
                                          .FirstOrDefault(t => t.Id == productId);
            return product;
        }
    }
}
