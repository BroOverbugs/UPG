using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers;

public record FilterParameters
(
    int pageSize,
    int pageNumber,
    string? title,
    double? minPrice,
    double? maxPrice,
    bool orderByTitle = true)
{
    public string Title = title ?? string.Empty;
    public double MinPrice = minPrice ?? 0;
    public double MaxPrice = maxPrice ?? double.MaxValue;
    public bool OrderByTitle = orderByTitle;
    public int PageNumber = pageNumber;
    public int PageSize = pageSize;
}