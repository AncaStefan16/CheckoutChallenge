using PaymentGateway.Models;
using System;

namespace PaymentGateway.Services
{
    public interface IPaymentService
    {
        /// <summary>
        /// Retrieve payment details
        /// </summary>
        /// <param name="paymentId">The unique identifier of the payment</param>
        /// <returns>Payment details for the given payment ID</returns>
        PaymentDetails GetPaymentByPaymentId(Guid paymentId);

        /// <summary>
        /// Save payment details and bank response to data storage
        /// </summary>
        /// <param name="bankResponse">Bank response for the given payment request</param>
        /// <param name="paymentRequest">Payment request details</param>
        void SavePayment(BankResponse bankResponse, PaymentRequest paymentRequest);
    }
}