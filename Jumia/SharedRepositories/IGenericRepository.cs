using Microsoft.EntityFrameworkCore.Storage;

namespace Jumia.SharedRepositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {

        public Task<Entity> GetByIdAsync(int id);
        public Task<List<Entity>> GetAllAsync();
        public Task<List<Entity>> GetPaged(int pageNumber, int pageSize); //pagination support
        public Task<int> GetTotalPagesAsync(int pageSize);
        public List<Entity> SearchAsync(string searchString, string searchProperty);
        public Task InsertAsync(Entity entity);
        public Task AddRangeAsync(IEnumerable<Entity> entities);
        public Task UpdateAsync(Entity entity);
        public Task UpdateRangeAsync(IEnumerable<Entity> entities);
        public Task DeleteAsync(int id);
        public Task DeleteRangeAsync(IEnumerable<Entity> entities);
    }
}
