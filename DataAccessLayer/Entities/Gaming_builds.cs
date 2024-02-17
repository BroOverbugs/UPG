using DataAccessLayer.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class Gaming_builds
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Mother_board { get; set; }
    public string Cooler {  get; set; }
    public string? SSD { get; set; }
    public string? HDD { get; set; }
    public string GPU { get; set; }
    public string PSU { get; set; }
    public string Case { get; set; }
    public CompanyCategory CompanyCategory { get; set; }
    public CategoryCatalog CatalogCategory { get; set; }
}
