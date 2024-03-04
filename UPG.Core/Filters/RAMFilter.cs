namespace UPG.Core.Filters;

public record RAMFilter
(
    string? brand,
    string? capacity,
    string? technologies,
    string? timings,
    bool? backlight,
    string? memoryFrequency,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1
);
