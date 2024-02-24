using System.ComponentModel.DataAnnotations;

namespace DTOS.DrivesDTOs;

public class UpdateDriverDTO : AddDriverDTO
{
    public int ID { get; set; }
}
