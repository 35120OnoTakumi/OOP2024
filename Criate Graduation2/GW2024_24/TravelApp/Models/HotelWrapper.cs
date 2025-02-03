using System.Text.Json.Serialization;

namespace TravelApp.Models {
    public class HotelWrapper {
        [JsonPropertyName("hotel")]
        public HotelContainer Hotel { get; set; } = new();
    }
}
