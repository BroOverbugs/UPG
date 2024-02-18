using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Power_supplies_Category
{
    public int ID { get; set; }
    public List<Power_supplies> Accessories { get; set; } = new List<Power_supplies>();
}
