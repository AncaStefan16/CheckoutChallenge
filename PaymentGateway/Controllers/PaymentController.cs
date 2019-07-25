using PaymentGateway.Entities;
using PaymentGateway.Models;
using PaymentGateway.Services;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace PaymentGateway.Controllers
{
    public class PaymentController : ApiController
    {
        public IBankService BankService { get; }
        public IPaymentService PaymentService { get; }

        public PaymentController(IBankService bankService, IPaymentService paymentService)
        {
            BankService = bankService;
            PaymentService = paymentService;
        }

        /// <summary>
        /// Retrieve payment details
        /// </summary>
        /// <param name="paymentId">The unique identifier of the payment</param>
        /// <returns>Payment details for the given payment ID or NotFound result</returns>
        [HttpGet]        
        [ResponseType(typeof(PaymentDetails))]
        public IHttpActionResult GetByPaymentId(Guid paymentId)
        {
            var payment = PaymentService.GetPaymentByPaymentId(paymentId);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        /// <summary>
        /// Validate card details and process payment
        /// </summary>
        /// <param name="paymentRequest">The payment details to be processed</param>
        /// <returns>Successful or unsuccessful response</returns>
        [HttpPost]
        [ResponseType(typeof(PaymentStatus))]
        public IHttpActionResult MakePayment([FromBody]PaymentRequest paymentRequest)
        {
            //validate card details

            var bankResponse = BankService.ProcessPayment(paymentRequest);
            PaymentService.SavePayment(bankResponse, paymentRequest);

            if (bankResponse.PaymentStatus == PaymentStatus.Failed)
                return BadRequest("Failed to be processed by the bank");            
                
            return Ok(bankResponse);
        }
    }
}
