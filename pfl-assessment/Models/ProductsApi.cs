using pfl_assessment.Models.Json;
using pfl_assessment.Models.Json.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public static async Task<Product> GetProduct(int productId)
        {
            JsonResponse<Product> product = await Api.Get<JsonResponse<Product>>(ProductsEndpoint + "/" + productId, null);
            if (product != null && product.Results != null && product.Results.Data != null)
            {
                product.Results.Data.ProductId = product.Results.Data.Id;
            }
            else
            {
                return new Product();
            }
            return product.Results.Data;
        }
    }
}