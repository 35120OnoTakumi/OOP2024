// ファイル: Models/RakutenTravelResponse.cs
// 目的: 楽天トラベルAPIのレスポンスデータを格納するモデル。
namespace TravelApp.Models {
    public class RakutenTravelResponse {
        public List<TravelSpot>? TravelSpots { get; set; }
    }
}
