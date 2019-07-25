using System;

namespace PaymentGateway.Entities.Models
{
    public class Payment: EntityBase
    {
        public Guid PaymentId { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }
        
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime TransactionDate { get; set; }

        public string PaymentStatusString
        {
            get => PaymentStatus.ToString();

            set
            {
                PaymentStatus newValue;
                if (Enum.TryParse(value, out newValue))
                { PaymentStatus = newValue; }
            }
        }
    }
}
