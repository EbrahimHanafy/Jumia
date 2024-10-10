using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class UserAddressRepository : GenericRepository<UserAddress>, IUserAddressRepository
	{
		protected readonly DbSet<UserAddress> _userAddresses;

		public UserAddressRepository(AppDBContext context) : base(context) 
		{
			_userAddresses = context.Set<UserAddress>();
		}
	}
}
