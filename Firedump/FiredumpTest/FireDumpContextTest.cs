using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump;
using Firedump.tests;
using System.Collections.Generic;

namespace FiredumpTest
{
    [TestClass]
    public class FireDumpContextTest
    {
        [TestMethod]
        public void TestMysqlserversGetSave()
        {

            Firedump.tests.TestContext context = new Firedump.tests.TestContext();
            FiredumpContextTest service = new FiredumpContextTest(context);

            for (int i = 0; i <= 100; i++)
            {
                mysql_servers server = new mysql_servers();
                server.port = -10000 + i;
                server.host = "HOST"+i;
                server.name = "N"+i;
                server.password = "*"+i;
                server.username = "U" + i;

                server.id = i;
                service.saveMysqlServer(server);             
            }

            List<mysql_servers> servers = service.getAllMySqlServers();
            Assert.AreEqual(101, servers.Count);


            TestMysql_serverDbSet mysqlserverContext = new TestMysql_serverDbSet();
            service = new FiredumpContextTest(mysqlserverContext);

            for (int i = 0; i <= 100; i++)
            {
                mysql_servers server = new mysql_servers();
                server.port = -10000 + i;
                server.host = "HOST" + i;
                server.name = "N" + i;
                server.password = "*" + i;
                server.username = "U" + i;

                server.id = i;
                service.saveMysqlServer(server);
            }


            servers = service.getAllMySqlServers();
            Assert.AreEqual(101, servers.Count);
            for(int i =0; i < servers.Count; i++)
            {
                mysql_servers temps = mysqlserverContext.Find((int)servers[i].id);
                Assert.AreEqual(servers[i],temps);
                Assert.AreEqual(servers[i].id, temps.id);
                Assert.AreEqual(servers[i].host, temps.host);
                Assert.AreEqual(servers[i].name, temps.name);
                Assert.AreEqual(servers[i].password, temps.password);
                Assert.AreEqual(servers[i].port, temps.port);
            }


            mysql_servers mysqlserver = service.getAllMySqlServers()[0];
            schedules schedule = new schedules();
            schedule.hours = 1;
            schedule.activated = 0;
            schedule.date = new DateTime();
            schedule.name = "scheduleName";
            schedule.server_id = mysqlserver.id;

            service.saveSchedule(schedule);

            servers = service.getAllMySqlServers();
            List<schedules> schedules = service.getSchedules();
            for(int i =0; i < servers.Count; i++)
            {
                
            }
            

        }


    }
}
