using SysVentas.Products.Domain.Entities.Invoices;
using SysVentas.Products.Domain.Repositories;
using SysVentas.Products.Infrastructure.Data.Base;

namespace SysVentas.Products.Infrastructure.Data.Repositories
{
    public class InvoiceMasterRepository : GenericRepository<InvoiceMaster>, IInvoiceMasterRepository
    {
        public InvoiceMasterRepository(IDbContext context): base(context)
        {

        }
        
    }
}
