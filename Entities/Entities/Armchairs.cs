namespace Domain.Entities;

public class Armchairs : BaseEntity
{
    public double Price { get; set; }
    public string TypeOfChair { get; set; } = string.Empty;
    public string MaterialOfChair { get; set; } = string.Empty;
    public string ColorOfChair { get; set; } = string.Empty;
    public string ArmRestsType { get; set; } = string.Empty;
    public string CrossMaterial { get; set; } = string.Empty;
    public int Reclining { get; set; }
    public string RockingMechanism { get; set; } = string.Empty;
    public int PermissibleLoad { get; set; }
}
