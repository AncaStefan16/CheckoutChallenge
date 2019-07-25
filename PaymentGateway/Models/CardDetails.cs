using System;

namespace PaymentGateway.Models
{
    /// <summary>
    /// Payment card details to be processed
    /// </summary>
    public class CardDetails
    {
        /// <summary>
        /// Card number digits only
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Card expiry month (1 - 12)
        /// </summary>
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// Card expiry full year. Only full years are accepted
        /// </summary>
        public int ExpiryYear { get; set; }

        /// <summary>
        /// Card CVV
        /// </summary>
        public string Cvv { get; set; }        
    }
}