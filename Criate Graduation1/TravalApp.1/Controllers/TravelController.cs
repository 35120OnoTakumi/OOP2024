using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravalApp1.Models;
using TravalApp1.Services;

namespace TravalApp1.Controllers {
    public class TravelController : Controller {
        private readonly RakutenTravelService _rakutenTravelService;

        public TravelController(RakutenTravelService rakutenTravelService) {
            _rakutenTravelService = rakutenTravelService;
        }

        public async Task<IActionResult> Index(string areaCode) {
            var travelData = await _rakutenTravelService.GetTravelDataAsync(areaCode);
            return View(travelData);
        }
    }
}
