using Jumia.DTO;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class ProductRateUserRepository :GenericRepository<ProductRateUser> ,IProductRateUserRepository
	{
		protected readonly DbSet<ProductRateUser> _productRateUser;
		private readonly DbSet<ProductRate> _productRates;
		private readonly DbSet<User> _users;

		public ProductRateUserRepository(AppDBContext context) : base(context)
		{
			_productRateUser = context.Set<ProductRateUser>();
			_productRates = context.Set<ProductRate>();
			_users = context.Set<User>();
		}
		public async Task<List<ProductRateUser>> GetProductRatesByProductId(int productId)
		{
			return await (from pr in _productRates
						  join u in _users on pr.CreatedBy equals u.UserCode
						  where pr.ProductId == productId
						  orderby pr.Rate ascending
						  select new ProductRateUser
						  {
							  ProductRateId = pr.ProductRateId,
							  ProductId = pr.ProductId,
							  Rate = pr.Rate,
							  Review = pr.Review,
							  RateDate = pr.CreatedAt,
							  UserCode = u.UserCode,
							  UserName = u.UserName,
							  UserEmail = u.Email,
						  }).ToListAsync();
		}
	}
}
