using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri ImageUrl { get; set; }
        public bool HasTemplate { get; set; }
        public int QuantityDefault { get; set; }
        public string ShippingMethodDefault { get; set; }
        public List<DeliveredPrice> DeliveredPrices { get; set; }
    }
}