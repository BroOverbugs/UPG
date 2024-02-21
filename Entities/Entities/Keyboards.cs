namespace Domain.Entities;

public class Keyboards : BaseEntity
{
    public string SwitchType { get; set; } = string.Empty;
    // Gateron, Cherry ....
    public string KeyboardType { get; set; } = string.Empty;
    // Mechanical, Membrane ...
    public string BackLight { get; set; } = string.Empty;
    // White, Blue, 16.8 million color ....
}
