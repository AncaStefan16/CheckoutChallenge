using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentGateway.Configurations
{
    public class BankServiceConfiguration
    {
        public bool IsSimulationModeOn { get; set; }

        public string DummyDataFile { get; set; }

        public string BankServiceUrl { get; set; }
    }
}