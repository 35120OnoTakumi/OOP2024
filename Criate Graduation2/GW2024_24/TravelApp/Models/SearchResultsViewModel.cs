using System.Collections.Generic;

namespace TravelApp.Models {
    public class SearchResultsViewModel {
        public List<RakutenTravelResponse> Hotels { get; set; } = new List<RakutenTravelResponse>();
    }
}
