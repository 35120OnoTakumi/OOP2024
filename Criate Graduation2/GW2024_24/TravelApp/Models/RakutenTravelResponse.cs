namespace TravelApp.Models {
    public class RakutenTravelResponse {
        public string HotelName { get; set; } = string.Empty; // ホテル名
        public string Address { get; set; } = string.Empty; // 住所
        public int Price { get; set; } = 0; // 価格
        public string ImageUrl { get; set; } = string.Empty; // ホテル画像のURL
        public string Description { get; set; } = string.Empty; // 説明
    }
}
