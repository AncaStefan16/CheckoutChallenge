using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PaymentGateway.Configurations;
using PaymentGateway.Entities;
using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PaymentGateway.Services
{
    /// <summary>
    /// Bank component simulator
    /// 
    /// </summary>
    public class BankService : IBankService
    {
        public BankServiceConfiguration Configuration { get; }

        public BankService(BankServiceConfiguration configuration)
        {
            Configuration = configuration;
        }

        public BankResponse ProcessPayment(PaymentRequest paymentRequest)
        {
            var bankResponse = new BankResponse();
            if (Configuration.IsSimulationModeOn)
            {
                var items = LoadDataFromJson();
                var responseData = items.FirstOrDefault(i => i.CardNumber == paymentRequest.CardDetails.CardNumber);
                if (responseData == null)
                {
                    bankResponse.PaymentStatus = PaymentStatus.Failed;
                }
                else
                {
                    bankResponse.PaymentStatus = responseData.PaymentStatus;
                    bankResponse.PaymentId = responseData.PaymentId;
                }
            }

            return bankResponse;
        }

        private IEnumerable<BankResponseData> LoadDataFromJson()
        {
            var items = new List<BankResponseData>();
            using (StreamReader r = new StreamReader(Path.Combine(HttpRuntime.AppDomainAppPath, Configuration.DummyDataFile)))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<BankResponseData>>(json);
            }

            return items;
        }

    }

    public class BankResponseData
    {
        public Guid PaymentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string CardNumber { get; set; }
    }
}