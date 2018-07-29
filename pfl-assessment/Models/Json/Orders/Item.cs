using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}