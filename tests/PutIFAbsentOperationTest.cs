﻿using Infinispan.DotNetClient.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Infinispan.DotNetClient.Protocol;
using Infinispan.DotNetClient;
using Infinispan.DotNetClient.Trans;
using Infinispan.DotNetClient.Util;

namespace tests
{
    [TestClass()]
    public class PutIFAbsentOperationTest:SingleServerAbstractTest
    {
        [TestMethod()]
        public void putIfAbsentTest()
        {
            IRemoteCache<String, String> defaultCache = remoteManager.getCache(true);
            defaultCache.put("key7", "carbon0");
            defaultCache.putIfAbsent("key7", "carbon1");
            defaultCache.putIfAbsent("key8", "carbon2");
            Assert.AreEqual("carbon0",defaultCache.get("key7"));
            Assert.AreEqual("carbon2", defaultCache.get("key8"));
        }
    }
}
