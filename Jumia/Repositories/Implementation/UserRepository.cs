using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Jumia.Repositories.Implementation
{
	public class UserRepository : GenericRepository<User> , IUserRepository
	{
		protected readonly DbSet<User> _users;

		public UserRepository(AppDBContext context) : base(context) 
		{
			_users = context.Set<User>();	
		}
	}
}
