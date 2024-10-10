using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class MaterialsCareRepository : GenericRepository<MaterialsCare>, IMaterialsCareRepository
    {
        protected readonly DbSet<MaterialsCare> _materialsCares;
        public MaterialsCareRepository(AppDBContext context) : base(context)
        {
            _materialsCares = context.Set<MaterialsCare>();
        }
    }
}
