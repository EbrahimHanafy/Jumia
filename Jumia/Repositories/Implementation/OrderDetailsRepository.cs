using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository

    {
        protected readonly DbSet<OrderDetails> _ordersDetails;
       
        public OrderDetailsRepository(AppDBContext context) : base(context)
        {
            _ordersDetails = context.Set<OrderDetails>();
        }
    }
}
