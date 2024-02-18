using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Web_cameras_Category
{
    public int ID { get; set; }
    public List<Web_cameras> Accessories { get; set; } = new List<Web_cameras>();
}
