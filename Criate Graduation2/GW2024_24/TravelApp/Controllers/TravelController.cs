using Microsoft.AspNetCore.Mvc;
using TravelApp.Models;
using System.Collections.Generic;

namespace TravelApp.Controllers {
    public class TravelController : Controller {
        public IActionResult Index() {
            // サンプルデータを作成
            var hotels = new List<RakutenTravelResponse>
            {
                new RakutenTravelResponse
                {
                    HotelName = "Sample Hotel",
                    Address = "123 Sample St",
                    Price = 10000,
                    ImageUrl = "https://via.placeholder.com/150",
                    Description = "A sample description for Sample Hotel."
                },
                new RakutenTravelResponse
                {
                    HotelName = "Example Inn",
                    Address = "456 Example Rd",
                    Price = 8000,
                    ImageUrl = "https://via.placeholder.com/150",
                    Description = "A sample description for Example Inn."
                }
            };

            // モデルにデータを設定
            var model = new SearchResultsViewModel {
                Hotels = hotels
            };

            return View(model);
        }
    }
}
