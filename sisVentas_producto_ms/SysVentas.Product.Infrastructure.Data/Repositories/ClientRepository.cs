using Microsoft.EntityFrameworkCore;
using System.Linq;
using SysVentas.Products.Domain.Entities.Categorys;
using SysVentas.Products.Domain.Entities.Clients;
using SysVentas.Products.Domain.Repositories;
using SysVentas.Products.Infrastructure.Data.Base;

namespace SysVentas.Products.Infrastructure.Data.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(IDbContext context): base(context)
        {

        }
        
    }
}
