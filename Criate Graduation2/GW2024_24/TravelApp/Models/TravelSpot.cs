// 修正版: Models/TravelSpot.cs
namespace TravelApp.Models {
    public class TravelSpot {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Keyword { get; set; } = string.Empty;
        public string AreaCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // コンストラクタでプロパティを初期化
        public TravelSpot(string name, string address, string keyword, string areaCode, string description) {
            Name = name;
            Address = address;
            Keyword = keyword;
            AreaCode = areaCode;
            Description = description;
        }
    }
}
