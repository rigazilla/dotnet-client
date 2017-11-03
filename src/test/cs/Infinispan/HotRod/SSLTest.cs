using System;
using NUnit.Framework;
using Infinispan.HotRod.Config;

namespace Infinispan.HotRod.Tests
{
    class SSLTest
    {
        [Test]
        public void SSLSuccessfullServerAndClientAuthTest()
        {
            ConfigurationBuilder conf = new ConfigurationBuilder();
            conf.AddServer().Host("127.0.0.1").Port(11222).ConnectionTimeout(90000).SocketTimeout(900);
            SslConfigurationBuilder sslConf = conf.Ssl();
            registerServerCAFile(sslConf, "infinispan-ca.pem");
            registerClientCertificateFile(sslConf, "truststore_client.p12");
            conf.Marshaller(new JBasicMarshaller());

            RemoteCacheManager remoteManager = new RemoteCacheManager(conf.Build(), true);
            IRemoteCache<string, string> testCache = remoteManager.GetCache<string, string>();

            testCache.Clear();
            string k1 = "key13";
            string v1 = "boron";
            testCache.Put(k1, v1);
            Assert.AreEqual(v1, testCache.Get(k1));
        }

        [Test]
        public void SNI1CorrectCredentialsTest() 
        {
            ConfigurationBuilder conf = new ConfigurationBuilder();
            conf.AddServer().Host("127.0.0.1").Port(11222).ConnectionTimeout(90000).SocketTimeout(900);
            conf.Marshaller(new JBasicMarshaller());
            registerServerCAFile(conf.Ssl(), "keystore_server_sni1.pem", "sni1");
            registerClientCertificateFile(conf.Ssl(), "truststore_client.p12");

            RemoteCacheManager remoteManager = new RemoteCacheManager(conf.Build(), true);
            IRemoteCache<string, string> testCache = remoteManager.GetCache<string, string>();

            testCache.Clear();
            string k1 = "key13";
            string v1 = "boron";
            testCache.Put(k1, v1);
            Assert.AreEqual(v1, testCache.Get(k1));
        }

        [Test]
        public void SNI2CorrectCredentialsTest()
        {
            ConfigurationBuilder conf = new ConfigurationBuilder();
            conf.AddServer().Host("127.0.0.1").Port(11222).ConnectionTimeout(90000).SocketTimeout(900);
            conf.Marshaller(new JBasicMarshaller());
            registerServerCAFile(conf.Ssl(), "keystore_server_sni2.pem", "sni2");
            registerClientCertificateFile(conf.Ssl(), "truststore_client.p12");

            RemoteCacheManager remoteManager = new RemoteCacheManager(conf.Build(), true);
            IRemoteCache<string, string> testCache = remoteManager.GetCache<string, string>();

            testCache.Clear();
            string k1 = "key13";
            string v1 = "boron";
            testCache.Put(k1, v1);
            Assert.AreEqual(v1, testCache.Get(k1));
        }

        [Test]
        [ExpectedException(typeof(Infinispan.HotRod.Exceptions.TransportException), ExpectedMessage = "**** The server certificate did not validate correctly.\n")]
        public void SNIUntrustedTest()
        {
            ConfigurationBuilder conf = new ConfigurationBuilder();
            conf.AddServer().Host("127.0.0.1").Port(11222).ConnectionTimeout(90000).SocketTimeout(900);
            conf.Marshaller(new JBasicMarshaller());

            registerServerCAFile(conf.Ssl(), "malicious.pem", "sni3-untrusted");
            registerClientCertificateFile(conf.Ssl(), "truststore_client.p12");

            RemoteCacheManager remoteManager = new RemoteCacheManager(conf.Build(), true);
            IRemoteCache<string, string> testCache = remoteManager.GetCache<string, string>();

            testCache.Clear();
            string k1 = "key13";
            string v1 = "boron";
            testCache.Put(k1, v1);
            Assert.Fail("Should not get here");
        }

        void registerServerCAFile(SslConfigurationBuilder conf, string filename = "", string sni = "")
        {
            if (filename != "")
            {
                checkFileExists(filename);
                conf.Enable().ServerCAFile(filename);
                if (sni != "")
                {
                    conf.SniHostName(sni);
                }
            }
        }

        void registerClientCertificateFile(SslConfigurationBuilder conf, string filename = "")
        {
            if (filename != "")
            {
                checkFileExists(filename);
                conf.Enable().ClientCertificateFile(filename);
            }
        }

        void checkFileExists(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                Console.WriteLine("File not found: " + filename);
                Environment.Exit(-1);
            }
        }
    }
}
