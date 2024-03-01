namespace UPG.Core.Filters;

public record KeyboardFilter(
    string? brand,
    string? switchType,
    string? keyboardType,
    string? backlight,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1);
