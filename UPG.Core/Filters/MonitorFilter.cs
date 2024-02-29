namespace UPG.Core.Filters;

public record MonitorFilter(
    string? brand,
    string? screenType,
    string? matrixType,
    bool? HDR,
    string? adjustment,
    string? VESAMount,
    string? frameRate,
    string? aspectRatio,
    string? diagonal,
    bool? Guarantee_period,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1);