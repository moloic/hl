using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Hl.dotNet.CacheBase
{
    /// <summary>
    /// 缓存类
    /// </summary>
    public class CacheHelper
    {

        /// <summary>  
        /// 获取数据缓存  
        /// </summary>  
        /// <param name="CacheKey">键</param>  
        public static object GetCache(string CacheKey)
        {
            //第一种写法
            //System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            // return objCache[CacheKey];
            // 第二种写法
            return HttpRuntime.Cache.Get(CacheKey);
        }



        /// <summary>
        /// 设置数据缓存绝对过期
        /// </summary>
        /// <param name="Key">
        /// 第一个参数null 为不依赖于文件和数据库
        /// DateTime.Now.AddSeconds(60) 缓存时间60秒
        ///  Cache.NoSlidingExpiration 不是相对过期时间
        /// CacheItemPriority.Default  优先级别
        /// 
        /// 
        /// </param>
        public static void SetCacheAbsolute(string Key, object objObject)
        {
            object obj = GetCache(Key);//读取获取缓存
            if (obj == null)//缓存为空就写入缓存
            {

                HttpRuntime.Cache.Add(Key, objObject, null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            }

        }
        /// <summary>
        /// 相对过期缓存
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="objObject">
        /// Cache.NoAbsoluteExpiration 不设置绝对过期
        /// new TimeSpan(0, 0, 10) 相对过期时间为10s
        /// 
        /// 
        /// </param>
        public static void SetCacheRelative(string Key, object objObject)
        {
            object obj = GetCache(Key);//读取获取缓存
            if (obj == null)//缓存为空就写入缓存
            {
                HttpRuntime.Cache.Add(Key, objObject, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 10), CacheItemPriority.Default, null);
            }

        }

        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string CacheKey, object objObject, TimeSpan Timeout)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, DateTime.MaxValue, Timeout, System.Web.Caching.CacheItemPriority.NotRemovable, null);


        }


        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }


        /// <summary>  
        /// 移除指定数据缓存  
        /// </summary>  
        public static void RemoveAllCache(string CacheKey)
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            _cache.Remove(CacheKey);
        }

        /**/
        /// <summary>  
        /// 移除全部缓存  
        /// </summary>  
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }



    }
}
