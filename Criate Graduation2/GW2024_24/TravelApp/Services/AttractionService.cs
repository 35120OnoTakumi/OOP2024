namespace TravelApp.Services {
    public class AttractionService {
        public string GetAttractionInfo(int attractionId) {
            // Attraction ID を処理する場合、型変換が必要
            return $"Attraction ID: {attractionId}";
        }
    }
}
