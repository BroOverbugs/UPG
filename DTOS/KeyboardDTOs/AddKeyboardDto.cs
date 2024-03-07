using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DTOS.KeyboardDTOs
{
    public class AddKeyboardDto
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = "";
        public string Keyboard_type { get; set; } = string.Empty;
        public string Switch_type { get; set; } = string.Empty;
        public string Interface { get; set; } = string.Empty;
        public string Backlight { get; set; } = string.Empty;
        public string Internal_memory { get; set; } = string.Empty;
        public bool Palm_rest { get; set; }
        public bool Cable_laying { get; set; }
        public int Number_of_keys { get; set; }
        public string Dimensions { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public List<string> ImageUrls { get; set; } = new();


        public static implicit operator Keyboard(AddKeyboardDto keyboardDto)
            => new()
            {
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
