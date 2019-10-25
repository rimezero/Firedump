using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    class BinlogDumpCredentialsConfig : CredentialsConfig
    {
        /// <summary>
        /// The database to query the logs for. Leave null to get info for all databases on the server.
        /// </summary>
        public string database { set; get; }
        /// <summary>
        /// Names of the log files on the mysql server to use for the dump. Leave null to get all.
        /// </summary>
        public string[] logfiles { set; get; }
        /// <summary>
        /// True does an incremental delta otherwise does an incremental backup
        /// </summary>
        public bool isIncrementalDelta { set; get; }
        /// <summary>
        /// the folder path of the save location 
        /// </summary>
        public string path { set; get; }
        /// <summary>
        /// 0 for local 1 for ftp
        /// </summary>
        public int locationType { set; get; }
    }
}
