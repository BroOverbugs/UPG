namespace DTOS.MonitorDTOs
{
    public class MonitorDto
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
        public List<string> ImageUrls { get; set; } = new();


        public static implicit operator MonitorDto(Domain.Entities.Monitor monitorDto)
            => new()
            {
                Id = monitorDto.Id,
                Name = monitorDto.Name,
                Price = monitorDto.Price,
                Description = monitorDto.Description,
                BrandName = monitorDto.BrandName,
                Diagonal = monitorDto.Diagonal,
                Screen_type = monitorDto.Screen_type,
                Matrix_type = monitorDto.Matrix_type,
                Resolution_FHD = monitorDto.Resolution_FHD,
                Aspect_ratio = monitorDto.Aspect_ratio,
                Frame_rate = monitorDto.Frame_rate,
                Response_time = monitorDto.Response_time,
                Viewing_angle = monitorDto.Viewing_angle,
                Interface = monitorDto.Interface,
                VESA_Mount = monitorDto.VESA_Mount,
                Technologies = monitorDto.Technologies,
                Adjustment = monitorDto.Adjustment,
                HDR = monitorDto.HDR,
                Guarantee_period = monitorDto.Guarantee_period,
                ImageUrls = monitorDto.ImageUrls
            };
    }
}
