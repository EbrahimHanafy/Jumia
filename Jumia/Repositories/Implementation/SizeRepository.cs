using Jumia.Repositories.Interfaces;
using Jumia.Models;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class SizeRepository : GenericRepository<Size> , ISizeRepository
	{
		protected readonly DbSet<Size> _sizes;

		public SizeRepository(AppDBContext context) : base(context) 
		{
			_sizes = context.Set<Size>();
		}
	}
}
