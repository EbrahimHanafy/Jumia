using Jumia.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace Jumia.SharedRepositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected readonly AppDBContext _context; //object to connect database
        protected readonly DbSet<Entity> _dbset; //represents the table in the database that holds data for a specific entity

        public GenericRepository(AppDBContext context)
        {
            this._context = context;
            this._dbset = _context.Set<Entity>();
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task InsertAsync(Entity entity)
        {
            await _dbset.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<Entity> entities)
        {
            _dbset.AddRange(entities);
        }

        public async Task UpdateAsync(Entity entity)
        {
            _dbset.Update(entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<Entity> entities)
        {
            _dbset.UpdateRange(entities);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<Entity> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public Task<List<Entity>> GetPaged(int pageNumber, int pageSize)
        {
            return _dbset.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetTotalPagesAsync(int pageSize)
        {
            int totalCount = await _dbset.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            return totalPages;
        }

        public List<Entity> SearchAsync(string searchString, string searchProperty)
        {
            throw new NotImplementedException();
        }


    }
}
