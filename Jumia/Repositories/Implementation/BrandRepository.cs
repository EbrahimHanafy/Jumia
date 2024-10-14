using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        protected readonly DbSet<Brand> _brands;

        public BrandRepository(AppDBContext context) :base(context)
        {
            _brands = context.Set<Brand>();
        }
    }
}
