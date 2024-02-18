namespace Domain.Entities;

public class Cooler : BaseEntity
{
    public string PowerDissipation { get; set; } = string.Empty;
    public string CoolerType { get; set; } = string.Empty;
    public string RotationalSpeed { get; set; } = string.Empty;
    public string BearingType { get; set; } = string.Empty;
    public string DimensionsOfCompleteFans { get; set; } = string.Empty;
}
