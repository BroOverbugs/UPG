using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class BaseEntity
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public string BrendName { get; set; } = string.Empty;
}
