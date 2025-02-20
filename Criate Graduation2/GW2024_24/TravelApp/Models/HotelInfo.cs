using System.Text.Json.Serialization;

namespace TravelApp.Models {
    public class HotelInfo {
        [JsonPropertyName("hotelName")]
        public string? HotelName { get; set; } = string.Empty;  // nullable型に変更

        [JsonPropertyName("hotelInformationUrl")]
        public string? HotelInformationUrl { get; set; } = string.Empty;  // nullable型に変更

        [JsonPropertyName("hotelThumbnailUrl")]
        public string? HotelThumbnailUrl { get; set; } = string.Empty;  // nullable型に変更

        // カッコ内の情報（別名や補足情報）
        public string? HotelSubname { get; set; } = string.Empty;  // nullable型に変更

        // お気に入りかどうかを示すプロパティ
        public bool IsFavorite { get; set; } = false;
    }
}
