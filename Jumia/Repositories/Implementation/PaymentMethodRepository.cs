using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class PaymentMethodRepository : GenericRepository<PaymentMethod> , IPaymentMethodRepository
    {
        protected readonly DbSet<PaymentMethod> _paymentMethods;

        public PaymentMethodRepository(AppDBContext context) : base(context)
        {
            _paymentMethods = context.Set<PaymentMethod>();
        }
    }
}
