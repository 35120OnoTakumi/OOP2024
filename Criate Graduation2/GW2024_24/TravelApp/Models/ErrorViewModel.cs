// ファイル: Models/ErrorViewModel.cs
// 目的: エラー情報を表示するためのモデルクラス。
namespace TravelApp.Models {
    public class ErrorViewModel {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
