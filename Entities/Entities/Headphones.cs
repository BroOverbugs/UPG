namespace Domain.Entities;

public class Headphones : BaseEntity
{
    public string SoundType { get; set; } = string.Empty;
    // Stereo, Mono, Virtual surround sound
    public string OperatingMode { get; set; } = string.Empty;
    // [ 2.4GHz ] , [ 2.4GHz Bluetooth ], [ 2.4GHz Bluetooth 5.0 Wired]
    public string HeadPhonesType { get; set; } = string.Empty;
    // FullSize, Gags
}
