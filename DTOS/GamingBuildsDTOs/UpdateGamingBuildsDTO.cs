using System.ComponentModel.DataAnnotations;

namespace DTOS.GamingBuildsDTOs;

public class UpdateGamingBuildsDTO : AddGamingBuildsDTO
{
    public int ID { get; set; }
}
