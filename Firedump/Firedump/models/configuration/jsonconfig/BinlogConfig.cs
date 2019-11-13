using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.jsonconfig
{
    public class BinlogConfig : ConfigurationClass<BinlogConfig>
    {
        private readonly string jsonFilePath = "./config/BinlogConfig.json";

        //<configuration fields section>
        /// <summary>
        /// --base64-output=value
        /// This option determines when events should be displayed encoded as base-64 strings using BINLOG statements. The option has these permissible values (not case-sensitive):
        /// AUTO - ("automatic") or UNSPEC ("unspecified") displays BINLOG statements automatically when necessary (that is, for format description events and row events). If no --base64-output option is given, the effect is the same as --base64-output=AUTO.
        /// NEVER - causes BINLOG statements not to be displayed. mysqlbinlog exits with an error if a row event is found that must be displayed using BINLOG.
        /// DECODE-ROWS - specifies to mysqlbinlog that you intend for row events to be decoded and displayed as commented SQL statements by also specifying the --verbose option
        /// </summary>
        public string base64output = "";
        /// <summary>
        /// --bind-address=ip_address
        /// On a computer having multiple network interfaces, use this option to select which interface to use for connecting to the MySQL server.
        /// </summary>
        public string bindAdress = "";
        /// <summary>
        /// --binlog-row-event-max-size=N
        /// 0 disabled
        /// Specify the maximum size of a row-based binary log event, in bytes. Rows are grouped into events smaller than this size if possible. The value should be a multiple of 256. The default is 4GB.
        /// </summary>
        public long rowEventMaxSize = 0;
        /// <summary>
        /// --character-sets-dir=dir_name
        /// The directory where character sets are installed (On the server).
        /// </summary>
        public string characterSetsDir = "";
        /// <summary>
        /// --compression-algorithms=value
        /// The permitted compression algorithms for connections to the server. The available algorithms are the same as for the protocol_compression_algorithms system variable. The default value is uncompressed.
        /// valid values = zlib,zstd,uncompressed
        /// </summary>
        public string compressionAlgorithms = "";
        /// <summary>
        /// --connection-server-id=server_id
        /// 0 disabled
        /// --connection-server-id specifies the server ID that mysqlbinlog reports when it connects to the server. It can be used to avoid a conflict with the ID of a slave server or another mysqlbinlog process.
        /// </summary>
        public int conServerId = 0;
        /// <summary>
        /// --debug[=debug_options]
        /// Write a debugging log. A typical debug_options string is d:t:o,file_name. The default is d:t:o,/tmp/mysqlbinlog.trace.
        /// </summary>
        public string debugOptions = "";
        /// <summary>
        /// --debug-check
        /// Print some debugging information when the program exits.
        /// </summary>
        public bool debugCheck = false;
        /// <summary>
        /// --debug-info
        /// Print debugging information and memory and CPU usage statistics when the program exits.
        /// </summary>
        public bool debugInfo = false;
        /// <summary>
        /// --disable-log-bin, -D
        /// Disable binary logging. This is useful for avoiding an endless loop if you use the --to-last-log option and are sending the output to the same MySQL server. This option also is useful when restoring after a crash to avoid duplication of the statements you have logged.
        /// </summary>
        public bool disableLogBin = false;
        /// <summary>
        /// --exclude-gtids=gtid_set
        /// Do not display any of the groups listed in the gtid_set.
        /// </summary>
        public string excludeGtids = "";
        /// <summary>
        /// --force-if-open, -F
        /// Read binary log files even if they are open or were not closed properly.
        /// </summary>
        public bool forceIfOpen = false;
        /// <summary>
        /// --force-read, -f
        /// With this option, if mysqlbinlog reads a binary log event that it does not recognize, it prints a warning, ignores the event, and continues. Without this option, mysqlbinlog stops if it reads such an event.
        /// </summary>
        public bool forceRead = false;
        /// <summary>
        /// --hexdump, -H
        /// Display a hex dump of the log in comments, as described in Section 4.6.8.1, “mysqlbinlog Hex Dump Format”. The hex output can be helpful for replication debugging.
        /// </summary>
        public bool hexdump = false;
        /// <summary>
        /// --idempotent
        /// Tell the MySQL Server to use idempotent mode while processing updates; this causes suppression of any duplicate-key or key-not-found errors that the server encounters in the current session while processing updates. This option may prove useful whenever it is desirable or necessary to replay one or more binary logs to a MySQL Server which may not contain all of the data to which the logs refer.
        /// </summary>
        public bool idempotent = false;
        /// <summary>
        /// --print-defaults
        /// Print the program name and all options that it gets from option files.
        /// </summary>
        public bool printDefaults = false;
        /// <summary>
        /// --print-table-metadata
        /// Print table related metadata from the binary log. Configure the amount of table related metadata binary logged using binlog-row-metadata.
        /// </summary>
        public bool printTableMetadata = false;
        /// <summary>
        /// --protocol={TCP|SOCKET|PIPE|MEMORY}
        /// The connection protocol to use for connecting to the server. It is useful when the other connection parameters normally result in use of a protocol other than the one you want.
        /// </summary>
        public string protocol = "tcp";
        /// <summary>
        /// --raw
        /// By default, mysqlbinlog reads binary log files and writes events in text format. The --raw option tells mysqlbinlog to write them in their original binary format.
        /// </summary>
        public bool raw = false;
        /// <summary>
        /// --rewrite-db='from_name->to_name'
        /// When reading from a row-based or statement-based log, rewrite all occurrences of from_name to to_name. Rewriting is done on the rows, for row-based logs, as well as on the USE clauses, for statement-based logs.
        /// </summary>
        public string rewriteDb = "";
        /// <summary>
        /// --get-server-public-key
        /// Request from the server the public key required for RSA key pair-based password exchange. This option applies to clients that authenticate with the caching_sha2_password authentication plugin. For that plugin, the server does not send the public key unless requested. This option is ignored for accounts that do not authenticate with that plugin. It is also ignored if RSA-based password exchange is not used, as is the case when the client connects to the server using a secure connection.
        /// </summary>
        public bool getServerPublicKey = false;
        /// <summary>
        /// --server-id=id
        /// -1 disabled
        /// Display only those events created by the server having the given server ID.
        /// </summary>
        public int serverId = -1;
        /// <summary>
        /// --set-charset=charset_name
        /// Add a SET NAMES charset_name statement to the output to specify the character set to be used for processing log files.
        /// </summary>
        public string charsetName = "utf8";
        /// <summary>
        /// --skip-gtids[=(true|false)]
        /// Do not display any GTIDs in the output. This is needed when writing to a dump file from one or more binary logs containing GTIDs
        /// </summary>
        public bool skipGtids = false;
        /// <summary>
        /// --verbose, -v
        /// Reconstruct row events and display them as commented SQL statements, with table partition information where applicable.
        /// </summary>
        public bool verbose = false;
        /// <summary>
        /// Use mysql server time instead of local machine's to increase dump time precision
        /// WARNING: the server and the client must be in the same time zone for this option to work correctly
        /// </summary>
        public bool useServerTime = false;
        //</configuration fields section>

        private static BinlogConfig binlogConfigInstance;

        private BinlogConfig() { }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static BinlogConfig getInstance()
        {
            if (binlogConfigInstance == null)
            {
                binlogConfigInstance = new BinlogConfig();
            }
            return binlogConfigInstance;
        }

        public BinlogConfig initializeConfig()
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                binlogConfigInstance = JsonConvert.DeserializeObject<BinlogConfig>(json);
                return binlogConfigInstance;
            }
            catch (Exception ex)
            {
                binlogConfigInstance = new BinlogConfig(); //resetarei sta default options giati mporei apo panw na exoun allaksei kapoia se periptwsi corrupted data
                binlogConfigInstance.saveConfig();
                if (!(ex is FileNotFoundException || ex is JsonException || ex is RuntimeBinderException))
                {
                    Console.WriteLine("BinlogConfig.initializeConfig(): " + ex.ToString());
                }
                return binlogConfigInstance; //never reached just to avoid error message
            }
        }

        public BinlogConfig resetToDefaults()
        {
            binlogConfigInstance = new BinlogConfig();
            binlogConfigInstance.saveConfig();
            return binlogConfigInstance;
        }

        public void saveConfig()
        {
            string jsonOutput = JsonConvert.SerializeObject(this, Formatting.Indented);
            FileInfo file = new FileInfo(jsonFilePath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllText(file.FullName, jsonOutput);
        }
    }
}
