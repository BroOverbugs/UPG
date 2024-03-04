namespace UPG.Core.Filters;

public record MousePadsFilter
(
    string? material,
    string? dimensions,
    string? brand,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10, 
    int pageNumber = 1
);
