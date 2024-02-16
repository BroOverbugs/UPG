namespace Domain.Entities;

public class Mouse : BaseEntity
{
    public string PollingFrequency { get; set; } = string.Empty;
    // 1000 Hz, 4000Hz .......
    public int NumberOfButtons { get; set; }
    // 3, 4, 5 .....
    public int MaximumDPI { get; set; }
    // 26000 | 1000
    public string Acceleration { get; set; } = string.Empty;
    // 8G, 20G ....
    public string SensorType { get; set; } = string.Empty;
    // Optic, Optical Avago ...........
    public string OperatingMode { get; set; } = string.Empty;
    // [ 2.4GHz ] , [ 2.4GHz Bluetooth ], [ 2.4GHz Bluetooth 5.0 Wired] ....
}
