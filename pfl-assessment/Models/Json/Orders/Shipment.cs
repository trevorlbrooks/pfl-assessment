using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json.Orders
{
    public class Shipment : Customer
    {
        public int ShipmentSequenceNumber { get; set; }
        public string ShippingMethod { get; set; }
        public string IMBSerialNumber { get; set; }
    }
}