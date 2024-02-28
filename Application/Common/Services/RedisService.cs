using Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json;

namespace Application.Common.Services;

public class RedisService<T>(IDistributedCache distributed) : IRedisService<T> where T : class
{
    private readonly IDistributedCache _cache = distributed;

    public async Task<IEnumerable<T>?> GetFromCacheAsync(string key)
    {
        IEnumerable<T>? entities = null;
        var entitiesFromCache = await _cache.GetStringAsync(key);
        entities = (entitiesFromCache == null) ? null
            : JsonConvert.DeserializeObject<IEnumerable<T>>(entitiesFromCache);

        return entities;
    }

    public async Task RemoveFromCacheAsync(string key)
        => await _cache.RemoveAsync(key);

    public async Task SaveToCacheAsync(string content, string key)
    {
        await _cache.SetStringAsync(key, content, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        });
    }
}