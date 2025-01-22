// TravelController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelApp.Services;

namespace TravelApp.Controllers {
    /// <summary>
    /// 観光地検索に関するリクエストを処理するコントローラー。
    /// </summary>
    public class TravelController : Controller {
        private readonly RakutenTravelService _rakutenTravelService;

        public TravelController(RakutenTravelService rakutenTravelService) {
            _rakutenTravelService = rakutenTravelService;
        }

        /// <summary>
        /// 指定されたキーワードで観光地情報を検索し、結果をビューに渡す。
        /// </summary>
        public async Task<IActionResult> Search(string keyword) {
            var attractions = await _rakutenTravelService.SearchAttractionsAsync(keyword);
            return View("SearchResults", attractions);
        }
    }
}