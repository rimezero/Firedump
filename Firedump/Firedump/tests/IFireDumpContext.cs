using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.tests
{
    public interface IFireDumpContext
    {
        DbSet<mysql_servers> mysql_servers { get; }
        DbSet<schedules> schedules { get; }
        int SaveChanges();
    }
}
