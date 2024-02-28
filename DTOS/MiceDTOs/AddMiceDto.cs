using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DTOS.MiceDTOs
{
    public class AddMiceDto
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = "";
        public string Sensor_type { get; set; } = string.Empty;
        public string Maximum_resolution_DPI_or_CPI { get; set; } = string.Empty;
        public int Number_of_buttons { get; set; }
        public string Polling_rate { get; set; } = string.Empty;
        public string Acceleration_max_acceleration { get; set; } = string.Empty;
        public string Prism { get; set; } = string.Empty;
        public string Internal_memory { get; set; } = string.Empty;
        public string Operating_mode { get; set; } = string.Empty;
        public string Wire_type { get; set; } = string.Empty;
        public string Wire_length { get; set; } = string.Empty;
        public string Weight_with_cable { get; set; } = string.Empty;
        public string Weight_without_cable { get; set; } = string.Empty;
        public string Dimensions { get; set; } = string.Empty;
        public List<string> ImageUrls { get; set; } = new();

        public static implicit operator Mice(AddMiceDto miceDto)
            => new()
            {
                Name = miceDto.Name,
                Price = miceDto.Price,
                Description = miceDto.Description,
                BrandName = miceDto.BrandName,
                Sensor_type = miceDto.Sensor_type,
                Maximum_resolution_DPI_or_CPI = miceDto.Maximum_resolution_DPI_or_CPI,
                Number_of_buttons = miceDto.Number_of_buttons,
                Polling_rate = miceDto.Polling_rate,
                Acceleration_max_acceleration = miceDto.Acceleration_max_acceleration,
                Prism = miceDto.Prism,
                Internal_memory = miceDto.Internal_memory,
                Operating_mode = miceDto.Operating_mode,
                Wire_type = miceDto.Wire_type,
                Wire_length = miceDto.Wire_length,
                Weight_without_cable = miceDto.Weight_without_cable,
                Weight_with_cable = miceDto.Weight_with_cable,
                Dimensions = miceDto.Dimensions,
                ImageUrls = miceDto.ImageUrls
            };
    }
}