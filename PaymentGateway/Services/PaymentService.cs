using PaymentGateway.Entities.Models;
using PaymentGateway.Entities.Repositories;
using PaymentGateway.Models;
using System;
using System.Linq;

namespace PaymentGateway.Services
{
    public class PaymentService: IPaymentService
    {
        public IPaymentRepository PaymentRepository { get; }

        public PaymentService(IPaymentRepository paymentRepository)
        {
            PaymentRepository = paymentRepository;
        }

        /// <summary>
        /// Get payment details based on payment unique identifier from data storage
        /// </summary>
        /// <param name="paymentId">Payment unique identifier</param>
        /// <returns>Payment details for the given payment with a masked card number or NULL</returns>
        public PaymentDetails GetPaymentByPaymentId(Guid paymentId)
        {
            var payment = PaymentRepository.List(p => p.PaymentId == paymentId).FirstOrDefault();
            if (payment == null)
                return null;

            var paymentDetails = new PaymentDetails
            {
                PaymentId = payment.PaymentId,
                Amount = payment.Amount,
                Currency = payment.Currency,
                CardDetails = new CardDetails
                {
                    ExpiryMonth = payment.ExpiryDate.Month,
                    ExpiryYear = payment.ExpiryDate.Year,
                    CardNumber = MaskCardNumber(payment.CardNumber)
                }
            };

            return paymentDetails;
        }

        /// <summary>
        /// Save payment details and bank response to data storage
        /// </summary>
        /// <param name="bankResponse">Bank response for the given payment request</param>
        /// <param name="paymentRequest">Payment request details</param>
        public void SavePayment(BankResponse bankResponse, PaymentRequest paymentRequest)
        {
            var payment = new Payment()
            {
                PaymentId = bankResponse.PaymentId,
                PaymentStatus = bankResponse.PaymentStatus,
                Amount = paymentRequest.Amount,
                Currency = paymentRequest.Currency,
                TransactionDate = DateTime.Now,
                CardNumber = paymentRequest.CardDetails.CardNumber,
                ExpiryDate = CalculateExpiryDate(paymentRequest.CardDetails.ExpiryMonth, paymentRequest.CardDetails.ExpiryYear)
            };

            PaymentRepository.Add(payment);
        }

        // Most of the cards are 16 digits long but it should be extended to mask cards of different lengths accordingly
        private string MaskCardNumber(string cardNumber)
        {
            return $"************{cardNumber.Substring(cardNumber.Length - 4, 4)}";
        }

        // I am assuming a card expires at the end of the month
        private DateTime CalculateExpiryDate(int month, int year)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month));
        }
    }
}