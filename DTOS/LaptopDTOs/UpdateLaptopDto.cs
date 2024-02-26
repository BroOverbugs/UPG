namespace DTOS.LaptopDTOs
{
    public class UpdateLaptopDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = "";
        public string Processor { get; set; } = string.Empty;
        public string RAM { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public string Video_card { get; set; } = string.Empty;
        public string Screen { get; set; } = string.Empty;
        public string Extra { get; set; } = string.Empty;
        public string Wi_Fi { get; set; } = string.Empty;
        public string RTX_or_AMD { get; set; } = string.Empty;
    }
}
