// HotelsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelApp.Services;

namespace TravelApp.Controllers {
    /// <summary>
    /// ホテル検索に関するリクエストを処理するコントローラー。
    /// </summary>
    public class HotelsController : Controller {
        private readonly RakutenTravelService _rakutenTravelService;

        public HotelsController(RakutenTravelService rakutenTravelService) {
            _rakutenTravelService = rakutenTravelService;
        }

        /// <summary>
        /// 指定されたキーワードでホテル情報を検索し、結果をビューに渡す。
        /// </summary>
        public async Task<IActionResult> Search(string keyword) {
            var hotels = await _rakutenTravelService.SearchHotelsAsync(keyword);
            return View("SearchResults", hotels);
        }
    }
}