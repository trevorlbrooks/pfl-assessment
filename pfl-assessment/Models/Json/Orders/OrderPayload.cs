using System.Collections.Generic;
using pfl_assessment.Models.Json.Price;

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
        public OrderPrice OrderPrices { get; set; }
    }
}