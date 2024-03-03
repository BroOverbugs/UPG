using Domain.Entities;
using DTOS.MonitorDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Mouse_pads;

public class MousePadsDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Material { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
    public static implicit operator MousePadsDTO(MousePads mousePads)
            => new()
            {
                ID = mousePads.Id,
                Name = mousePads.Name,
                Price = mousePads.Price,
                Description = mousePads.Description,
                BrandName = mousePads.BrandName,
                Dimensions = mousePads.Dimensions,
                Material = mousePads.Material,
                ImageUrls = mousePads.ImageUrls
            };
}
