using pfl_assessment.Models.Json;
using pfl_assessment.Models.Json.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace pfl_assessment.Models
{
    public static class ProductsApi
    {
        private static string ProductsEndpoint = "products";
        private static ApiAccessor Api = ApiAccessor.Singleton;

        public static async Task<List<Product>> GetProducts()
        {
            JsonResponse<List<Product>> products = await Api.Get<JsonResponse<List<Product>>>(ProductsEndpoint, null);
            return products.Results.Data;
        }

        public static async Task<Product> GetProduct(int productId) {
            JsonResponse<Product> products = await Api.Get<JsonResponse<Product>>(ProductsEndpoint + "/" + productId, null);
            return products.Results.Data;
        }
    }
}