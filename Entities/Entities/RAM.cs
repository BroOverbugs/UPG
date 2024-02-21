namespace Domain.Entities;

public class RAM : BaseEntity
{
    public string Capacity { get; set; } = string.Empty;
    //  16GB ( 1 X 16GB )
    public string BackLight { get; set; } = string.Empty;
    // EAT
    public string MemoryFrequency { get; set; } = string.Empty;
    // 3200 MHZ
    public string Timing { get; set; } = string.Empty;
    // 16-18-18
    public string RamTechnology { get; set; } = string.Empty;
    // DDR5
}
