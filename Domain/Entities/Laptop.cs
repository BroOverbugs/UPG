using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Laptop : BaseEntity
{
    [Required]
    public string Processor {  get; set; } = string.Empty;
    [Required]
    public string RAM { get; set; } = string.Empty;
    [Required]
    public string Storage { get; set; } = string.Empty;
    [Required]
    public string Video_card { get; set; } = string.Empty;
    [Required]
    public string Screen { get; set; } = string.Empty;
    public string Extra { get; set; } = string.Empty;
    [Required]
    public string Wi_Fi { get; set; } = string.Empty;
    [Required]
    public string RTX_or_AMD { get; set; } = string.Empty;

}
