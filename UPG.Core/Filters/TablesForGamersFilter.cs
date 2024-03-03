namespace UPG.Core.Filters;

public record TablesForGamersFilter
(
    string? maxLoadUp,
    string? weight,
    string? dimensions,
    string? tableAdjustment,
    bool? backlight,
    string? brand,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1);
