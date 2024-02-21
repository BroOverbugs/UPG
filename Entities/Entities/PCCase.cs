using System.Drawing;

namespace Domain.Entities;

public class PCCase : BaseEntity
{
    public string MaximumCoolerHeight { get; set; } = string.Empty;
    public string MaximumVideoCardLength { get; set; } = string.Empty;
    public string StandardSize { get; set; } = string.Empty;
    public string PossibilityOfInstallingLiquidCooling { get; set; } = string.Empty;
    public string CaseColor { get; set; } = string.Empty;
}
