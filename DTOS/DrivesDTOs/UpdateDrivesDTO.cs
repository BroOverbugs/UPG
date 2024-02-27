using System.ComponentModel.DataAnnotations;

namespace DTOS.DrivesDTOs;

public class UpdateDrivesDTO : AddDrivesDTO
{
    public int ID { get; set; }
}
