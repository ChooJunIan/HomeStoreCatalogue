using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HomeStore
{
    public class API
    {
        private HttpClient _httpClient;

        public API()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri("https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
  
            var credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("ck_2682b35c4d9a8b6b6effac126ac552e0bfb315a0:cs_cab8c9a729dfb49c50ce801a9ea41b577c00ad71"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        }

        public async Task<string> GetProductDataAsync(int page)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"api/products?page={page}");
                if (response.IsSuccessStatusCode)
                {
                    
                    string content = await response.Content.ReadAsStringAsync();
                    
                    return content;
                }
                else
                {
                    Console.WriteLine("Error while retrieving Product Data.");
                    return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while retrieving at GetProductDataAsync().");
                return null;
            }
        }
    }
}
