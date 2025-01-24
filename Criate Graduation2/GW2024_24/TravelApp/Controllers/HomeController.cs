// ファイル: Controllers/HomeController.cs
// 目的: ユーザーのリクエストを処理し、結果をビューに渡すコントローラー。
using Microsoft.AspNetCore.Mvc;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Controllers {
    public class HomeController : Controller {
        private readonly RakutenTravelService _rakutenTravelService;

        public HomeController(RakutenTravelService rakutenTravelService) {
            _rakutenTravelService = rakutenTravelService;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query, string areaCode) {
            var results = await _rakutenTravelService.SearchTravelSpotsAsync(query, areaCode);
            var viewModel = new SearchResultsViewModel {
                Results = results,
                SearchQuery = query
            };
            return View("SearchResults", viewModel);
        }
    }
}
