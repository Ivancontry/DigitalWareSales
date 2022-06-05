using System;
using System.Threading.Tasks;
using SysVentas.Domain.Base;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Repositories;
using SysVentas.Infrastructure.Data.Repositories;
namespace SysVentas.Infrastructure.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private ICategoryRepository _categorysRepository;
        private IClientRepository _clientsRepository;
        private IInvoiceMasterRepository _invoicesRepository;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_dbContext);
        }

        public IInvoiceMasterRepository InvoicesMasterRepository
        {
            get
            {
                return _invoicesRepository ??= new InvoiceMasterRepository(_dbContext);
            }
        }
        public ICategoryRepository CategorysRepository
        {
            get
            {
                return _categorysRepository ??= new CategoryRepository(_dbContext);
            }
        }

        public IClientRepository ClientsRepository
        {
            get
            {
                return _clientsRepository ??= new ClientRepository(_dbContext);
            }
        }
        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;
            _dbContext.DoDispose();
            _dbContext = null;
        }
    }
}
