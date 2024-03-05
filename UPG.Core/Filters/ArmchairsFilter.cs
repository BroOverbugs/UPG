namespace UPG.Core.Filters;

public record ArmchairsFilter(
    string? type,
    string? upholstery_material,
    string? color_material,
    string? armsets,
    string? cross_material,
    string? reclining,
    string? rocking_mechanism,
    string? permissible_load,
    string? brand,
    double? minPrice,
    double? maxPrice,
    int pageSize = 10,
    int pageNumber = 1
    );
