using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Laptops_Category
{
    public int ID { get; set; }
    public List<Laptops> Accessories { get; set; } = new List<Laptops>();
}
