using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class ReturnRepository :GenericRepository<Return>, IReturnRepository
	{
		protected readonly DbSet<Return>  _returns;

		public ReturnRepository(AppDBContext context) : base(context) 
		{
			_returns = context.Set<Return>();
		}
	}
}
