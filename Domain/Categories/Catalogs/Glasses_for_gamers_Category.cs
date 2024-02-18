using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Glasses_for_gamers_Category
{
    public int ID { get; set; }
    public List<Glasses_for_gamers> Accessories { get; set; } = new List<Glasses_for_gamers>();
}
