using pfl_assessment.Models.Json;
using pfl_assessment.Models.Json.Products;
using pfl_assessment.Models.Json.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pfl_assessment.Models
{
    public static class OrderApi
    {
        private static string OrderEndpoint = "orders";
        private static ApiAccessor Api = ApiAccessor.Singleton;

        public static async Task<OrderPayload> PlaceOrder(OrderPayload order)
        {
            JsonResponse<OrderPayload> pricedOrder = await Api.Post<JsonResponse<OrderPayload>, OrderPayload>(OrderEndpoint, order);
            return pricedOrder.Results.Data;
        }

        public static async Task<OrderPayload> GetOrder(string id)
        {
            JsonResponse<OrderPayload> order = await Api.Get<JsonResponse<OrderPayload>>(OrderEndpoint + "/" + id, null);
            return order.Results.Data;
        }

        //Populates one-indexed item sequences on the cart for pricing and ordering.
        private static void PopulateItemSequenceNumbers(List<Item> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].ItemSequenceNumber = i + 1;
                int productionDays = 0;
                foreach (ProductionSpeed speed in itemList[i].Product.ProductionSpeeds)
                {
                    if (speed.IsDefault)
                    {
                        productionDays = speed.Days;
                        break;
                    }
                }
                itemList[i].ProductionDays = productionDays;
            }
        }

        //Vanity call, test api does not require payment info.
        public static OrderPayload CreateOrderPayload(List<Item> items, Customer customer)
        {
            return CreateOrderPayload(items, customer, null);
        }

        //Creates the order payload for both pricing and ordering requests
        public static OrderPayload CreateOrderPayload(List<Item> items, Customer customer, List<Payment> payments)
        {
            PopulateItemSequenceNumbers(items);

            //Set up some data structs
            Dictionary<String, Shipment> shipmentsSet = new Dictionary<String, Shipment>();
            int numShipments = 0;
            List<ItemShipment> itemShipments = new List<ItemShipment>();


            foreach (Item item in items)
            {
                //If the item's default shipping method is new, add it. Use customer info to populate.
                if (!shipmentsSet.ContainsKey(item.Product.ShippingMethodDefault))
                {
                    shipmentsSet.Add(item.Product.ShippingMethodDefault, new Shipment
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        CompanyName = customer.CompanyName,
                        Address1 = customer.Address1,
                        Address2 = customer.Address2,
                        City = customer.City,
                        State = customer.State,
                        PostalCode = customer.PostalCode,
                        CountryCode = customer.CountryCode,
                        Phone = customer.Phone,
                        ShipmentSequenceNumber = numShipments + 1,
                        ShippingMethod = item.Product.ShippingMethodDefault,
                        //Fixme: add
                        IMBSerialNumber = null
                    });
                    numShipments++;
                }
                //For every item, add it to the item shipment list with the seq of the preferred shipment
                itemShipments.Add(new ItemShipment
                {
                    ItemSequenceNumber = item.ItemSequenceNumber,
                    ShipmentSequenceNumber = shipmentsSet[item.Product.ShippingMethodDefault].ShipmentSequenceNumber
                });
            }

            //Make list out of generated shipment methods.
            List<Shipment> shipments = new List<Shipment>(shipmentsSet.Values);

            //load up the payload with generated data.
            return new OrderPayload
            {
                Items = items,
                OrderCustomer = customer,
                PartnerOrderReference = Guid.NewGuid().ToString(),
                Shipments = shipments,
                ItemShipments = itemShipments,
                Payments = payments
            };
        }
    }
}