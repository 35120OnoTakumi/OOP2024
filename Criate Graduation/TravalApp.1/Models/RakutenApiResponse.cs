using System.Collections.Generic;

namespace TravalApp1.Models {
    public class RakutenApiResponse {
        public List<HotelBasicInfo> Hotels { get; set; } = new List<HotelBasicInfo>();
    }

    public class HotelBasicInfo {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string HotelImageUrl { get; set; } = string.Empty;
        public string HotelInformationUrl { get; set; } = string.Empty;
    }
}
