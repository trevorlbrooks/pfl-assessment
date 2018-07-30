using System;
using System.Collections.Generic;

namespace pfl_assessment.Models.Json.Products
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
        public int? QuantityMinimum { get; set; }
        public int? QuantityMaximum { get; set; }
        public int? QuantityIncrement { get; set; }
        public string ShippingMethodDefault { get; set; }
        public List<DeliveredPrice> DeliveredPrices { get; set; }
        public TemplateFieldList TemplateFields { get; set; }
        public List<ProductionSpeed> ProductionSpeeds { get; set; }
    }
}