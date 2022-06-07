using System.Linq;

namespace SysVentas.Infrastructure.Data.initialize
{
    public class InitializeDevelopmentSales
    {
        private readonly ProductDataContext _context;
        public InitializeDevelopmentSales(ProductDataContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            if (!_context.Categories.Any()) CategoryInitialize.InitializeCategory(_context);
            if (!_context.Clients.Any()) ClientInitialize.InitializeClient(_context);
            if (!_context.InvoiceMasters.Any()) InvoicesInitialize.InitializeInvoice(_context);
        }
    }
}
