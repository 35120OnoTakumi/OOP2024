// 修正版: Models/SearchResultsViewModel.cs
namespace TravelApp.Models {
    public class SearchResultsViewModel {
        public List<TravelSpot> Results { get; set; } = new List<TravelSpot>();
        public string? SearchQuery { get; set; }

        // コンストラクタで初期化
        public SearchResultsViewModel() {
            Results = new List<TravelSpot>();
        }
    }
}
