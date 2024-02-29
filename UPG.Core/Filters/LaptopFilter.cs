namespace UPG.Core.Filters;

public record LaptopFilter(
    string? brand,
    string? processor,
    string? storage,
    string? RAM,
    string? videoCard,
    string? screen,
    string? WiFi,
    string? RTXAMD,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1);