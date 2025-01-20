public class HotelResponse {
    public PagingInfo? PagingInfo { get; set; }
    public List<Hotel>? Hotels { get; set; }

    public HotelResponse() {
        PagingInfo = new PagingInfo();
        Hotels = new List<Hotel>();
    }
}

public class PagingInfo {
    public int RecordCount { get; set; }
    public int PageCount { get; set; }
    public int Page { get; set; }
    public int First { get; set; }
    public int Last { get; set; }
}

public class Hotel {
    public HotelBasicInfo? HotelBasicInfo { get; set; }
}

public class HotelBasicInfo {
    public string? HotelName { get; set; }
    public string? Address { get; set; }
    public string? TelephoneNo { get; set; }
    public string? HotelInformationUrl { get; set; }
}
