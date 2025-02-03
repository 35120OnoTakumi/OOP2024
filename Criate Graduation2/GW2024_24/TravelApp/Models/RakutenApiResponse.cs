using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TravelApp.Models {
    public class RakutenApiResponse {
        [JsonPropertyName("hotels")]
        public List<HotelWrapper> Hotels { get; set; } = new();
    }
}
