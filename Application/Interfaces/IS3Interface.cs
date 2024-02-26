using Microsoft.AspNetCore.Http;
namespace Application.Interfaces;

public interface IS3Interface
{
    public Task<List<string>> MultiUploadImage(List<IFormFile> files);
    public Task<string> UploadFileAsync(IFormFile file);
    public Task<Stream> GetFileUrlAsync(string fileName);
    public Task DeleteFileAsync(string fileName);
}