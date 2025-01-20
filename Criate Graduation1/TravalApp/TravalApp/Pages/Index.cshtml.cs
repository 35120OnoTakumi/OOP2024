using Microsoft.AspNetCore.Mvc.RazorPages;
using TravalApp.Models;

namespace TravalApp.Pages {
    public class IndexModel : PageModel {
        // プロパティとして SearchViewModel を公開
        public SearchViewModel SearchViewModel { get; set; } = new SearchViewModel();

        public void OnGet() {
            // 初期化が必要ならここで行う
            SearchViewModel = new SearchViewModel {
                Location = string.Empty,
                ErrorMessage = string.Empty
            };
        }

        public void OnPost(string location) {
            if (string.IsNullOrWhiteSpace(location)) {
                SearchViewModel.ErrorMessage = "Location cannot be empty.";
                return;
            }

            // 必要な処理 (例: 検索結果の取得など)
            // 今回はデモとしてエラーメッセージのみ
            SearchViewModel.Location = location;
            SearchViewModel.ErrorMessage = $"Search for '{location}' is not yet implemented.";
        }
    }
}
