using PaymentGateway.Entities;
using System;

namespace PaymentGateway.Models
{
    /// <summary>
    /// Represents the response from the bank received as a result of a payment transaction
    /// </summary>
    public class BankResponse
    {
        /// <summary>
        /// Bank unique identifier for a payment transation
        /// </summary>
        public Guid PaymentId { get; set; }

        /// <summary>
        /// Status of the transaction 
        /// </summary>
        public PaymentStatus PaymentStatus { get; set; }
    }
}