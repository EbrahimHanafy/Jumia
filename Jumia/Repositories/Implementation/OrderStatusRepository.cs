using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class OrderStatusRepository : GenericRepository<OrderStatus> , IOrderStatusRepository
    {
        protected readonly DbSet<OrderStatus> _orderStatuses;
        public OrderStatusRepository(AppDBContext context) : base(context)
        {
            _orderStatuses = context.Set<OrderStatus>();
        }
    }
}
