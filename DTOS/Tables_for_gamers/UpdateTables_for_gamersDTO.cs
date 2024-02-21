using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Tables_for_gamers;

public class UpdateTables_for_gamersDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string I_or_O_panel { get; set; } = string.Empty;
    public string Table_adjustment { get; set; } = string.Empty;
    public string Max_load_up { get; set; } = string.Empty;
    public string Backlight { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
}
