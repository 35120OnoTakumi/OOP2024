using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TravalApp1.Services {
    public class RakutenTravelService {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RakutenTravelService(HttpClient httpClient, IConfiguration configuration) {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> SearchHotelsAsync(string location) {
            var baseUrl = _configuration["RakutenTravelAPI:BaseUrl"];
            var appId = _configuration["RakutenTravelAPI:ApplicationId"];
            var url = $"{baseUrl}/Travel/HotelSearch/20170426?applicationId={appId}&location={location}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
