using System;
using System.Web.Caching;
using EPiServer;

namespace EPiAbstractions
{
    public class CacheManagerFacade : ICacheManagerFacade
    {
        private static CacheManagerFacade _instance;

        public static CacheManagerFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CacheManagerFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region ICacheManagerFacade Members

        public virtual void Clear()
        {
            CacheManager.Clear();
        }

        public virtual void Remove(String key)
        {
            CacheManager.Remove(key);
        }

        public virtual void RemoveLocalOnly(String key)
        {
            CacheManager.RemoveLocalOnly(key);
        }

        public virtual void RemoveRemoteOnly(String key)
        {
            CacheManager.RemoveRemoteOnly(key);
        }

        public virtual void Add(String key, Object item)
        {
            CacheManager.Add(key, item);
        }

        public virtual void Add(String key, Object item, CacheItemPriority priority)
        {
            CacheManager.Add(key, item, priority);
        }

        public virtual Object Get(String key)
        {
            return CacheManager.Get(key);
        }

        public virtual void RuntimeCacheInsert(String key, Object value)
        {
            CacheManager.RuntimeCacheInsert(key, value);
        }

        public virtual void RuntimeCacheInsert(String key, Object value, CacheDependency dependencies)
        {
            CacheManager.RuntimeCacheInsert(key, value, dependencies);
        }

        public virtual void RuntimeCacheInsert(String key, Object value, CacheDependency dependencies, DateTime absoluteExpiration,
                                               TimeSpan slidingExpiration)
        {
            CacheManager.RuntimeCacheInsert(key, value, dependencies, absoluteExpiration, slidingExpiration);
        }

        public virtual void RuntimeCacheInsert(String key, Object value, CacheDependency dependencies, DateTime absoluteExpiration,
                                               TimeSpan slidingExpiration, CacheItemPriority priority)
        {
            CacheManager.RuntimeCacheInsert(key, value, dependencies, absoluteExpiration, slidingExpiration, priority);
        }

        public virtual Object RuntimeCacheAdd(String key, Object value)
        {
            return CacheManager.RuntimeCacheAdd(key, value);
        }

        public virtual Object RuntimeCacheAdd(String key, Object value, CacheDependency dependencies)
        {
            return CacheManager.RuntimeCacheAdd(key, value, dependencies);
        }

        public virtual Object RuntimeCacheAdd(String key, Object value, CacheDependency dependencies, DateTime absoluteExpiration,
                                              TimeSpan slidingExpiration)
        {
            return CacheManager.RuntimeCacheAdd(key, value, dependencies, absoluteExpiration, slidingExpiration);
        }

        public virtual Object RuntimeCacheAdd(String key, Object value, CacheDependency dependencies, DateTime absoluteExpiration,
                                              TimeSpan slidingExpiration, CacheItemPriority priority)
        {
            return CacheManager.RuntimeCacheAdd(key, value, dependencies, absoluteExpiration, slidingExpiration, priority);
        }

        public virtual void RuntimeCacheRemove(String key)
        {
            CacheManager.RuntimeCacheRemove(key);
        }

        public virtual Object RuntimeCacheGet(String key)
        {
            return CacheManager.RuntimeCacheGet(key);
        }

        #endregion
    }
}