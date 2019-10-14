using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.tests
{
    public class FiredumpContextTest
    {
        private IFireDumpContext contextdb;

        public FiredumpContextTest(IFireDumpContext contextdb)
        {
            this.contextdb = contextdb;
        }


        public List<mysql_servers> getAllMySqlServers()
        {        
            return contextdb.mysql_servers.ToList();           
        }

        //return the new id
        public int saveMysqlServer(mysql_servers server)
        {          
            contextdb.mysql_servers.Add(server);
            contextdb.SaveChanges();
            return (int)server.id;          
        }

        public mysql_servers getMysqlServerById(int id)
        {      
            mysql_servers server = contextdb.mysql_servers.Find(id);
            return server;
        }


        public void deleteMysqlServer(mysql_servers server)
        {
            contextdb.mysql_servers.Remove(server);
            contextdb.SaveChanges();
        }


        public List<schedules> getSchedules()
        {
            return contextdb.schedules.ToList();
        }

        public int saveSchedule(schedules schedule)
        {
            contextdb.schedules.Add(schedule);
            contextdb.SaveChanges();
            return (int)schedule.id;
        }
    }
}
