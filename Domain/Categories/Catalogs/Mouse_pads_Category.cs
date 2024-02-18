using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Mouse_pads_Category
{
    public int ID { get; set; }
    public List<Mouse_pads> Accessories { get; set; } = new List<Mouse_pads>();
}
