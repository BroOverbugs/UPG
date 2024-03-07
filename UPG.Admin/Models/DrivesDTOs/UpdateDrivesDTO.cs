using System.ComponentModel.DataAnnotations;

namespace UPG.Admin.Models.DrivesDTOs;

public class UpdateDrivesDTO : AddDrivesDTO
{
    public int ID { get; set; }
}
