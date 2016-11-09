using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infinispan.HotRod;
using Infinispan.HotRod.Config;
namespace ConsoleApplication1
{
    class Program
    {
        private static IRemoteCache<String, String> cache;
        static void Main(string[] args)
        {
            ConfigurationBuilder conf = new ConfigurationBuilder();
            conf.AddServer().Host("127.0.0.1").Port(11222);
            conf.ConnectionTimeout(90000).SocketTimeout(6000);
            RemoteCacheManager remoteManager = new RemoteCacheManager(conf.Build(), true);
            cache = remoteManager.GetCache<String, String>();
            cache.Put("ciao", "hello");
            cache.Put("buono", "good");
            cache.addClientListener("", "", true, new string[] { }, new string[] { }, null);
            Console.Out.WriteLine("COEODO");
            Console.Out.WriteLine("COEeeeeeeeeeeeeeeeeeODO");
        }
    }
}
