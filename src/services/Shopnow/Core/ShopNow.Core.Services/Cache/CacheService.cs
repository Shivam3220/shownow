using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using ShopNow.Core.Contracts.Interfaces;
using ShopNow.Core.Contracts.Results;
using static ShopNow.Core.Services.Cache.CacheErrorCodes;

namespace ShopNow.Core.Services.Cache
{
    public class CacheService : ICacheService
    {
        private ILoggerService<CacheService> _logger;

        private IDistributedCache _distributedCache;
        public CacheService(IDistributedCache distributedCache, ILoggerService<CacheService> logger)
        {
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public Result<T> GetCachedObject<T>(string cacheKey) where T : class
        {
            return GetCachedObjectAsync<T>(cacheKey).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<Result<T>> GetCachedObjectAsync<T>(string cacheKey) where T : class
        {
            try
            {
                string? cacheValue = await _distributedCache.GetStringAsync(cacheKey);

                if (cacheValue is null)
                {
                    return Result.NotFound<T>(CACHED_OBJECT_NOT_FOUND);
                }

                return Result.Ok(JsonSerializer.Deserialize<T>(cacheValue)!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get cached object failed at cache service");
                return Result.Failure<T>(CACHE_SERVICE_INTERNAL_ERROR);
            }
        }

        public Result RemoveCachedObject(string cacheKey)
        {
            return RemoveCachedObjectAsync(cacheKey).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<Result> RemoveCachedObjectAsync(string cacheKey)
        {
            try
            {
                await _distributedCache.RemoveAsync(cacheKey);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get cached object failed at cache service");
                return Result.Failure(CACHE_SERVICE_INTERNAL_ERROR);
            }
        }

        public Result SetCacheObject<T>(T cacheObject, string cacheKey) where T : class
        {
            return SetCacheObjectAsync(cacheObject, cacheKey).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public Result SetCacheObject<T>(T cacheObject, string cacheKey, int minutes) where T : class
        {
            return SetCacheObjectAsync(cacheObject, cacheKey, minutes).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<Result> SetCacheObjectAsync<T>(T cacheObject, string cacheKey) where T : class
        {
            try
            {
                string serializedValue = JsonSerializer.Serialize(cacheObject);
                await _distributedCache.SetStringAsync(key: cacheKey, value: serializedValue);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Set cache object failed at cache service");
                return Result.Failure(CACHE_SERVICE_INTERNAL_ERROR);
            }
        }

        public async Task<Result> SetCacheObjectAsync<T>(T cacheObject, string cacheKey, int minutes) where T : class
        {
            try
            {
                string serializedValue = JsonSerializer.Serialize(cacheObject);
                DistributedCacheEntryOptions options = new()
                {
                    AbsoluteExpirationRelativeToNow = new TimeSpan(0, minutes, 0)
                };
                await _distributedCache.SetStringAsync(key: cacheKey, value: serializedValue, options: options);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Set cache object failed at cache service");
                return Result.Failure(CACHE_SERVICE_INTERNAL_ERROR);
            }
        }
    }
}