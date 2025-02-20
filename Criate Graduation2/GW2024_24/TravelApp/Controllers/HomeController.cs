using Microsoft.AspNetCore.Mvc;

namespace TravelApp.Controllers {
    public class HomeController : Controller {
        
        // Privacyページ用のアクションを追加
        public IActionResult Privacy() {
            return View();
        }
    }
}
