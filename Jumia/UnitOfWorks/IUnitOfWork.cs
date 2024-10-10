using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Jumia.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        // Generic repository accessor
        IGenericRepository<T> Repository<T> () where T : class;

        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task CommitTransactionAsync();
        public Task RollbackTransactionAsync();
        Task<int> Save();
    }
}
