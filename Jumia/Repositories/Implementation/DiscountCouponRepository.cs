using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class DiscountCouponRepository : GenericRepository<DiscountCoupon>, IDiscountCouponRepository
    {
        protected readonly DbSet<DiscountCoupon> _discountCoupons;
        public DiscountCouponRepository(AppDBContext context) : base(context)
        {
            _discountCoupons = context.Set<DiscountCoupon>();
        }
    }
}
