// RakutenTravelService.cs
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelApp.Services {
    /// <summary>
    /// 楽天トラベルAPIとの通信を行うサービスクラス。
    /// </summary>
    public class RakutenTravelService {
        private readonly HttpClient _httpClient;

        public RakutenTravelService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        /// <summary>
        /// 指定されたキーワードでホテル情報を取得する非同期メソッド。
        /// </summary>
        public async Task<List<RakutenTravelResponse>> SearchHotelsAsync(string keyword) {
            string url = $"https://example.com/api/hotels?keyword={keyword}"; // ダミーURL
            var response = await _httpClient.GetStringAsync(url);
            return JsonSerializer.Deserialize<List<RakutenTravelResponse>>(response);
        }

        /// <summary>
        /// 指定されたキーワードで観光地情報を取得する非同期メソッド。
        /// </summary>
        public async Task<List<RakutenTravelResponse>> SearchAttractionsAsync(string keyword) {
            string url = $"https://example.com/api/attractions?keyword={keyword}"; // ダミーURL
            var response = await _httpClient.GetStringAsync(url);
            return JsonSerializer.Deserialize<List<RakutenTravelResponse>>(response);
        }
    }
}