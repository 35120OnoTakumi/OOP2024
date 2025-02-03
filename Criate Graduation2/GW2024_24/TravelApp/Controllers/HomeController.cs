using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Controllers {
    public class HomeController : Controller {
        private readonly RakutenTravelApiClient _apiClient;

        public HomeController(RakutenTravelApiClient apiClient) {
            _apiClient = apiClient;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword) {
            if (string.IsNullOrWhiteSpace(keyword)) {
                return View("Index", null);
            }

            var result = await _apiClient.SearchHotelsAsync(keyword);

            if (result == null || result.Hotels.Count == 0) {
                ViewBag.Message = "åüçıåãâ Ç™Ç†ÇËÇ‹ÇπÇÒÇ≈ÇµÇΩÅB";
                return View("Index", null);
            }

            return View("Index", result);
        }
    }
}
