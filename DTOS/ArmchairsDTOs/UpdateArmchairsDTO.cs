namespace DTOS.ArmchairsDTOs;

public class UpdateArmchairsDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Type { get; set; } = string.Empty;
    public string Upholstery_material { get; set; } = string.Empty; //koja yoki boshqa narsalar
    public string Color_material { get; set; } = string.Empty;
    public string Armrests { get; set; } = string.Empty; // 4d,3d
    public string Cross_material { get; set; } = string.Empty;
    public string Reclining { get; set; } = string.Empty;
    public string Rocking_mechanism { get; set; } = string.Empty;
    public string Permissible_load { get; set; } = string.Empty;//(kg)
    public string Frame_material { get; set; } = string.Empty;
}
