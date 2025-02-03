using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelApp.Services {
    public class RakutenTravelApiClient {
        private readonly HttpClient _httpClient;

        public RakutenTravelApiClient(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<RakutenApiResponse?> SearchHotelsAsync(string keyword) {
            if (string.IsNullOrWhiteSpace(keyword)) {
                return null;
            }

            var url = $"https://app.rakuten.co.jp/services/api/Travel/HotelSearch/20200401?format=json&keyword={Uri.EscapeDataString(keyword)}&applicationId=1039389032278599415";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RakutenApiResponse>(json, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
