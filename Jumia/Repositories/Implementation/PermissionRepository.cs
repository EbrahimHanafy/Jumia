using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class PermissionRepository : GenericRepository<Permission> , IPermissionRepository
    {
        protected readonly DbSet<Permission> _permissions;

        public PermissionRepository(AppDBContext context) : base(context)
        {
            _permissions = context.Set<Permission>();
        }
    }
}
