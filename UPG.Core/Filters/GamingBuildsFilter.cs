namespace UPG.Core.Filters;

public record GamingBuildsFilter(
    string? Case,
    string? CPU,
    string? GPU,
    string? RAM,
    string? SSD,
    string? HDD,
    string? PSU,
    string? motherBoard,
    string? brand,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1
    );
