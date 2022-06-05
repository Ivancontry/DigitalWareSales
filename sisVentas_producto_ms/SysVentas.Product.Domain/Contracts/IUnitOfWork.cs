using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVentas.Products.Domain.Base;
using SysVentas.Products.Domain.Repositories;

namespace SysVentas.Domain.Base
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;
        public ICategoryRepository CategorysRepository { get; }
        public IClientRepository ClientsRepository { get; }
        public IInvoiceMasterRepository InvoicesMasterRepository { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
