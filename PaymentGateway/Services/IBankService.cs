using PaymentGateway.Models;

namespace PaymentGateway.Services
{
    public interface IBankService
    {
        BankResponse ProcessPayment(PaymentRequest paymentRequest);
    }
}