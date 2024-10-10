using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class RefundRepository : GenericRepository<Refund> , IRefundRepository
	{
		protected readonly DbSet<Refund> _refunds;

		public RefundRepository(AppDBContext context) : base(context) 
		{
			_refunds = context.Set<Refund>();
		}
	}
}
