using SysVentas.Domain.Contracts;
using SysVentas.Domain.Entities.Categorys;
namespace SysVentas.Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Product GetProduct(long productId);
        Product GetProductForCode(string code);
    }
}
