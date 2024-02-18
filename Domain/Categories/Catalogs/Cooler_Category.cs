using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Categories.Catalogs;

public class Cooler_Category
{
    public int ID { get; set; }
    public List<Accessories> Accessories { get; set; } = new List<Accessories>();
}
