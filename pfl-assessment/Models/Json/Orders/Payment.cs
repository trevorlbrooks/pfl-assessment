using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json.Orders
{
    public class Payment
    {
        public string PaymentMethod { get; set; }
        public string PaymentID { get; set; }
        public double PaymentAmount { get; set; }
    }
}