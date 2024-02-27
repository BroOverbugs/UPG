using Amazon.S3;
using Amazon.S3.Model;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TinifyAPI;

namespace Application.Services;

public class S3Service(IAmazonS3 s3Client,
    IConfiguration configuration)
    : IS3Interface
{
    private readonly IAmazonS3 s3Client = s3Client;
    private readonly IConfiguration _configuration = configuration;
    private const string bucketName = "my-book-images1";

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        using var fileStream = file.OpenReadStream();
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var fileKey = bucketName + "/" + fileName;

        var fileBytes = new byte[fileStream.Length];
        fileStream.Read(fileBytes, 0, fileBytes.Length);

        _ = Task.Run(async () =>
        {
            Tinify.Key = _configuration["TinifyApiKey"];
            var compressedData = await Tinify.FromBuffer(fileBytes).ToBuffer();

            var putObjectRequest = new PutObjectRequest
            {
                InputStream = new MemoryStream(compressedData),
                BucketName = bucketName,
                Key = fileName
            };

            await s3Client.PutObjectAsync(putObjectRequest);
        });

        return fileName;
    }

    public async Task<Stream> GetFileUrlAsync(string fileName)
    {
        var urlRequest = new GetPreSignedUrlRequest
        {
            BucketName = bucketName,
            Key = fileName,
            Expires = DateTime.Now.AddMinutes(5)
        };

        var fileUrl = s3Client.GetPreSignedURL(urlRequest);
        HttpClient httpClient = new();

        var response = await httpClient.GetAsync(fileUrl);

        if (!response.IsSuccessStatusCode)
        {
            throw new ArgumentNullException("File not found");
        }

        return response.Content.ReadAsStream();
    }

    public async Task DeleteFileAsync(string fileName)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = bucketName,
            Key = fileName
        };

        await s3Client.DeleteObjectAsync(deleteObjectRequest);
    }

    public async Task<List<string>> MultiUploadImage(List<IFormFile> files)
    {
        var fileNames = new List<string>();
        foreach (var file in files)
        {
            var filename = await UploadFileAsync(file);
            fileNames.Add(filename);
        }

        return fileNames;
    }
}