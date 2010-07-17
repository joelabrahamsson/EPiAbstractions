using System;
using System.Web.Caching;

namespace EPiAbstractions
{
    public interface ICacheManagerFacade
    {
        void Clear();

        void Remove(String key);

        void RemoveLocalOnly(String key);

        void RemoveRemoteOnly(String key);

        void Add(String key, Object item);

        void Add(String key, Object item, CacheItemPriority priority);

        Object Get(String key);

        void RuntimeCacheInsert(String key, Object value);

        void RuntimeCacheInsert(String key, Object value, CacheDependency dependencies);

        void RuntimeCacheInsert(String key, Object value, CacheDependency dependencies, DateTime absoluteExpiration,
                                TimeSpan slidingExpiration);

        void RuntimeCacheInsert(String key, Object value, CacheDependency dependencies, DateTime absoluteExpiration,
                                TimeSpan slidingExpiration, CacheItemPriority priority);

        Object RuntimeCacheAdd(String key, Object value);

        Object RuntimeCacheAdd(String key, Object value, CacheDependency dependencies);

        Object RuntimeCacheAdd(String key, Object value, CacheDependency dependencies, DateTime absoluteExpiration,
                               TimeSpan slidingExpiration);

        Object RuntimeCacheAdd(String key, Object value, CacheDependency dependencies, DateTime absoluteExpiration,
                               TimeSpan slidingExpiration, CacheItemPriority priority);

        void RuntimeCacheRemove(String key);

        Object RuntimeCacheGet(String key);
    }
}