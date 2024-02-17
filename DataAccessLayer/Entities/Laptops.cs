using DataAccessLayer.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class Laptops
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string CPU {  get; set; }
    public string RAM { get; set; }
    public string Storage {  get; set; }
    public string GPU { get; set; }
    public string Display {  get; set; }
    public string? Other { get; set; }
    public string WiFi { get; set; }
    public string RTXorAMD { get; set; }
    public CompanyCategory Company_Category { get; set; }
}
