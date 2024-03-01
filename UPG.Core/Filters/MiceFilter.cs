namespace UPG.Core.Filters;

public record MiceFilter(
    string? brand,
    string? pollingRate,
    int? numberOfButtons,
    string? maximumResolutionDPIOrCPI,
    string? acceleration,
    string? sensorType,
    string? operatingMode,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1);
