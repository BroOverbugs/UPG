namespace Domain.Entities;

public class Armchairs : BaseEntity
{
    public string TypeOfChair { get; set; } = string.Empty;
    // Gaming, Office
    public string MaterialOfChair { get; set; } = string.Empty;
    // Textile, ECO
    public string ColorOfChair { get; set; } = string.Empty;
    // Black, White, Red
    public string ArmRestsType { get; set; } = string.Empty;
    // 1D, 2D, 3D
    public string CrossMaterial { get; set; } = string.Empty;
    // Metal, Plastic
    public int Reclining { get; set; }
    // Up To 135/160/180*
    public string RockingMechanism { get; set; } = string.Empty;
    // Tilt, Butterfly
    public int PermissibleLoad { get; set; }
    // Up to 100/120 .... KG
}
