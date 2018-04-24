using System.Collections.Generic;

namespace Infinispan.HotRod
{
    /// <summary>
    /// This class provides the user with methods for creating and removing remote cache
    /// </summary>
    public class RemoteCacheManagerAdmin
    {
        private RemoteCacheManager remoteCacheManager;
        private Infinispan.HotRod.SWIGGen.RemoteCacheManagerAdmin remoteCacheManagerAdmin;

        internal RemoteCacheManagerAdmin(RemoteCacheManager remoteCacheManager, Infinispan.HotRod.SWIGGen.RemoteCacheManagerAdmin remoteCacheManagerAdmin)
        {
            this.remoteCacheManager = remoteCacheManager;
            this.remoteCacheManagerAdmin = remoteCacheManagerAdmin;
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public IRemoteCache<K, V> CreateCache<K,V>(string name, string model)
        {
            remoteCacheManagerAdmin.createCache(name, model != null ? model : "" , "@@cache@create");
            return remoteCacheManager.GetCache<K, V>(name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        public void CreateCache(string name, string model)
        {
            remoteCacheManagerAdmin.createCache(name, model != null ? model : "", "@@cache@create");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        public void GetOrCreateCache(string name, string model)
        {
            remoteCacheManagerAdmin.createCache(name, model != null ? model : "", "@@cache@getorcreate");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public IRemoteCache<K, V> GetOrCreateCache<K, V>(string name, string model)
        {
            remoteCacheManagerAdmin.createCache(name, model != null ? model : "", "@@cache@getorcreate");
            return remoteCacheManager.GetCache<K, V>(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="name"></param>
        /// <param name="conf"></param>
        /// <returns></returns>
        public IRemoteCache<K, V> CreateCacheWithXml<K, V>(string name, string conf)
        {
            remoteCacheManagerAdmin.createCacheWithXml(name, conf, "@@cache@create");
            return remoteCacheManager.GetCache<K, V>(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="name"></param>
        /// <param name="conf"></param>
        /// <returns></returns>
        public IRemoteCache<K, V> GetOrCreateCacheWithXml<K, V>(string name, string conf)
        {
            remoteCacheManagerAdmin.createCacheWithXml(name, conf, "@@cache@getorcreate");
            return remoteCacheManager.GetCache<K, V>(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        public RemoteCacheManagerAdmin WithFlags(ISet<AdminFlag> flags)
        {
            remoteCacheManagerAdmin.withFlags(flags);
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void RemoveCache(string name)
        {
            remoteCacheManagerAdmin.removeCache(name);
        }

    }
}