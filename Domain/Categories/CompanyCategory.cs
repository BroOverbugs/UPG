using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories;

public class CompanyCategory
{
    [Key]
    public int CompanyID { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}
