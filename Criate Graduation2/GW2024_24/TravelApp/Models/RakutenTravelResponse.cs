// RakutenTravelResponse.cs
namespace TravelApp.Models {
    /// <summary>
    /// 楽天トラベルのAPIからのレスポンスデータを格納するモデルクラス。
    /// ホテルと観光地の両方を統一的に扱う。
    /// </summary>
    public class RakutenTravelResponse {
        public string Name { get; set; } // 名前（ホテル名や観光地名）
        public string Address { get; set; } // 住所
        public string ImageUrl { get; set; } // 画像URL
        public string Description { get; set; } // 説明
        public double Rating { get; set; } // 評価
    }
}