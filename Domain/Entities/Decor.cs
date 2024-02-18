using Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Decor : BaseEntity
{
    [Required]
    public string Description { get; set; } = string.Empty;
}
