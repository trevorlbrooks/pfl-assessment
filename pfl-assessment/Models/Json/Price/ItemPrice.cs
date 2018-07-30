using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json.Price
{
    public class ItemPrice
    {
        public double? EnvelopePrice { get; set; }
        public double? MailingPrice { get; set; }
        public double? PrintingCostEach { get; set; }
        public double? PrintPrice { get; set; }
        public double? PromotionalDiscount { get; set; }
        public double? RetailFulfillmentPrice { get; set; }
        public double? RetailPrintPrice { get; set; }
        public double? RetailReimbursementPrice { get; set; }
        public double? RetailRushPrice { get; set; }
        public double? RetailShippingPrice { get; set; }
        public double? RushPrice { get; set; }
        public double? SecondSheetPrice { get; set; }
        public double? ShipPrice { get; set; }
        public double? TotalPrice { get; set; }
        public double? TotalPrintingPrice { get; set; }
    }
}