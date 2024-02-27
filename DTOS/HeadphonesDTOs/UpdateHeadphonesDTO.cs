using System.ComponentModel.DataAnnotations;

namespace DTOS.HeadphonesDTOs;

public class UpdateHeadphonesDTO : AddHeadphonesDTO
{
    public int ID { get; set; }
}
