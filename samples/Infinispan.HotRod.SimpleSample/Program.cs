using System;
using Infinispan.HotRod.Config;
namespace Infinispan.HotRod.SimpleSample
{
    class Program
    {
        private static IRemoteCache<String, String> cache;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConfigurationBuilder conf = new ConfigurationBuilder();
            conf.AddServer().Host("127.0.0.1").Port(11222);
            conf.ConnectionTimeout(90000).SocketTimeout(6000);
            RemoteCacheManager remoteManager = new RemoteCacheManager(conf.Build(), true);
            cache = remoteManager.GetCache<String, String>();
        }
    }
}
