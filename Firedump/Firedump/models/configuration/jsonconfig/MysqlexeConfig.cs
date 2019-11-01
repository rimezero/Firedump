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
    public class MysqlexeConfig : ConfigurationClass<MysqlexeConfig>
    {
        private readonly string jsonFilePath = "./config/MysqlexeConfig.json";

        //<configuration fields section>

        //</configuration fields section>

        private static MysqlexeConfig mysqlexeConfigInstance;
        
        private MysqlexeConfig() { }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static MysqlexeConfig getInstance()
        {
            if (mysqlexeConfigInstance == null)
            {
                mysqlexeConfigInstance = new MysqlexeConfig();
            }
            return mysqlexeConfigInstance;
        }

        public MysqlexeConfig initializeConfig()
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                mysqlexeConfigInstance = JsonConvert.DeserializeObject<MysqlexeConfig>(json);
                return mysqlexeConfigInstance;
            }
            catch (Exception ex)
            {
                mysqlexeConfigInstance = new MysqlexeConfig(); //resetarei sta default options giati mporei apo panw na exoun allaksei kapoia se periptwsi corrupted data
                mysqlexeConfigInstance.saveConfig();
                if (!(ex is FileNotFoundException || ex is JsonException || ex is RuntimeBinderException))
                {
                    Console.WriteLine("MysqlexeConfig.initializeConfig(): " + ex.ToString());
                }
                return mysqlexeConfigInstance; //never reached just to avoid error message
            }
        }

        public MysqlexeConfig resetToDefaults()
        {
            mysqlexeConfigInstance = new MysqlexeConfig();
            mysqlexeConfigInstance.saveConfig();
            return mysqlexeConfigInstance;
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
