using PaymentGateway.Entities.Models;
using PaymentGateway.Entities.Repositories;
using System.Data.Entity;

namespace PaymentGateway.Infrastructure.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
