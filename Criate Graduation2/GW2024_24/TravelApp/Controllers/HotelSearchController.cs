using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Models;

namespace TravelApp.Controllers {
    public class HotelSearchController : Controller {
        private readonly HttpClient _httpClient;

        public HotelSearchController(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public IActionResult Search(string keyword) {
            if (string.IsNullOrEmpty(keyword)) {
                return View("~/Views/Home/Index.cshtml");
            }

            var hotels = FetchHotelsFromApi(keyword);
            return View("~/Views/Home/Index.cshtml", hotels);
        }

        private List<HotelInfo> FetchHotelsFromApi(string keyword) {
            var hotels = new List<HotelInfo>();
            try {
                // Rakuten APIのエンドポイントのURL
                string apiUrl = $"https://app.rakuten.co.jp/services/api/Travel/KeywordHotelSearch/20170426?format=json&keyword={keyword}&applicationId=1039389032278599415";
                var response = _httpClient.GetStringAsync(apiUrl).Result;
                var jsonDoc = JsonDocument.Parse(response);

                foreach (var element in jsonDoc.RootElement.GetProperty("hotels").EnumerateArray()) {
                    var hotelInfo = new HotelInfo {
                        HotelName = element.GetProperty("hotel")[0].GetProperty("hotelBasicInfo").GetProperty("hotelName").GetString() ?? "",
                        HotelInformationUrl = element.GetProperty("hotel")[0].GetProperty("hotelBasicInfo").GetProperty("hotelInformationUrl").GetString() ?? "",
                        HotelThumbnailUrl = element.GetProperty("hotel")[0].GetProperty("hotelBasicInfo").GetProperty("hotelThumbnailUrl").GetString() ?? ""
                    };
                    hotels.Add(hotelInfo);
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error fetching hotels: {ex.Message}");
            }

            return hotels;
        }
    }
}
