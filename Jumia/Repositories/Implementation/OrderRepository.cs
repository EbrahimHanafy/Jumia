using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class OrderRepository : GenericRepository<Order> , IOrderRepository
    {
        protected readonly DbSet<Order> _orders;
        public OrderRepository(AppDBContext context) : base(context)
        {
            _orders = context.Set<Order>();
        }
    }
}
