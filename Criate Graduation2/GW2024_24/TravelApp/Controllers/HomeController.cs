using Microsoft.AspNetCore.Mvc;

namespace TravelApp.Controllers {
    /// <summary>
    /// ホーム画面を表示するコントローラー
    /// </summary>
    public class HomeController : Controller {
        public IActionResult Index() {
            return View(); // ホーム画面の表示
        }

        public IActionResult Privacy() {
            return View(); // プライバシーポリシー画面の表示
        }
    }
}
