using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump.utils;
using Firedump.db;

namespace FiredumpTest
{
    [TestClass]
    public class TestOS
    {
        [TestMethod]
        public void IsWindowsServerTest()
        {
            //i can show only output, cant test
            bool isServer = OS.IsWindowsServer();
            Console.WriteLine(isServer);
        }
    }
}
