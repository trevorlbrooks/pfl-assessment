using Newtonsoft.Json;
using pfl_assessment.Models.Json.Products;
using System;
using System.Collections.Generic;

namespace pfl_assessment.Models.Json.Orders
{
    public class Item
    {
        public int ItemSequenceNumber {get; set;}
        public int ProductID {get; set;}
        public int Quantity {get; set;}
        public int ProductionDays {get; set;}
        public string PartnerItemReference {get; set;}
        public Uri ItemFile {get; set;}
        public List<TemplateData> TemplateData { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        [JsonIgnore]
        public int ShipmentSequenceNumber { get; set; }
    }
}