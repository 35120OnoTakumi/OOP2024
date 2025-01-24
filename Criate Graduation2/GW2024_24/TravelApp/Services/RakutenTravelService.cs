// ファイル: Services/RakutenTravelService.cs
// 目的: 楽天トラベルAPIからデータを取得するためのサービスクラス。
using System.Net.Http.Json;
using TravelApp.Models;

namespace TravelApp.Services {
    public class RakutenTravelService {
        private readonly HttpClient _httpClient;

        public RakutenTravelService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<List<TravelSpot>> SearchTravelSpotsAsync(string query, string areaCode) {
            // APIエンドポイントとキー
            string apiUrl = "https://api.example.com/travel/search";
            string apiKey = "1039389032278599415";

            // クエリパラメータ
            var requestUrl = $"{apiUrl}?query={query}&areaCode={areaCode}&apiKey={apiKey}";

            // API呼び出し
            var response = await _httpClient.GetFromJsonAsync<RakutenTravelResponse>(requestUrl);

            // レスポンスを変換
            return response?.TravelSpots ?? new List<TravelSpot>();
        }
    }
}
