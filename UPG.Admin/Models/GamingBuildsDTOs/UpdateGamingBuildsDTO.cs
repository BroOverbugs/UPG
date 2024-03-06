using System.ComponentModel.DataAnnotations;

namespace UPG.Admin.Models.GamingBuildsDTOs;

public class UpdateGamingBuildsDTO : AddGamingBuildsDTO
{
    public int ID { get; set; }
}
