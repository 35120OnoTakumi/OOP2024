using System.Text.Json.Serialization;

namespace TravelApp.Models {
    public class HotelContainer {
        [JsonPropertyName("hotelBasicInfo")]
        public HotelInfo BasicInfo { get; set; } = new();
    }
}
