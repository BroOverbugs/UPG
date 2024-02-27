namespace DTOS.MonitorDTOs
{
    public class UpdateMonitorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = "";
        public string Diagonal { get; set; } = string.Empty;
        public string Screen_type { get; set; } = string.Empty;
        public string Matrix_type { get; set; } = string.Empty;
        public string Resolution_FHD { get; set; } = string.Empty;
        public string Aspect_ratio { get; set; } = string.Empty;
        public string Frame_rate { get; set; } = string.Empty;
        public string Response_time { get; set; } = string.Empty;
        public string Viewing_angle { get; set; } = string.Empty;
        public string Interface { get; set; } = string.Empty;
        public string VESA_Mount { get; set; } = string.Empty;
        public string Technologies { get; set; } = string.Empty;
        public string Adjustment { get; set; } = string.Empty;
        public string HDR { get; set; } = string.Empty;
        public string Guarantee_period { get; set; } = string.Empty;
    }
}
