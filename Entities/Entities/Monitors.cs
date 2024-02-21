namespace Domain.Entities;

public class Monitors : BaseEntity
{
    public string Permisson { get; set; } = string.Empty;
    // FHD, QuadHD, UHD
    public string MatrixType { get; set; } = string.Empty;
    // IPS, TN
    public string HDR { get; set; } = string.Empty;
    // Eat
    public string Adjustment { get; set; } = string.Empty;
    // Verticle Tilte,  Height Adjusment
    public string VESA_Mount { get; set; } = string.Empty;
    // 100mm X 100mm
    public string FrameRate { get; set; } = string.Empty;
    // 144 Hz
    public string AspectRatio { get; set; } = string.Empty;
    //  16 : 9
    public string ScreenType { get; set; } = string.Empty;
    // Curved, Flat
    public string Dioganal { get; set; } = string.Empty;
    // 23.8 , 24
    public string G_Sync { get; set; } = string.Empty;
    // Eat
}
