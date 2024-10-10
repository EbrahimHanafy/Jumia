using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class UserPermissionRepository : GenericRepository<UserPermission> , IUserPermissionRepository
	{
		protected readonly DbSet<UserPermission> _userPermissions;

		public UserPermissionRepository(AppDBContext context) : base(context) 
		{
			_userPermissions = context.Set<UserPermission>();	
		}

	}
}
