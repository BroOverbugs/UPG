using System.Globalization;

namespace Domain.Entities;

public class GamingTable : BaseEntity
{
    public string Weight { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string Backlight { get; set; } = string.Empty;
    public string TableAdjustment { get; set; } = string.Empty;
    public string MaxLoad { get; set; } = string.Empty;
}
