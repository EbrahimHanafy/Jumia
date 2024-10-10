using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class ReturnDetailsRepository : GenericRepository<ReturnDetails>, IReturnDetailsRepository
	{
		protected readonly DbSet<ReturnDetails> _returnDetails;

	    public ReturnDetailsRepository(AppDBContext context) : base(context) 
		{
			_returnDetails = context.Set<ReturnDetails>();
		}
	}
}
