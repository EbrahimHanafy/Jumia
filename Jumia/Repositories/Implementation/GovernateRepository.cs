using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class GovernorateRepository : GenericRepository<Governorate>, IGovernorateRepository
    {
        protected readonly DbSet<Governorate> _governorates;
        public GovernorateRepository(AppDBContext context) : base(context)
        {
            _governorates = context.Set<Governorate>();
        }
    }
}
