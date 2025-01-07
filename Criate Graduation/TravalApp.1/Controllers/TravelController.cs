using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravalApp1.Services;

namespace TravalApp1.Controllers {
    public class TravelController : Controller {
        private readonly RakutenTravelService _rakutenTravelService;

        public TravelController(RakutenTravelService rakutenTravelService) {
            _rakutenTravelService = rakutenTravelService;
        }

        // 検索画面の表示
        public IActionResult Index() {
            return View();
        }

        // 検索処理
        [HttpPost]
        public async Task<IActionResult> Search(string location) {
            if (string.IsNullOrEmpty(location)) {
                ModelState.AddModelError("", "場所を入力してください。");
                return View("Index");
            }

            var response = await _rakutenTravelService.SearchHotelsAsync(location);
            ViewData["Hotels"] = response; // JSONデータをビューに渡す
            return View("Results");
        }
    }
}
