using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Microphones_Category
{
    public int ID { get; set; }
    public List<Microphones> Accessories { get; set; } = new List<Microphones>();
}
