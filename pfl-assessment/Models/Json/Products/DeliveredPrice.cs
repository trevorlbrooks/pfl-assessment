using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json.Products
{
    public class DeliveredPrice
    {
        public string DeliveryMethodCode { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public string LocationType { get; set; }
        public double Price { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public DateTime Created { get; set; }
    }
}