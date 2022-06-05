using SysVentas.Domain.Entities.Clients;
using SysVentas.Domain.Repositories;
using SysVentas.Infrastructure.Data.Base;
namespace SysVentas.Infrastructure.Data.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(IDbContext context): base(context)
        {

        }
        
    }
}
