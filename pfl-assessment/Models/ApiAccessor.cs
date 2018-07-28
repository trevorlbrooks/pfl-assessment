using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

using pfl_assessment.Models.Products;

namespace pfl_assessment.Models
{
    public class ApiAccessor
    {
        public static readonly ApiAccessor Singleton = new ApiAccessor();
        private static HttpClient Client;

        private static string ProductsEndpoint = "products";

        private ApiAccessor() {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://testapi.pfl.com/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //TODO: LOAD IN KEY FROM SECRET MANAGER https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.1&tabs=windows
            Client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic",  "");
        }

        public async Task<List<Product>> GetProducts() {
            List<Product> products = new List<Product>();
            //TODO: LOAD IN KEY FROM SECRET MANAGER
            HttpResponseMessage response = await Client.GetAsync(ProductsEndpoint + "?apikey=");
            if (response.IsSuccessStatusCode)
            {
                JsonResponse<List<Product>> parsedResponse = await response.Content.ReadAsAsync<JsonResponse<List<Product>>>();
                products = parsedResponse.Results.Data;
            }
            return products;
        }

        public async Task<String> GetProductsJson()
        {
            HttpResponseMessage response = await Client.GetAsync(ProductsEndpoint + "?apikey=136085");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "fail";
        }
    }
}