using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories.Catalogs;

public class Capture_cards_Category
{
    public int ID { get; set; }
    public List<Accessories> Accessories { get; set; } = new List<Accessories>();
}
