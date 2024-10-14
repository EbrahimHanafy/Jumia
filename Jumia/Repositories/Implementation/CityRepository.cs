using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        protected readonly DbSet<City> _city;
        public CityRepository(AppDBContext context) : base(context)
        {
            _city = context.Set<City>();
        }
    }
}
