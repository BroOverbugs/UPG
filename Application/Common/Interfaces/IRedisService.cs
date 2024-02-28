namespace Application.Common.Interfaces;

public interface IRedisService<T> where T : class
{
    Task SaveToCacheAsync(string content, string key);
    Task<IEnumerable<T>?> GetFromCacheAsync(string key);
    Task RemoveFromCacheAsync(string key);
}