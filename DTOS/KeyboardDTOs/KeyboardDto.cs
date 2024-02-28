using Domain.Entities;

namespace DTOS.KeyboardDTOs
{
    public class KeyboardDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = "";
        public string Keyboard_type { get; set; } = string.Empty;
        public string Switch_type { get; set; } = string.Empty;
        public string Interface { get; set; } = string.Empty;
        public string Backlight { get; set; } = string.Empty;
        public string Internal_memory { get; set; } = string.Empty;
        public string Palm_rest { get; set; } = string.Empty;
        public string Cable_laying { get; set; } = string.Empty;
        public int Number_of_keys { get; set; }
        public string Dimensions { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public List<string> ImageUrls { get; set; } = new();

        public static implicit operator KeyboardDto(Keyboard keyboardDto)
            => new()
            {
                Id = keyboardDto.Id,
                Name = keyboardDto.Name,
                Price = keyboardDto.Price,
                Description = keyboardDto.Description,
                BrandName = keyboardDto.BrandName,
                Keyboard_type = keyboardDto.Keyboard_type,
                Switch_type = keyboardDto.Switch_type,
                Interface = keyboardDto.Interface,
                Backlight = keyboardDto.Backlight,
                Internal_memory = keyboardDto.Internal_memory,
                Palm_rest = keyboardDto.Palm_rest,
                Cable_laying = keyboardDto.Cable_laying,
                Number_of_keys = keyboardDto.Number_of_keys,
                Dimensions = keyboardDto.Dimensions,
                Weight = keyboardDto.Weight,
                ImageUrls = keyboardDto.ImageUrls
            };
    }
}
