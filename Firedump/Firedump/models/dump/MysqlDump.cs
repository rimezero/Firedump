using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;
using Firedump.models.dump;
using System.IO;
using System.Text.RegularExpressions;
using Firedump.models.databaseUtils;
using Firedump.utils;

namespace Firedump.models.dump
{
    public class MysqlDump
    {
        //<events>
        private static readonly string BUILD_SERVER_MYSQLDUMP_PATH = "C:\\jenkins\\resources\\mysqldump.exe";
        public bool IsTest { get; set; }

        //onTableStartDump
        public delegate void tableStartDump(string table);
        public event tableStartDump TableStartDump;
        private void onTableStartDump(string table)
        {
            TableStartDump?.Invoke(table);
        }

        //onCompressStart
        public delegate void tableRowCount(int rowcount);
        public event tableRowCount TableRowCount;
        private void onTableRowCount(int rowcount)
        {
            TableRowCount?.Invoke(rowcount);
        }

        //onCompressProgress
        public delegate void compressProgress(int progress);
        public event compressProgress CompressProgress;
        private void onCompressProgress(int progress)
        {
            CompressProgress?.Invoke(progress);
        }

        //onCompressStart
        public delegate void compressStart();
        public event compressStart CompressStart;
        private void onCompressStart()
        {
            CompressStart?.Invoke();
        }

        //</events>

        ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();
        /// <summary>
        /// Create a new credentials instance and set it before executing mysqldump
        /// </summary>
        public DumpCredentialsConfig credentialsConfigInstance { set; get; }

        private Process proc;
        private Compression comp;
        private string tempTableName = "";
        private string currentDatabase = "";

        private DumpResultSet resultObj;

        bool createschema = ConfigurationManager.getInstance().mysqlDumpConfigInstance.includeCreateSchema;
        bool ignoreInsert = ConfigurationManager.getInstance().mysqlDumpConfigInstance.useIgnoreInserts;
        bool backquotes = ConfigurationManager.getInstance().mysqlDumpConfigInstance.encloseWithBackquotes;
        int insertReplace = ConfigurationManager.getInstance().mysqlDumpConfigInstance.exportType;
        bool xmlout = ConfigurationManager.getInstance().mysqlDumpConfigInstance.xml;

        public MysqlDump() { }

        private StringBuilder calculateArguments()
        {
            StringBuilder arguments = new StringBuilder();
            resultObj = new DumpResultSet();
            //<ConfigurationSection>

            arguments.Append("--protocol=tcp ");

            //Credentials

            //host
            if (!String.IsNullOrEmpty(credentialsConfigInstance.host))
            {
                arguments.Append("--host " + credentialsConfigInstance.host + " ");
            }
            else
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Host not set";
                return arguments;
            }

            //port
            if (credentialsConfigInstance.port < 1 || credentialsConfigInstance.port > 65535)
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Invalid port number: " + credentialsConfigInstance.port;
                return arguments;
            }
            else
            {
                arguments.Append("--port=" + credentialsConfigInstance.port + " ");
            }

