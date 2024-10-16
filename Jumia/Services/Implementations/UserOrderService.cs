using AutoMapper;
using Jumia.Models;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Services.Implementations
{
    public class UserOrderService (IUnitOfWork unitOfWork, IMapper mapper, AppDBContext context) : IUserORderService 
    {
        public async Task<List<Order>> getByUSerCode(int Usercode)
        {
            var Order = await context.Orders.Where(s => s.UserCode == Usercode)
                .Include(s=>s.OrderDetails)
                .Include(s=>s.Orderstatus).ToListAsync();

            return mapper.Map<List<Order>>(Order);
        }
    }
}
