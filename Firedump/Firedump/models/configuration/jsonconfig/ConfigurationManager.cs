using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.jsonconfig
{
    public class ConfigurationManager : ConfigurationClass<ConfigurationManager>
    {
        public MySqlDumpConfig mysqlDumpConfigInstance { set; get; }
        public CompressConfig compressConfigInstance { set; get; }
        public BinlogConfig binlogConfigInstance { set; get; }
        public MysqlexeConfig mysqlexeConfigInstance { set; get; }
        private static ConfigurationManager configurationManagerInstance;
        private ConfigurationManager() { }

        [MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a ConfigurationManager instance with all configuration class instances set as fields of this instance</returns>
        public static ConfigurationManager getInstance()
        {
            if (configurationManagerInstance == null)
            {
                configurationManagerInstance = new ConfigurationManager();
            }
            return configurationManagerInstance;
        }

        /// <summary>
        /// Calls the initiallize methods of every configuration class.
        /// </summary>
        public ConfigurationManager initializeConfig()
        {
            this.mysqlDumpConfigInstance = MySqlDumpConfig.getInstance().initializeConfig();
            this.compressConfigInstance = CompressConfig.getInstance().initializeConfig();
            this.binlogConfigInstance = BinlogConfig.getInstance().initializeConfig();
            this.mysqlexeConfigInstance = MysqlexeConfig.getInstance().initializeConfig();
            return configurationManagerInstance;
        }

        /// <summary>
        /// Calls the save methods of every configuration class.
        /// IMPORTANT: initializeConfig must be called at least once before this method is called.
        /// </summary>
        public void saveConfig()
        {
            this.mysqlDumpConfigInstance.saveConfig();
            this.compressConfigInstance.saveConfig();
            this.binlogConfigInstance.saveConfig();
            this.mysqlexeConfigInstance.saveConfig();
        }

        public ConfigurationManager resetToDefaults()
        {
            this.mysqlDumpConfigInstance = MySqlDumpConfig.getInstance().resetToDefaults();
            this.compressConfigInstance = CompressConfig.getInstance().resetToDefaults();
            this.binlogConfigInstance = BinlogConfig.getInstance().resetToDefaults();
            this.mysqlexeConfigInstance = MysqlexeConfig.getInstance().resetToDefaults();
            return configurationManagerInstance;
        }
    }
}
