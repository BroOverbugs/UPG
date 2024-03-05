namespace UPG.Core.Filters;

public record DrivesFilter(
    string? Interface,
    string? reading_speed,
    string? write_type,
    string? drive_type,
    string? volume,
    string? brand,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1
    );
