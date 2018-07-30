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
    public static class PriceApi
    {
        private static string PriceEndpoint = "price";
        private static ApiAccessor Api = ApiAccessor.Singleton;

        public static async Task<OrderPayload> PriceOrder(OrderPayload order)
        {
            JsonResponse<OrderPayload> pricedOrder = await Api.Post<JsonResponse<OrderPayload>, OrderPayload>(PriceEndpoint, order);
            return pricedOrder.Results.Data;
        }
    }
}