using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Wi_Fi_routers_Category
{
    public int ID { get; set; }
    public List<Wi_Fi_routers> Accessories { get; set; } = new List<Wi_Fi_routers>();
}
