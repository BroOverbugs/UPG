namespace UPG.Core.Filters;

public record HeadphonesFilter(
    string? sount_type,
    string? operating_mode,
    string? headphone_type,
    string? brand,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1
    );
