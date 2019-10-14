using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.tests
{
    public class TestMysql_serverDbSet : TestContext,IFireDumpContext
    {

        
        public TestMysql_serverDbSet() 
        {
            mysql_servers = new TestDbSet<mysql_servers>();
        }

        public DbSet<mysql_servers> mysql_servers
        {
            get; set;
        }
        

        public mysql_servers Find(int id)
        {
            return mysql_servers.SingleOrDefault(b => b.id == id);
        }

        public int SaveChangesCount
        {
            get; set;
        }

       
        public int SaveChanges()
        {
            this.SaveChangesCount++;
            return SaveChangesCount;
        }
    }


}

