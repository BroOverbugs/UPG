using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Headphones_Category
{
    public int ID { get; set; }
    public List<Headphones> Accessories { get; set; } = new List<Headphones>();
}
