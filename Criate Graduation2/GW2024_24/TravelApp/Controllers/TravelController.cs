using Microsoft.AspNetCore.Mvc;
using TravelApp.Services;

namespace TravelApp.Controllers {
    public class TravelController : Controller {
        private readonly RakutenTravelService _rakutenTravelService;

        // コンストラクターでサービスを受け取る
        public TravelController(RakutenTravelService rakutenTravelService) {
            _rakutenTravelService = rakutenTravelService ?? throw new ArgumentNullException(nameof(rakutenTravelService));
        }

        // Index メソッド
        public IActionResult Index() {
            return View();
        }

        // Search メソッド
        [HttpPost]
        public async Task<IActionResult> Search(string keyword) {
            if (string.IsNullOrEmpty(keyword)) {
                ViewBag.Error = "検索キーワードを入力してください。";
                return View("Index");
            }

            try {
                var result = await _rakutenTravelService.SearchHotelsAsync(keyword);
                ViewBag.Result = result;
                return View("Index");
            }
            catch (Exception ex) {
                ViewBag.Error = "検索中にエラーが発生しました: " + ex.Message;
                return View("Index");
            }
        }

    }
}
