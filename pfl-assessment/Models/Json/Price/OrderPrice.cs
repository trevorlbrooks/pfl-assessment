using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json.Price
{
    public class OrderPrice
    {
        public double? BundleCouponAmount { get; set; }
        public double? EnvelopeTotalPrice { get; set; }
        public double? MailingPriceTotal { get; set; }
        public double? OrderTotalPrice { get; set; }
        public double? PrintPriceTotal { get; set; }
        public double? RushTotalPrice { get; set; }
        public double? SecondSheetTotal { get; set; }
        public double? ShipPriceTotal { get; set; }
    }
}