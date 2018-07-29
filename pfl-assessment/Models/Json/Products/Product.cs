using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public override String ToString() {
            return "Id: " + Id + "\n" +
                "Product Id: " + ProductId + "\n" +
                "Name: " + Name + "\n" +
                "Description: " + Description + "\n" +
                "ImageUrl: " + ImageUrl + "\n" +
                "HasTemplate: " + HasTemplate + "\n" +
                "QuantityDefault: " + QuantityDefault + "\n" +
                "ShippingMethodDefault: " + ShippingMethodDefault + "\n";
        }
    }
}