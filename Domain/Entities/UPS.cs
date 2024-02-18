using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UPS : BaseEntity
{
    [Required]
    public string Description { get; set; } = string.Empty;
}
