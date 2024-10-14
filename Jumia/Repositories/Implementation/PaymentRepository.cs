using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class PaymentRepository : GenericRepository<Payment> , IPaymentRepository
    {
        protected readonly DbSet<Payment> _payments;

        public PaymentRepository(AppDBContext context) : base(context)
        {
            _payments = context.Set<Payment>();
        }
    }
}
