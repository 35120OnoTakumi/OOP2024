using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelApp.Models;
using TravelApp.Extensions;  // SessionExtensions を追加

namespace TravelApp.Controllers {
    public class HotelSearchController : Controller {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HotelSearchController> _logger;
        private const string FavoriteSessionKey = "FavoriteHotels";

        public HotelSearchController(HttpClient httpClient, ILogger<HotelSearchController> logger) {
            _httpClient = httpClient;
            _logger = logger;
        }

        // ホテル検索結果を表示
        public async Task<IActionResult> Search(string keyword, int page = 1) {
            if (string.IsNullOrEmpty(keyword)) {
                return View("~/Views/Home/Index.cshtml", new List<HotelInfo>());
            }

            var hotels = await FetchHotelsFromApiAsync(keyword);

            // 1ページに表示するホテル数
            int pageSize = 10;
            var pagedHotels = hotels.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // ホテル名のカッコ内情報がない場合はカッコを表示しない
            foreach (var hotel in pagedHotels) {
                if (string.IsNullOrEmpty(hotel.HotelSubname)) {
                    hotel.HotelName = hotel.HotelName;  // カッコ内がない場合はそのまま
                } else {
                    hotel.HotelName = $"{hotel.HotelName} ({hotel.HotelSubname})";  // カッコ内情報があれば追加
                }
            }

            ViewBag.TotalPages = Math.Ceiling((double)hotels.Count / pageSize);
            ViewBag.CurrentPage = page;

            return View("~/Views/Home/Index.cshtml", pagedHotels);
        }

        private async Task<List<HotelInfo>> FetchHotelsFromApiAsync(string keyword) {
            var hotels = new List<HotelInfo>();
            try {
                string apiKey = "103938932278599415";  // APIキーを設定
                string apiUrl = $"https://app.rakuten.co.jp/services/api/Travel/KeywordHotelSearch/20170426?format=json&keyword={keyword}&applicationId={apiKey}";
                var response = await _httpClient.GetStringAsync(apiUrl);
                var jsonDoc = JsonDocument.Parse(response);

                foreach (var element in jsonDoc.RootElement.GetProperty("hotels").EnumerateArray()) {
                    var hotelElement = element.GetProperty("hotel")[0].GetProperty("hotelBasicInfo");

                    var hotelInfo = new HotelInfo {
                        HotelName = hotelElement.GetProperty("hotelName").GetString() ?? "",
                        HotelInformationUrl = hotelElement.GetProperty("hotelInformationUrl").GetString() ?? "",
                        HotelThumbnailUrl = hotelElement.GetProperty("hotelThumbnailUrl").GetString() ?? "",
                        HotelSubname = hotelElement.GetProperty("hotelSubname").ValueKind == JsonValueKind.Null
                            ? "" // hotelSubname が null の場合は空文字
                            : hotelElement.GetProperty("hotelSubname").GetString() // null でなければ値を取得
                    };

                    hotels.Add(hotelInfo);
                }
            }
            catch (Exception ex) {
                _logger.LogError($"Error fetching hotels: {ex.Message}");
            }

            return hotels;
        }

        // お気に入りに追加
        public IActionResult AddToFavorites(string hotelName, string hotelUrl, string thumbnailUrl) {
            var favorites = GetFavoriteHotels();

            if (!favorites.Any(f => f.HotelName == hotelName)) {
                favorites.Add(new HotelInfo {
                    HotelName = hotelName,
                    HotelInformationUrl = hotelUrl,
                    HotelThumbnailUrl = thumbnailUrl,
                    IsFavorite = true
                });
                HttpContext.Session.SetObjectAsJson(FavoriteSessionKey, favorites);
            }

            return RedirectToAction("Favorites");
        }

        // お気に入りから削除
        public IActionResult RemoveFromFavorites(string hotelName) {
            var favorites = GetFavoriteHotels();
            favorites.RemoveAll(f => f.HotelName == hotelName);
            HttpContext.Session.SetObjectAsJson(FavoriteSessionKey, favorites);
            return RedirectToAction("Favorites");
        }

        // セッションからお気に入りを取得
        private List<HotelInfo> GetFavoriteHotels() {
            return HttpContext.Session.GetObjectFromJson<List<HotelInfo>>(FavoriteSessionKey) ?? new List<HotelInfo>();
        }

        // お気に入りページを表示
        public IActionResult Favorites() {
            var favorites = GetFavoriteHotels();
            return View("~/Views/HotelSearch/Favorites.cshtml", favorites);
        }
    }
}
