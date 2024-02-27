namespace DTOS.AccessoriesDtos
{
    public class AccessoriesDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = "";
        public List<string> ImageUrls { get; set; } = new();
    }
}
