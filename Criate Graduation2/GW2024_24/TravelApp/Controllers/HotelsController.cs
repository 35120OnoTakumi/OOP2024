using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using TravelApp.Models; // 必要に応じて適切な名前空間に変更してください

namespace TravelApp.Controllers {
    public class HotelsController : Controller {
        public async Task<IActionResult> Search(string keyword) {
            if (string.IsNullOrWhiteSpace(keyword)) {
                ViewBag.ErrorMessage = "Please enter a keyword.";
                return View();
            }

            var client = new HttpClient();
            string apiKey = "YOUR_API_KEY"; // 必ず正しいAPIキーに置き換えてください
            string url = $"https://api.example.com/hotels?keyword={Uri.EscapeDataString(keyword)}&apikey={apiKey}";

            try {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

                // JSONレスポンスをデシリアライズ
                var options = new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                };

                var hotelResponse = JsonSerializer.Deserialize<HotelResponse>(responseString, options);

                // データをビューに渡す
                if (hotelResponse != null && hotelResponse.Hotels != null) {
                    ViewBag.Result = hotelResponse.Hotels;
                } else {
                    ViewBag.ErrorMessage = "No hotels found.";
                }

                // Debug情報: 開発中のみ使用
                ViewBag.ResponseString = responseString;
            }
            catch (HttpRequestException ex) {
                ViewBag.ErrorMessage = "Error occurred while fetching hotel data.";
                ViewBag.ResponseString = ex.Message;
            }

            return View();
        }
    }
}
