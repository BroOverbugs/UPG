namespace UPG.Core.Filters;

public record CoolerFilter(
    string? type,
    string? power_dissipation,
    string? rotational_speed,
    string? bearing_type,
    string? dimensions_of_complete_fans,
    string? brand,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1
);
