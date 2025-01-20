using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace TravelApp.Controllers {
    public class HomeController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Search() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string keyword) {
            if (string.IsNullOrEmpty(keyword)) {
                ViewBag.ErrorMessage = "Please enter a search keyword.";
                return View();
            }

            string apiUrl = $"https://app.rakuten.co.jp/services/api/Travel/KeywordHotelSearch/20170426?applicationId=1039389032278599415&keyword={System.Web.HttpUtility.UrlEncode(keyword)}";

            try {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode) {
                    ViewBag.ErrorMessage = "Failed to retrieve data from API.";
                    return View();
                }

                string responseString = await response.Content.ReadAsStringAsync();

                // JSONレスポンスを確認するためのデバッグ用コード
                Console.WriteLine(responseString);
                ViewBag.ResponseString = responseString;

                var hotelResponse = JsonSerializer.Deserialize<HotelResponse>(responseString);

                if (hotelResponse?.Hotels == null || hotelResponse.Hotels.Count == 0) {
                    ViewBag.ErrorMessage = "No hotels found.";
                    return View();
                }

                ViewBag.Result = hotelResponse.Hotels;
                return View();
            }
            catch (Exception ex) {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                return View();
            }
        }
    }

    // モデルクラスの定義
    public class HotelResponse {
        public List<HotelWrapper> Hotels { get; set; }
    }

    public class HotelWrapper {
        public Hotel Hotel { get; set; }
    }

    public class Hotel {
        public HotelBasicInfo HotelBasicInfo { get; set; }
    }

    public class HotelBasicInfo {
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string TelephoneNo { get; set; }
    }
}
