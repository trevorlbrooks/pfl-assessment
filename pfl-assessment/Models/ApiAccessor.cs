using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace pfl_assessment.Models
{
    public class ApiAccessor
    {
        public static readonly ApiAccessor Singleton = new ApiAccessor();
        private static HttpClient Client;
        private static String ApiKey;
        private static String Authorization;
        private static String ApiUrl;

        

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

        //Come back and add queryParam support if needed by the api.
        public async Task<T> Get<T>(String endpoint, List<String> queryParams) {
            HttpResponseMessage response = await Client.GetAsync(endpoint + "?apikey=" + ApiKey);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default(T);
        }

        public async Task<T> Post<T,K>(String endpoint, K payload)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(endpoint, payload);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

    }
}