using System.Security.Principal;

namespace Domain.Entities;

public class Drives : BaseEntity
{
    public string Interface { get; set; } = string.Empty;
    // USB, PSI .....
    public string ReadingSpeed { get; set; } = string.Empty;
    // 1050MB/s
    public string WriteSpeed { get; set; } = string.Empty;
    // 1000MB/s
    public string Volume { get; set; } = string.Empty;
    // 1TB, 2TB
    public string DriveType { get; set; } = string.Empty;
    // SSD, External SSD
}
