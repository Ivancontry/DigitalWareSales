using System;
using System.Threading.Tasks;
using SysVentas.Domain.Base;
using SysVentas.Domain.Repositories;
namespace SysVentas.Domain.Contracts
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
