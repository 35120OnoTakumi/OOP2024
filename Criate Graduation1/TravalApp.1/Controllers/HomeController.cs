using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravalApp.Services;

namespace TravalApp.Controllers {
    public class HomeController : Controller {
        private readonly RakutenTravelService _rakutenTravelService;

        public HomeController(RakutenTravelService rakutenTravelService) {
            _rakutenTravelService = rakutenTravelService;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string keyword, string prefectureCode) {
            var result = await _rakutenTravelService.SearchHotelsAsync(keyword, prefectureCode);
            ViewBag.SearchResults = result; // View ‚Å•\Ž¦‚·‚é‚½‚ß‚ÉŒ‹‰Ê‚ð•Û‘¶
            return View("Index");
        }
    }
}
