using pfl_assessment.Models.Json;
using pfl_assessment.Models.Json.Products;
using pfl_assessment.Models.Json.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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

        public static async Task<OrderPayload> GetOrder(int id)
        {
            JsonResponse<OrderPayload> order = await Api.Get<JsonResponse<OrderPayload>>(OrderEndpoint + "/" + id, null);
            return order.Results.Data;
        }
    }
}