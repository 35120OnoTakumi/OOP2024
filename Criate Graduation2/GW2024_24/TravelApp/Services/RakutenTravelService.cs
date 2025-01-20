using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TravelApp.Services {
    public class RakutenTravelService {
        private readonly HttpClient _httpClient;
        private readonly string _applicationId;
        private readonly string _baseUrl;

        public RakutenTravelService(HttpClient httpClient, IConfiguration configuration) {
            _httpClient = httpClient;
            _applicationId = configuration["RakutenTravelSettings:ApplicationId"];
            _baseUrl = configuration["RakutenTravelSettings:BaseUrl"];
        }

        public async Task<string> SearchHotelsAsync(string keyword) {
            try {
                var requestUrl = $"{_baseUrl}?applicationId={_applicationId}&keyword={keyword}";
                var response = await _httpClient.GetAsync(requestUrl);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) {
                // エラーログを出力
                Console.WriteLine($"エラー: {ex.Message}");
                throw; // エラーを再スロー
            }
        }

    }
}
