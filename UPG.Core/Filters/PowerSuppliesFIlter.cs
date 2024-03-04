namespace UPG.Core.Filters;

public record PowerSuppliesFIlter
(
    string? securityTechnologies,
    string? certificate,
    string? power,
    string? dimensions,
    string? formFactor,
    string? brand,
    double? minPrice,
    double? maxPrice, 
    int pageSize = 10,
    int pageNumber = 1
);
