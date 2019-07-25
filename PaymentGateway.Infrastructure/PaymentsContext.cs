using PaymentGateway.Entities.Models;
using System.Data.Entity;

namespace PaymentGateway.Infrastructure
{
    public class PaymentsContext : DbContext
    {
        public PaymentsContext() : base("PaymentsDatabase")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .ToTable("Payments");

            modelBuilder.Entity<Payment>()
                .Ignore(p => p.PaymentStatus)
                .Property(p => p.PaymentStatusString)
                .HasColumnName("PaymentStatus");
        }
    }
}
