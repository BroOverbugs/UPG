namespace UPG.Core.Filters;

public record AccessoriesFilter(
    string? brand,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1);