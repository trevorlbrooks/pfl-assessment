using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfl_assessment.Models.Json.Orders
{
    public class OrderPayload
    {
        public string OrderNumber { get; set; }
        public string PartnerOrderReference {get; set;}
        public Customer OrderCustomer {get; set;}
        public List<Item> Items { get; set; }
        public List<Shipment> Shipments { get; set; }
        public List<Payment> Payments { get; set; }
        public List<ItemShipment> ItemShipments { get; set; }
    }
}