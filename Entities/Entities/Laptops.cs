namespace Domain.Entities;

public class Laptops : BaseEntity
{
    public string CPU { get; set; } = string.Empty;
    // Intel, AMD .....
    public string Storage { get; set; } = string.Empty;
    //  1 TB  M.2 NVMe PCIe 4.0
    public string RAM { get; set; } = string.Empty;
    // DDR4 , DDR5 .....
    public string VideoCard { get; set; } = string.Empty;
    // GTX, RTX .....
    public string ScreenSize { get; set; } = string.Empty;
    // 15.6 , 16 ......
    public string WiFi { get; set; } = string.Empty;
    // Wifi 6E ............
 }
