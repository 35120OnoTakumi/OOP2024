using System.Text.Json.Serialization;

namespace TravelApp.Models {
    public class HotelInfo {
        [JsonPropertyName("hotelName")]
        public string HotelName { get; set; }

        [JsonPropertyName("hotelInformationUrl")]
        public string HotelInformationUrl { get; set; }

        [JsonPropertyName("hotelThumbnailUrl")]
        public string HotelThumbnailUrl { get; set; }
    }
}
