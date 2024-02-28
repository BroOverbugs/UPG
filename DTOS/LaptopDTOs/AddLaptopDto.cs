using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DTOS.LaptopDTOs
{
    public class AddLaptopDto
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = "";
        public string Processor { get; set; } = string.Empty;
        public string RAM { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public string Video_card { get; set; } = string.Empty;
        public string Screen { get; set; } = string.Empty;
        public string Extra { get; set; } = string.Empty;
        public string Wi_Fi { get; set; } = string.Empty;
        public string RTX_or_AMD { get; set; } = string.Empty;
        public List<string> ImageUrls { get; set; } = new();

        public static implicit operator Laptop(AddLaptopDto laptopDto)
            => new()
            {
                Name = laptopDto.Name,
                Price = laptopDto.Price,
                Description = laptopDto.Description,
                BrandName = laptopDto.BrandName,
                Processor = laptopDto.Processor,
                RAM = laptopDto.RAM,
                Storage = laptopDto.Storage,
                Video_card = laptopDto.Video_card,
                Screen = laptopDto.Screen,
                Extra = laptopDto.Extra,
                Wi_Fi = laptopDto.Wi_Fi,
                RTX_or_AMD = laptopDto.RTX_or_AMD,
                ImageUrls = laptopDto.ImageUrls
            };
    }
}