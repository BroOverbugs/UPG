using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Accessories : BaseEntity
{
    [Required,StringLength(10000)]
    public string Description { get; set; } = string.Empty;
}
