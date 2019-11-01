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
    public class CompressConfig : ConfigurationClass<CompressConfig>
    {
        private readonly string jsonFilePath = "./config/CompressConfig.json";

        //<!configuration fields section>
        /// <summary>
        /// Enables compression after dump
        /// </summary>
        public bool enableCompression { set; get; } 
        /// <summary>
        /// false - use .NET 4.5 native compression
        /// true - use 7zip
        /// </summary>
        public bool use7zip { set; get; } = true;

        //<7zip configuration>
        /// <summary>
        /// If true run 32 bit 7zip otherwise run 64 bit
        /// </summary>
        public bool use32bit { set; get; }
        /// <summary>
        /// 0 - -mx1 : Low compression faster proccess
        /// 1 - -mx3 : Fast compression mode
        /// 2 - -mx5 : Normal compression mode
        /// 3 - -mx7 : Maximum compression mode
        /// 4 - -mx9 : Ultra compression mode
        /// </summary>
        public int compressionLevel { set; get; } = 4;
        /// <summary>
        /// Uses multithreading to zip faster (use if you have quad core procressor) -mmt
        /// </summary>
        public bool useMultithreading { set; get; } = true;
        /// <summary>
        /// 0 - -t7z : file.7z
        /// 1 - -tgzip : file.gzip
        /// 2 - -tzip : file.zip
        /// 3 - -tbzip2 : file.bzip2
        /// 4 - -ttar : file.tar (UNIX and LINUX)
        /// 5 - -tiso : file.iso
        /// 6 - -tudf : file.udf
        /// </summary>
        public int fileType { set; get; } = 0;

        //security
        /// <summary>
        /// Enable/disable password encryption
        /// </summary>
        public bool enablePasswordEncryption { set; get; }
        /// <summary>
        /// Password to encrypt with
        /// </summary>
        public string password { set; get; }
        /// <summary>
        /// Hides file names in the password protected archive
        /// Password must be enabled and only works for .7z type
        /// </summary>
        public bool encryptHeader { set; get; }

        //</7zip configuration>

        //</configuration fields section>

        private static CompressConfig compressConfigInstance;
        private CompressConfig() { }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CompressConfig getInstance()
        {
            if (compressConfigInstance == null)
            {
                compressConfigInstance = new CompressConfig();
            }
            return compressConfigInstance;
        }

        public CompressConfig initializeConfig()
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                compressConfigInstance = JsonConvert.DeserializeObject<CompressConfig>(json);
                return compressConfigInstance;
            }
            catch (Exception ex)
            {
                compressConfigInstance = new CompressConfig(); //resetarei sta default options giati mporei apo panw na exoun allaksei kapoia se periptwsi corrupted data
                compressConfigInstance.saveConfig();
                if (!(ex is FileNotFoundException || ex is JsonException || ex is RuntimeBinderException))
                {
                    Console.WriteLine("MySqlDumpConfig.initializeConfig(): " + ex.ToString());
                }
                return compressConfigInstance; //never reached just to avoid error message    
            }
        }
        public void saveConfig()
        {
            if (!use32bit)
            {
                if (!Environment.Is64BitOperatingSystem)
                {
                    use32bit = true;
                }
            }
            string jsonOutput = JsonConvert.SerializeObject(this, Formatting.Indented);
            FileInfo file = new FileInfo(jsonFilePath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllText(file.FullName, jsonOutput);
        }

        public CompressConfig resetToDefaults()
        {
            compressConfigInstance = new CompressConfig();
            compressConfigInstance.saveConfig();
            return compressConfigInstance;
        }
    }
}
