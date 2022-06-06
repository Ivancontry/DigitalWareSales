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
                                          .FirstOrDefault(t => t.Id == productId && t.Status != "IN");
            return product;
        }

        public Domain.Entities.Categorys.Product GetProductForCode(string code)
        {
            var context = Db as ProductDataContext;
            var product = context.Products.FirstOrDefault(t => t.Code == code && t.Status != "IN");
            return product;
        }
    }
}