            //username
            if (!String.IsNullOrEmpty(credentialsConfigInstance.username))
            {
                arguments.Append("--user " + credentialsConfigInstance.username + " ");
            }
            else
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Username not set";
                return arguments;
            }

            //pasword
            if (!String.IsNullOrEmpty(credentialsConfigInstance.password))
            {
                arguments.Append("--password=" + credentialsConfigInstance.password + " ");
            }

            //MySqlDumpConfiguration

            //includeCreateSchema
            if (!configurationManagerInstance.mysqlDumpConfigInstance.includeCreateSchema)
            {
                arguments.Append("--no-create-info ");
            }

            //includeData
            if (!configurationManagerInstance.mysqlDumpConfigInstance.includeData)
            {
                arguments.Append("--no-data ");
            }

            //includeComments
            if (!configurationManagerInstance.mysqlDumpConfigInstance.includeComments)
            {
                arguments.Append("--skip-comments ");
            }

            //singleTransaction
            if (configurationManagerInstance.mysqlDumpConfigInstance.singleTransaction)
            {
                arguments.Append("--single-transaction ");
            }

            //disableForeignKeyChecks
            if (configurationManagerInstance.mysqlDumpConfigInstance.disableForeignKeyChecks)
            {
                arguments.Append("--disable-keys ");
            }

            //addDropDatabase
            if (configurationManagerInstance.mysqlDumpConfigInstance.addDropDatabase)
            {
                arguments.Append("--add-drop-database ");
            }

            //createDatabase
            if (!configurationManagerInstance.mysqlDumpConfigInstance.createDatabase)
            {
                arguments.Append("--no-create-db ");
            }

            //moreCompatible
            if (configurationManagerInstance.mysqlDumpConfigInstance.moreCompatible)
            {
                arguments.Append("--compatible ");
            }

            //characterSet
            if (configurationManagerInstance.mysqlDumpConfigInstance.characterSet != "utf8")
            {
                string charSetPath = "\"" + AppDomain.CurrentDomain.BaseDirectory + "resources\\mysqldump\\charsets\"";
                arguments.Append("--character-sets-dir=" + charSetPath + " ");
                arguments.Append("--default-character-set=" + configurationManagerInstance.mysqlDumpConfigInstance.characterSet + " ");
            }

            //addDropTable
            if (configurationManagerInstance.mysqlDumpConfigInstance.addDropTable)
            {
                arguments.Append("--add-drop-table ");
            }
            else
            {
                arguments.Append("--skip-add-drop-table ");
            }

            //addLocks
            if (configurationManagerInstance.mysqlDumpConfigInstance.addLocks)
            {
                arguments.Append("--add-locks ");
            }

            //noAutocommit
            if (configurationManagerInstance.mysqlDumpConfigInstance.noAutocommit)
            {
                arguments.Append("--no-autocommit ");
            }

            //encloseWithBackquotes
            if (!configurationManagerInstance.mysqlDumpConfigInstance.encloseWithBackquotes)
            {
                arguments.Append("--skip-quote-names ");
            }

            //addCreateProcedureFunction
            if (configurationManagerInstance.mysqlDumpConfigInstance.addCreateProcedureFunction)
            {
                arguments.Append(" --routines ");
            }

            //addInfoComments
            if (configurationManagerInstance.mysqlDumpConfigInstance.addInfoComments)
            {
                arguments.Append("--dump-date ");
            }

            //completeInsertStatements
            if (configurationManagerInstance.mysqlDumpConfigInstance.completeInsertStatements)
            {
                arguments.Append("--complete-insert ");
            }

            //extendedInsertStatements
            if (configurationManagerInstance.mysqlDumpConfigInstance.completeInsertStatements)
            {
                arguments.Append("--extended-insert ");
            }

            //maximumLengthOfQuery
            arguments.Append("--net-buffer-length " + configurationManagerInstance.mysqlDumpConfigInstance.maximumLengthOfQuery + " ");

            //maximumPacketLength
            arguments.Append("--max_allowed_packet=" + configurationManagerInstance.mysqlDumpConfigInstance.maximumPacketLength + "M ");

            //useIgnoreInserts
            if (configurationManagerInstance.mysqlDumpConfigInstance.useIgnoreInserts)
            {
                arguments.Append("--insert-ignore ");
            }

            //useHexadecimal
            if (configurationManagerInstance.mysqlDumpConfigInstance.useHexadecimal)
            {
                arguments.Append("--hex-blob ");
            }

            //dumpTriggers
            if (!configurationManagerInstance.mysqlDumpConfigInstance.dumpTriggers)
            {
                arguments.Append("--skip-triggers ");
            }

            //dumpEvents
            if (configurationManagerInstance.mysqlDumpConfigInstance.dumpEvents)
            {
                arguments.Append("--events ");
            }

            //xml
            if (configurationManagerInstance.mysqlDumpConfigInstance.xml)
            {
                arguments.Append("--xml ");
            }

            //exportType
            switch (configurationManagerInstance.mysqlDumpConfigInstance.exportType)
            {
                case 0:
                    break;
                case 1:
                    arguments.Append("--replace ");
                    break;
                default:
                    break;
            }

            //database choice
            if (credentialsConfigInstance.databases == null)
            {
                if (string.IsNullOrEmpty(credentialsConfigInstance.database))
                {
                    arguments.Append("--all-databases ");
                }
                else
                {
                    arguments.Append("--databases " + credentialsConfigInstance.database);
                    if (credentialsConfigInstance.excludeTablesSingleDatabase != null)
                    {
                        arguments.Append(" ");
                        string[] tables = credentialsConfigInstance.excludeTablesSingleDatabase.Split(',');
                        foreach (string table in tables)
                        {
                            arguments.Append("--ignore-table=" + credentialsConfigInstance.database + "." + table + " ");
                        }
                    }
                }
            }
            else
            {
                arguments.Append("--databases ");
                foreach (string database in credentialsConfigInstance.databases)
                {
                    arguments.Append(database + " ");
                }
                if (credentialsConfigInstance.excludeTables != null)
                {
                    for (int i = 0; i < credentialsConfigInstance.excludeTables.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(credentialsConfigInstance.excludeTables[i]))
                        {
                            string[] tables = credentialsConfigInstance.excludeTables[i].Split(',');
                            foreach (string table in tables)
                            {
                                arguments.Append("--ignore-table=" + credentialsConfigInstance.databases[i] + "." + table + " ");
                            }
                        }
                    }
                }
            }

            //</ConfigurationSection>
            resultObj.wasSuccessful = true;
            return arguments;
        }


        public DumpResultSet executeDump()
        {
            //to espasa se 2 methodous
            StringBuilder arguments = calculateArguments();

            if (!resultObj.wasSuccessful)
            {
                return resultObj;
            }

            //dump execution
            Console.WriteLine(arguments.ToString());
            
            string mysqldumpfile = "resources/mysqldump/mysqldump.exe";
            //now we can run test localy and on server
            //localy visual studio test suite will handle process mapping
            if (IsTest)
            {
                if(OS.IsWindowsServer())
                    mysqldumpfile = BUILD_SERVER_MYSQLDUMP_PATH;
            }
                
            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = mysqldumpfile,//AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "mysqldump.exe") ,
                    Arguments = arguments.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
         
            Console.WriteLine("MySqlDump: Dump starting now");      
            proc.Start();

            Random rnd = new Random();
            string fileExt;
            if (configurationManagerInstance.mysqlDumpConfigInstance.xml)
            {
                fileExt = ".xml";
            }
            else
            {
                fileExt = ".sql";
            }
            String filename = "dump" + rnd.Next(1000000, 9999999) + fileExt;

            Directory.CreateDirectory(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath);
           

            //checking if file exists
            while (File.Exists(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename)){
                filename = "Dump" + rnd.Next(10000000, 99999999) + fileExt;
            }

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename))
                {
                    //addCustomCommentInHeader
                    if (!string.IsNullOrEmpty(configurationManagerInstance.mysqlDumpConfigInstance.addCustomCommentInHeader))
                    {
                        file.WriteLine("-- Custom comment: " + configurationManagerInstance.mysqlDumpConfigInstance.addCustomCommentInHeader);
                    }


                    while (!proc.StandardOutput.EndOfStream)
                    {
                        string line = proc.StandardOutput.ReadLine();
                        file.WriteLine(line);
                        handleLineOutput(line);
                    }

                }


                resultObj.mysqldumpexeStandardError = "";
                while (!proc.StandardError.EndOfStream)
                {
                    resultObj.mysqldumpexeStandardError += proc.StandardError.ReadLine() + "\n";
                }

                if(resultObj.mysqldumpexeStandardError.StartsWith("Warning: Using a password"))
                {
                    resultObj.mysqldumpexeStandardError = resultObj.mysqldumpexeStandardError.Replace("Warning: Using a password on the command line interface can be insecure.\n","");
                }

                Console.WriteLine(resultObj.mysqldumpexeStandardError); //for testing

                proc.WaitForExit();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("MySQLdump null reference exception on proccess: "+ex.Message);
                File.Delete(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename);
            }
            if (proc == null || proc.ExitCode != 0)
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -2;
                if(proc == null)
                {
                    resultObj.mysqldumpexeStandardError = "MySQL dump proccess was killed.";
                }
                File.Delete(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename);
            }
            else
            {
                resultObj.wasSuccessful = true;
                resultObj.fileAbsPath = configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename;

                //compression
                if (configurationManagerInstance.compressConfigInstance.enableCompression)
                {
                    comp = new Compression();
                    if (IsTest)
                    {
                        if (OS.IsWindowsServer())
                            comp.IsTest = true;
                    }

                    comp.absolutePath = resultObj.fileAbsPath;
                    comp.CompressProgress += onCompressProgressHandler;
                    comp.CompressStart += onCompressStartHandler;
                   
                    CompressionResultSet compResult = comp.doCompress7z(); //edw kaleitai to compression

                    if (!compResult.wasSucessful)
                    {
                        resultObj.wasSuccessful = false;
                        resultObj.errorNumber = -3;
                        resultObj.mysqldumpexeStandardError = compResult.standardError;
                    }
                    File.Delete(resultObj.fileAbsPath); //delete to sketo .sql
                    resultObj.fileAbsPath = compResult.resultAbsPath;
                }
            }
                    
            return resultObj;
        }

        private void onCompressProgressHandler(int progress)
        {
            onCompressProgress(progress);
        }

        private void onCompressStartHandler()
        {
            onCompressStart();
        }


        public void cancelMysqlDumpProcess()
        {        
                try
                {
                    if(comp != null)
                    {
                        comp.KillProc();
                    }                   
                    proc.Kill();
                    proc = null;                   
                }catch(Exception ex)
                {
                }                
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="createschema"></param>
        private void handleLineOutput(string line) //ekana ta boolean global gia na min ta pernaei sinexws parametrika
        {
            if (!String.IsNullOrEmpty(line))
            {
                if (backquotes)
                {
                    if (line.ToUpper().StartsWith("USE"))
                    {
                        currentDatabase = line.Split('`', '`')[1];
                    }
                }
                else
                {
                    if (line.ToUpper().StartsWith("USE"))
                    {
                        currentDatabase = line.Replace("USE", "").Trim();
                    }
                }

                string insertStartsWith = "";
                if (insertReplace == 1 && ignoreInsert == true)
                {
                    insertStartsWith = "REPLACE  IGNORE INTO";
                }
                else if (insertReplace == 1)
                {
                    insertStartsWith = "REPLACE INTO";
                }
                else if (ignoreInsert)
                {
                    insertStartsWith = "INSERT  IGNORE INTO";
                }
                else
                {
                    insertStartsWith = "INSERT INTO";
                }

                //Console.WriteLine(insertStartsWith);

                if (!xmlout)
                {
                    if (createschema)
                    {
                        if (line.StartsWith("CREATE TABLE"))
                        {
                            string tablename = "";
                            if (!backquotes)
                            {
                                int Pos1 = line.IndexOf("TABLE") + 5;
                                int Pos2 = line.IndexOf("(");
                                tablename = line.Substring(Pos1, Pos2 - Pos1).Trim();
                            }
                            else
                            {
                                tablename = line.Split('`', '`')[1];
                            }

                            Console.WriteLine(tablename);

                            int rowcount = 1;
                            try
                            {
                                rowcount = getDbTableRowsCount(tablename, currentDatabase);
                            }
                            catch (Exception ex)
                            {
                            }
                            Console.WriteLine(tablename);
                            //fire event
                            onTableStartDump(tablename);
                            onTableRowCount(rowcount);

                        }

                    }
                    else
                    {
                        if (line.Contains(insertStartsWith))
                        {
                            string tablename = "";
                            if (!backquotes)
                            {
                                int Pos1 = line.IndexOf("INTO") + 4;
                                int Pos2 = line.IndexOf("(");
                                tablename = line.Substring(Pos1, Pos2 - Pos1).Trim();
                            }
                            else
                            {
                                tablename = line.Split('`', '`')[1];
                            }

                            if (tablename == tempTableName)
                            {

                            }
                            else
                            {
                                tempTableName = tablename;

                                int rowcount = 1;
                                try
                                {
                                    rowcount = getDbTableRowsCount(tablename, currentDatabase);
                                }
                                catch (Exception ex)
                                {
                                }
                                Console.WriteLine(tablename);
                                //fire event
                                onTableStartDump(tablename);
                                onTableRowCount(rowcount);
                            }

                        }
                    }
                }
            }
            
        }
        

        private int getDbTableRowsCount(string tableName,string dbname)
        {
            string host = credentialsConfigInstance.host;
            string password = credentialsConfigInstance.password;
            string username = credentialsConfigInstance.username;
            int port = credentialsConfigInstance.port;

            string constring = DbConnection.conStringBuilder(host, username, password, dbname,port);
            return DbConnection.Instance().getTableRowsCount(tableName,constring);
        }

    }
}
