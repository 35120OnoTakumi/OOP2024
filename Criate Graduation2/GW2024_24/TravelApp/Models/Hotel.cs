using System.Text.Json.Serialization;

namespace TravelApp.Models {
    public class Hotel {
        [JsonPropertyName("hotelBasicInfo")]
        public HotelInfo HotelBasicInfo { get; set; } = new();
    }
}
