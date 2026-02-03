using ShopNow.Core.Contracts.Results;

namespace ShopNow.Core.Contracts.Interfaces
{
    public interface ICacheService
    {
        /// <summary>
        /// Returns the cached object.
        /// </summary>
        /// <typeparam name="T">Generic object that is of class</typeparam>
        /// <param name="cacheKey">Key of the object</param>
        Result<T> GetCachedObject<T>(string cacheKey) where T : class;

        /// <summary>
        /// Returns the cached object.
        /// </summary>
        /// <typeparam name="T">Generic object that is of class</typeparam>
        /// <param name="cacheKey">Key of the object</param>
        Task<Result<T>> GetCachedObjectAsync<T>(string cacheKey) where T : class;

        /// <summary>
        /// Remove cached object from the cache.
        /// </summary>
        /// <param name="cacheKey">Key of the object</param>
        Result RemoveCachedObject(string cacheKey);

        /// <summary>
        /// Remove cached object from the cache.
        /// </summary>
        /// <param name="cacheKey">Key of the object</param>
        Task<Result> RemoveCachedObjectAsync(string cacheKey);

        /// <summary>
        /// Set cached object to the cache for 15 minutes.
        /// </summary>
        /// <typeparam name="T">Generic object that is of class</typeparam>
        /// <param name="cacheObject">Object to be cached</param>
        /// <param name="cacheKey">Key of the object</param>
        Result SetCacheObject<T>(T cacheObject, string cacheKey) where T : class;

        /// <summary>
        /// Set cached object to the cache.
        /// </summary>
        /// <typeparam name="T">Generic object that is of class</typeparam>
        /// <param name="cacheObject">Object to be cached</param>
        /// <param name="cacheKey">Key of the object</param>
        /// <param name="minutes">Minutes to be saved in cache</param>
        Result SetCacheObject<T>(T cacheObject, string cacheKey, int minutes) where T : class;

        /// <summary>
        /// Set cached object to the cache for 15 minutes.
        /// </summary>
        /// <typeparam name="T">Generic object that is of class</typeparam>
        /// <param name="cacheObject">Object to be cached</param>
        /// <param name="cacheKey">Key of the object</param>
        Task<Result> SetCacheObjectAsync<T>(T cacheObject, string cacheKey) where T : class;

        /// <summary>
        /// Set cached object to the cache.
        /// </summary>
        /// <typeparam name="T">Generic object that is of class</typeparam>
        /// <param name="cacheObject">Object to be cached</param>
        /// <param name="cacheKey">Key of the object</param>
        /// <param name="minutes">Minutes to be saved in cache</param>
        Task<Result> SetCacheObjectAsync<T>(T cacheObject, string cacheKey, int minutes) where T : class;
    }
}