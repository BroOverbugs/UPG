using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Mouse_pads;

public class UpdateMouse_padsDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BrandName { get; set; } = "";
    public string Material { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
}
