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

        public Domain.Entities.Categorys.Product GetProduct(long productId)
        {
            var context = Db as ProductDataContext;
            var product = context.Products.Include(p=> p.Category)
                                          .FirstOrDefault(t => t.Id == productId);
            return product;
        }
    }
}
