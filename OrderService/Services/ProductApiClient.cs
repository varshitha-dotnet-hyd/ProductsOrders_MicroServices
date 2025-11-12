using OrderService.Models;
using System.Net.Http;

namespace OrderService.Services
{
    public class ProductApiClient
    {
        private readonly HttpClient _httpClient;
        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProductDto> GetProduct(int productId)
        {
            var response = await _httpClient.GetAsync($"api/Products/{productId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var product = await response.Content.ReadFromJsonAsync<ProductDto>();
            return product;
        }
    }
}
