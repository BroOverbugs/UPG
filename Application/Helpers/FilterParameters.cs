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
    decimal? minPrice,
    decimal? maxPrice,
    bool orderByTitle = true)
{
    public string Title = title ?? string.Empty;
    public decimal MinPrice = minPrice ?? 0;
    public decimal MaxPrice = maxPrice ?? decimal.MaxValue;
    public bool OrderByTitle = orderByTitle;
    public int PageNumber = pageNumber;
    public int PageSize = pageSize;
}