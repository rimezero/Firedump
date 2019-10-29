using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class BinlogDump
    {
        //<events>

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
        public BinlogDumpCredentialsConfig config { set; get; }

        private Process proc;
        private Compression comp;

        private string logfiles;
        private string startdate;

        private BinlogDumpResultset result;

        public BinlogDumpResultset executeDump()
        {
            result = new BinlogDumpResultset();
            result.wasSuccessful = true;
            StringBuilder arguments = calculateArguments();

            if (!result.wasSuccessful)
            {
                return result;
            }

            // dump execution
            Console.WriteLine(arguments.ToString());

            string binlogexefile = "resources\\mysqldump\\mysqlbinlog.exe";

            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = binlogexefile,
                    Arguments = arguments.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            Console.WriteLine("BinlogDump: Dump starting now");
            proc.Start();

            Random rnd = new Random();
            string fileExt = ".sql";
            String filename = "binlogdump" + rnd.Next(1000000, 9999999) + fileExt;
            Directory.CreateDirectory(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath);
            while (File.Exists(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename))
            {
                filename = "binlogdump" + rnd.Next(10000000, 99999999) + fileExt;
            }

            try
            {
                StreamWriter filewriter = new StreamWriter(@configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename);
                while (!proc.StandardOutput.EndOfStream)
                {
                    filewriter.WriteLine(proc.StandardOutput.ReadLine());
                }
                filewriter.Close();
                result.mysqlbinlogexeStandardError = "";
                while (!proc.StandardError.EndOfStream)
                {
                    result.mysqlbinlogexeStandardError += proc.StandardError.ReadLine() + "\n";
                }
                result.mysqlbinlogexeStandardError = result.mysqlbinlogexeStandardError.Replace("Warning: Using a password on the command line interface can be insecure.\n", "");
                Console.WriteLine(result.mysqlbinlogexeStandardError); //for testing

                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                File.Delete(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename);
            }

            if (proc == null || proc.ExitCode != 0)
            {
                result.wasSuccessful = false;
                result.errorNumber = -2;
                if (proc == null)
                {
                    result.mysqlbinlogexeStandardError = "MySQL binlog proccess was killed.";
                }
                File.Delete(configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename);
            }
            else
            {
                result.wasSuccessful = true;
                result.fileAbsPath = configurationManagerInstance.mysqlDumpConfigInstance.tempSavePath + filename;

                //compression
                if (configurationManagerInstance.compressConfigInstance.enableCompression)
                {
                    comp = new Compression();

                    comp.absolutePath = result.fileAbsPath;
                    comp.CompressProgress += onCompressProgressHandler;
                    comp.CompressStart += onCompressStartHandler;

                    CompressionResultSet compResult = comp.doCompress7z(); //edw kaleitai to compression

                    if (!compResult.wasSucessful)
                    {
                        result.wasSuccessful = false;
                        result.errorNumber = -3;
                        result.mysqlbinlogexeStandardError = compResult.standardError;
                    }
                    File.Delete(result.fileAbsPath); //delete to sketo .sql
                    result.fileAbsPath = compResult.resultAbsPath;
                }
            }
            result.incrementalFormatPrefix = config.prefix;
            return result;
        }

        private void onCompressProgressHandler(int progress)
        {
            onCompressProgress(progress);
        }

        private void onCompressStartHandler()
        {
            onCompressStart();
        }

        public void cancelBinlogDumpProcess()
        {
            try
            {
                if (comp != null)
                {
                    comp.KillProc();
                }
                proc.Kill();
                proc.Dispose();
                proc = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private StringBuilder calculateArguments()
        {
            StringBuilder arguments = new StringBuilder();
            performChecks();
            if (!result.wasSuccessful)
            {
                return arguments;
            }
            //-R -h localhost -u root -p --skip-gtids -d "anime" DESKTOP-5TEPA4J-bin.000003
            arguments.Append("-R ");
            arguments.Append(" -h "+config.host);
            arguments.Append(" -u "+config.username);
            arguments.Append(" -p"+config.password);
            arguments.Append(" -d "+config.database);
            arguments.Append(" --start-datetime=\""+config.startDateTime+"\"");

            //last
            arguments.Append(" ");
            foreach (string fname in config.logfiles)
            {
                arguments.Append(fname+" ");
            }
            Console.WriteLine(arguments.ToString());

            return arguments;
        }

        private void performChecks()
        {
            
            if (config.locationIds?.Length == 0)
            {
                result.wasSuccessful = false;
                result.errorNumber = -2;
                result.errorMessage = "No save location set.";
                return;
            }

            IncrementalUtils iutils = new IncrementalUtils(config);
            config = iutils.calculateDumpConfig();
            if (config.logfiles?.Length == 0)
            {
                result.wasSuccessful = false;
                result.errorNumber = -2;
                result.errorMessage = "Binary log file names on server not set.";
                return;
            }
            if (config.prefix.StartsWith("FB_0.0.0"))
            {
                result.wasSuccessful = false;
                result.errorNumber = -2;
                result.errorMessage = "No previous backups found in save locations. Unable to execute incremental backup.";
                return;
            }
        }
    }
}
