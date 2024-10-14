using Jumia.Models;
using Jumia.Repositories.Implementation;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Jumia.UnitOfWorks
{
    public class UnitOfWork(AppDBContext context) : IUnitOfWork
    {
        private IDbContextTransaction? _transaction;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        //protected readonly AppDBContext _context;
        //public UnitOfWork()
        //{

        //}

        //This way for just one

        //IBrandRepository? _brandRepository; 
        //public IBrandRepository BrandRepository 
        //{
        //    get
        //    {
        //        _brandRepository ??=new BrandRepository(context);
        //        return _brandRepository;
        //    }
        //}

        // This generic way method for get repository and initialize context (getters)
        public IGenericRepository<T> Repository<T> () where T : class
        {
            if (_repositories.ContainsKey(typeof(T))) 
            {
                return _repositories[typeof(T)] as IGenericRepository<T>;
            }

            var repository = new GenericRepository<T>(context);
            _repositories[typeof (T)] = repository;

            return repository;
        }


        #region Transaction Management
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null) 
            {
                await _transaction.CommitAsync();

                await _transaction.DisposeAsync();

                _transaction = null;
            }
        }
        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null) 
            {
                await _transaction.RollbackAsync();

                await _transaction.DisposeAsync();

                _transaction = null;
            }
        }

        #endregion


        public async Task<int> Save()
        {
            int result;

            try
            {
                result = await context.SaveChangesAsync();
                if (_transaction != null) 
                {
                    await CommitTransactionAsync();
                }
            }
            catch (Exception ex)
            {
                if(_transaction != null)
                {
                    await RollbackTransactionAsync();
                }
                throw;
            }

            return result;
        }

        public void Dispose()
        {
            context.Dispose();
            _transaction?.Dispose();
        }

    }
}
