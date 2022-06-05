using SysVentas.Domain.Entities.Invoices;
using SysVentas.Domain.Repositories;
using SysVentas.Infrastructure.Data.Base;
namespace SysVentas.Infrastructure.Data.Repositories
{
    public class InvoiceMasterRepository : GenericRepository<InvoiceMaster>, IInvoiceMasterRepository
    {
        public InvoiceMasterRepository(IDbContext context): base(context)
        {

        }
        
    }
}
