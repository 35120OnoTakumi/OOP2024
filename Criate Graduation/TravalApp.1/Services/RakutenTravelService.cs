using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TravalApp1.Models;

namespace TravalApp1.Services {
    public class RakutenTravelService {
        private readonly HttpClient _httpClient;

        public RakutenTravelService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<RakutenApiResponse> GetTravelDataAsync(string areaCode) {
            var url = $"https://app.rakuten.co.jp/services/api/Travel/SimpleHotelSearch/20170426?format=json&largeClassCode={areaCode}&applicationId=12345678901234567890";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RakutenApiResponse>(json);
            }

            return null;
        }
    }
}
