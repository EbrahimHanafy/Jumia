using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        protected readonly DbSet<Country> _countries;
        public CountryRepository(AppDBContext context) : base(context)
        {
            _countries = context.Set<Country>();
        }
    }
}
