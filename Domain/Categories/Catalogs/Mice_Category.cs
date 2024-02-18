using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Mice_Category
{
    public int ID { get; set; }
    public List<Mice> Accessories { get; set; } = new List<Mice>();
}
