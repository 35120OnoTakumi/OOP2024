using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TravalApp.Services {
    public class RakutenTravelService {
        private readonly HttpClient _httpClient;
        private readonly string _applicationId;
        private readonly string _affiliateId;

        public RakutenTravelService(HttpClient httpClient, IConfiguration configuration) {
            _httpClient = httpClient;
            var rakutenConfig = configuration.GetSection("RakutenTravelAPI");
            _applicationId = rakutenConfig["ApplicationId"];
            _affiliateId = rakutenConfig["AffiliateId"];
        }

        public async Task<string> SearchHotelsAsync(string keyword, string prefectureCode) {
            var baseUrl = "https://app.rakuten.co.jp/services/api/Travel/SimpleHotelSearch/20170426";
            var requestUrl = $"{baseUrl}?applicationId={_applicationId}&affiliateId={_affiliateId}&keyword={keyword}&middleClassCode={prefectureCode}";

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
