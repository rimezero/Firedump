using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;
using Firedump.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class Compression
    {
        private static readonly string BUILD_SERVER_ZIP_PATH32 = "C:\\jenkins\\resources\\7z\\7z.exe";
        private static readonly string BUILD_SERVER_ZIP_PATH64 = "C:\\jenkins\\resources\\7z64\\7z.exe";
        public bool IsTest { get; set; }

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
        private Process proc;
        private string fileType;

        /// <summary>
        /// Absolute path of the file to compress
        /// </summary>
        public string absolutePath { set; get; }
        public CompressionConfig config { set; get; }

        public Compression() { }

        public Compression(string absolutePath)
        {
            this.absolutePath = absolutePath;
        }

        public Compression(CompressionConfig config)
        {
            this.config = config;
        }

        private StringBuilder calculateArguments()
        {
            StringBuilder arguments = new StringBuilder();
            arguments.Append("a -bsp1 ");

            //security
            if (configurationManagerInstance.compressConfigInstance.enablePasswordEncryption)
            {
                if (configurationManagerInstance.compressConfigInstance.encryptHeader)
                {
                    arguments.Append("-mhe=on ");
                }
                if (!string.IsNullOrEmpty(configurationManagerInstance.compressConfigInstance.password))
                {
                    if (configurationManagerInstance.compressConfigInstance.fileType != 0)
                    {
                        arguments.Append("-mem=AES256 ");
                    }
                    arguments.Append("-p" + configurationManagerInstance.compressConfigInstance.password + " ");
                }
            }

            //compression level
            switch (configurationManagerInstance.compressConfigInstance.compressionLevel)
            {
                case 0:
                    arguments.Append("-mx1 ");
                    break;
                case 1:
                    arguments.Append("-mx3 ");
                    break;
                case 2:
                    arguments.Append("-mx5 ");
                    break;
                case 3:
                    arguments.Append("-mx7 ");
                    break;
                case 4:
                    arguments.Append("-mx9 ");
                    break;
                default:
                    arguments.Append("-mx9 ");
                    break;
            }

            //enable multithreading
            if (configurationManagerInstance.compressConfigInstance.useMultithreading)
            {
                arguments.Append("-mmt ");
            }

            //filetype
            switch (configurationManagerInstance.compressConfigInstance.fileType)
            {
                case 0:
                    arguments.Append("-t7z ");
                    fileType = ".7z";
                    break;
                case 1:
                    arguments.Append("-tgzip ");
                    fileType = ".gzip";
                    break;
                case 2:
                    arguments.Append("-tzip ");
                    fileType = ".zip";
                    break;
                case 3:
                    arguments.Append("-tbzip2 ");
                    fileType = ".bzip2";
                    break;
                case 4:
                    arguments.Append("-ttar ");
                    fileType = ".tar";
                    break;
                case 5:
                    arguments.Append("-tiso ");
                    fileType = ".iso";
                    break;
                case 6:
                    arguments.Append("-tudf ");
                    fileType = ".udf";
                    break;
                default:
                    arguments.Append("-tzip ");
                    fileType = ".zip";
                    break;
            }

            //setting filenames
            if (configurationManagerInstance.mysqlDumpConfigInstance.xml)
            {
                arguments.Append("\"" + absolutePath.Replace(".xml", fileType) + "\" ");
            }
            else
            {
                arguments.Append("\"" + absolutePath.Replace(".sql", fileType) + "\" ");
            }

            arguments.Append("\"" + absolutePath + "\"");

            return arguments;
        }

        private StringBuilder calculateArgumentsDecompress()
        {
            StringBuilder arguments = new StringBuilder();
            arguments.Append("x -bsp1 ");
            arguments.Append("\""+config.absolutePath + "\" ");
            arguments.Append("-o\""+config.decompressDirectory+"\" ");
            if (config.isEncrypted)
            {
                arguments.Append("-p"+config.password);
            }
            return arguments;
        }

        public CompressionResultSet doCompress7z()
        {

            StringBuilder arguments = calculateArguments();
            Console.WriteLine("Compression7z arguments: "+arguments.ToString());

            string f7zip = "resources\\7z64\\7z.exe";
            if (IsTest)
            {
                if (OS.IsWindowsServer())
                    f7zip = BUILD_SERVER_ZIP_PATH64;
            }
              
            if (configurationManagerInstance.compressConfigInstance.use32bit)
            {
                f7zip = "resources\\7z\\7z.exe";
                if (IsTest)
                {
                    if (OS.IsWindowsServer())
                        f7zip = BUILD_SERVER_ZIP_PATH32;
                }                    
            }

            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = f7zip,
                    Arguments = arguments.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            Console.WriteLine("Executing 7zip now.");
            CompressionResultSet result = new CompressionResultSet();
            proc.Start();

            onCompressStart();

            try
            {
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    Console.WriteLine("Comp:" + line);


                    if (line.Contains("%"))
                    {
                        int per = 0;
                        int.TryParse(line.Substring(0, 3), out per);
                        onCompressProgress(per);
                    }


                }

                while (!proc.StandardError.EndOfStream)
                {
                    string line = proc.StandardError.ReadLine();
                    result.standardError += line + "\n";
                    Console.WriteLine(line);
                }

                proc.WaitForExit();
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("Compression null reference exception on proccess: " + ex.Message);
                File.Delete(absolutePath);
                File.Delete(absolutePath.Replace(".sql", fileType));
            }

            if(proc==null || proc.ExitCode!=0)
            {
                result.wasSucessful = false;
                if(proc == null)
                {
                    result.standardError = "Compression proccess was killed.";
                }
                //delete
                File.Delete(absolutePath);
                File.Delete(absolutePath.Replace(".sql", fileType));
            }
            else
            {
                result.wasSucessful = true;
            }

            result.resultAbsPath = absolutePath.Replace(".sql", fileType);

            return result;
        }

        public CompressionResultSet decompress7z()
        {
            StringBuilder arguments = calculateArgumentsDecompress();
            Console.WriteLine("Compression7z arguments: " + arguments.ToString());

            Directory.CreateDirectory(config.decompressDirectory);

            string f7zip = "resources\\7z64\\7z.exe";
            if (IsTest)
            {
                if (OS.IsWindowsServer())
                    f7zip = BUILD_SERVER_ZIP_PATH64;
            }

            if (configurationManagerInstance.compressConfigInstance.use32bit)
            {
                f7zip = "resources\\7z\\7z.exe";
                if (IsTest)
                {
                    if (OS.IsWindowsServer())
                        f7zip = BUILD_SERVER_ZIP_PATH32;
                }
            }

            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = f7zip,
                    Arguments = arguments.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                }
            };
            Console.WriteLine("Executing 7zip now.");
            CompressionResultSet result = new CompressionResultSet();
            proc.Start();
            

            onCompressStart();

            try
            {
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    Console.WriteLine("Comp:" + line);


                    if (line.Contains("%"))
                    {
                        int per = 0;
                        int.TryParse(line.Substring(0, 3), out per);
                        onCompressProgress(per);
                    }


                }

                while (!proc.StandardError.EndOfStream)
                {
                    string line = proc.StandardError.ReadLine();
                    result.standardError += line + "\n";
                    Console.WriteLine(line);
                }

                proc.WaitForExit();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Compression null reference exception on proccess: " + ex.Message);
                File.Delete(config.absolutePath);
                Directory.Delete(config.decompressDirectory, true);
            }

            if (proc == null || proc.ExitCode != 0)
            {
                result.wasSucessful = false;
                if (proc == null)
                {
                    result.standardError = "Compression proccess was killed.";
                }
                //delete
                File.Delete(config.absolutePath);
                Directory.Delete(config.decompressDirectory, true);
            }
            else
            {
                result.wasSucessful = true;
            }

            return result;
        }

        public void KillProc()
        {
            try
            {
                proc.Kill();
                proc.Close();
                proc = null;
            } catch(Exception ex)
            {

            }
        }


    }
}
