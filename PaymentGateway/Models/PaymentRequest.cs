using PaymentGateway.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentGateway.Models
{
    /// <summary>
    /// Represents a payment to be processed
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// Card details
        /// </summary>
        public CardDetails CardDetails { get; set; }
        
        /// <summary>
        /// Payment transaction amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Payment transaction currency code. <example>For example: EUR, GBP, USD </example>
        /// </summary>
        public string Currency { get; set; }
    }
}