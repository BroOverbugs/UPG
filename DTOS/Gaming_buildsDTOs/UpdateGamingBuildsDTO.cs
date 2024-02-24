using System.ComponentModel.DataAnnotations;

namespace DTOS.Gaming_buildsDTOs;

public class UpdateGamingBuildsDTO : AddGamingBuildsDTO
{
    public int ID { get; set; }
}
