namespace UPG.Core.Filters;

public record HousingFilter(
    string? brand,
    string? maximumCoolerHeight,
    string? videoCard,
    string? dimensions,
    string? PossibilityOfInstalling,
    string? color,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1);
