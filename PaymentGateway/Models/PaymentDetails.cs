using PaymentGateway.Entities;
using System;

namespace PaymentGateway.Models
{
    /// <summary>
    /// Repersents the datails of a payment transaction
    /// </summary>
    public class PaymentDetails
    {
        /// <summary>
        /// Payment unique identifier returned by the bank
        /// </summary>
        public Guid PaymentId { get; set; }

        /// <summary>
        /// Payment card details
        /// </summary>
        public CardDetails CardDetails { get; set; }

        /// <summary>
        /// Payment transaction amount
        /// </summary>>
        public decimal Amount { get; set; }

        /// <summary>
        /// Payment transaction currency code. <example>For example: EUR, GBP, USD </example>
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Payment transaction status
        /// </summary>
        public PaymentStatus PaymentStatus { get; set; }
    }
}