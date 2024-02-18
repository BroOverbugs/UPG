using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Tables_for_gamers_Category
{
    public int ID { get; set; }
    public List<Tables_for_gamers> Accessories { get; set; } = new List<Tables_for_gamers>();
}
