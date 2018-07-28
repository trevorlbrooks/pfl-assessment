using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using pfl_assessment.Models.Products;

namespace pfl_assessment.Models
{
    public class ApiAccessor
    {
        public static readonly ApiAccessor Singleton = new ApiAccessor();
        private static HttpClient Client;
        private static String ApiKey;
        private static String Authorization;
        private static String ApiUrl;

        private static string ProductsEndpoint = "products";

        private ApiAccessor() {
            ApiKey = ConfigurationManager.AppSettings["api-key"];
            byte[] authPlaintext = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["api-user"] + ":" + ConfigurationManager.AppSettings["api-pass"]);
            Authorization = Convert.ToBase64String(authPlaintext);
            ApiUrl = ConfigurationManager.ConnectionStrings["api-url"].ConnectionString;

            Client = new HttpClient();
            Client.BaseAddress = new Uri(ApiUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            Client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic",  Authorization);
        }

        public async Task<List<Product>> GetProducts() {
            List<Product> products = new List<Product>();
            HttpResponseMessage response = await Client.GetAsync(ProductsEndpoint + "?apikey=" + ApiKey);
            if (response.IsSuccessStatusCode)
            {
                JsonResponse<List<Product>> parsedResponse = await response.Content.ReadAsAsync<JsonResponse<List<Product>>>();
                products = parsedResponse.Results.Data;
            }
            return products;
        }

        public async Task<String> GetProductsJson()
        {
            HttpResponseMessage response = await Client.GetAsync(ProductsEndpoint + "?apikey=" + ApiKey);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "fail";
        }
    }
}