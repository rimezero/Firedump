using Firedump.models.configuration.dynamicconfig;
using Firedump.models.databaseUtils;
using Firedump.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class IncrementalUtils
    {
        private BinlogDumpCredentialsConfig config;
        private int[] locationIds;
        public IncrementalUtils() { }
        public IncrementalUtils(BinlogDumpCredentialsConfig config)
        {
            this.config = config;
            this.locationIds = config.locationIds;
        }
        public IncrementalUtils(int[] locationIds)
        {
            this.locationIds = locationIds;
        }

        public BinlogDumpCredentialsConfig calculateDumpConfig()
        {
            BinlogDumpCredentialsConfig retConfig = config;
            //<binarylognames>
            MySQLCredentialsConfig myconfig = new MySQLCredentialsConfig();
            myconfig.host = config.host;
            myconfig.port = config.port;
            myconfig.username = config.username;
            myconfig.password = config.password;
            myconfig.database = config.database;
            DbConnection dbcon = new DbConnection(myconfig);
            retConfig.logfiles = dbcon.getBinlogfilenames().ToArray();
            //</binarylognames>
            int bpType = 1;
            if (retConfig.isIncrementalDelta)
            {
                bpType = 2;
            }
            string[] res = calculatePrefix(bpType);
            retConfig.prefix = res[1];
            retConfig.startDateTime = res[0].Replace(',',':'); //replacing : because it is invalid in filenames
            //retConfig.prefix += "_" + dbcon.getCurrentDatetime().Replace(':',',');
            return retConfig;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bpType">0 = Full Backup 1 = Incremental Backup 2 = Incremental Delta</param>
        /// <returns></returns>
        public string[] calculatePrefix(int bpType)
        {
            string prefix="";
            //<filename_prefix>
            firedumpdbDataSetTableAdapters.backup_locationsTableAdapter adapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            List<firedumpdbDataSet.backup_locationsRow> locations = new List<firedumpdbDataSet.backup_locationsRow>();
            foreach (int id in locationIds)
            {
                locations.Add(adapter.GetDataByID(id)[0]);
            }

            int index = -1;
            int j = 0;
            while (index == -1 && j < locations.Count())
            {
                if (locations[j].service_type == 0)
                {
                    index = j;
                }
            }

            List<string[]> splitBpFnames = new List<string[]>();
            if (index == -1)
            {
                //periptwsi p den iparxei save location local fix argotera
                string path = locations[0].path; //dialegw tixea to prwto location
                string[] splitpath = StringUtils.splitPath(path);
                List<string> fnames = new List<string>();
                //edw ftp directory listing
            }
            else
            {
                string path = locations[index].path;   
                string[] splitpath = StringUtils.splitPath(path);
                List<string> fnames = new List<string>();
                foreach (string fname in Directory.GetFiles(splitpath[0]))
                {
                    fnames.Add(fname.Replace(splitpath[0], ""));
                }
                splitBpFnames = getSplitBpFnames(fnames, splitpath[1]);
                
                //Console.WriteLine("path "+splitpath[0]);
                //Console.WriteLine("filename " + splitpath[1]);
            }
            string[] res = new string[2];
            if (splitBpFnames.Count() > 0)
            {
                res = findNext(splitBpFnames, bpType);
                prefix += res[1];
            }
            else
            {
                prefix += "FB_0.0.0";
            }

            MySQLCredentialsConfig myconfig = new MySQLCredentialsConfig();
            myconfig.host = config.host;
            myconfig.port = config.port;
            myconfig.username = config.username;
            myconfig.password = config.password;
            myconfig.database = config.database;
            DbConnection dbcon = new DbConnection(myconfig);
            prefix += "_" + dbcon.getCurrentDatetime().Replace(':', ',');
            //prefix += "_" + DateTime.Now.ToString("yyyy-M-d hh:mm:ss"); has to come from the mysql server
            //calculate datetime and add it to prefix in binlog required format

            //</filename_prefix>

            res[1] = prefix;
            return res;
        }

        private List<string[]> getSplitBpFnames(List<string> fnames, string splitName)
        {  
            List<string> backupFiles = new List<string>();
            foreach (string fname in fnames)
            {
                if (fname.Contains(splitName) && fname.Contains("_"))
                {
                    backupFiles.Add(fname);
                }
                //Console.WriteLine(fname);
            }
            List<string[]> splitBpFnames = new List<string[]>();
            foreach (string fname in backupFiles)
            {
                splitBpFnames.Add(fname.Split('_'));
            }
            
            return splitBpFnames;
        }

        private string[] findNext(List<string[]> splitBpFnames, int bpType)
        {
            string[] restable = new string[2];
            string nextprefix = "";
            List<string> bpIndexes = new List<string>();
            foreach (string[] splitBpFname in splitBpFnames)
            {
                if (splitBpFname.Length == 4)
                {
                    bpIndexes.Add(splitBpFname[2]);
                }
            }
            List<string[]> splitIndexes = new List<string[]>();
            foreach (string bpIndex in bpIndexes)
            {
                splitIndexes.Add(bpIndex.Split('.'));
            }
            int maxindex = 0;
            int maxfullindex = 0;
            if (splitIndexes.Count()>1)
            {
                for (int i = 1; i < splitIndexes.Count(); i++)
                {
                    int indexMaxA = Convert.ToInt32(splitIndexes[maxindex][0]);
                    int indexMaxB = Convert.ToInt32(splitIndexes[maxindex][1]);
                    int indexMaxC = Convert.ToInt32(splitIndexes[maxindex][2]);

                    int indexCurrA = Convert.ToInt32(splitIndexes[i][0]);
                    int indexCurrB = Convert.ToInt32(splitIndexes[i][1]);
                    int indexCurrC = Convert.ToInt32(splitIndexes[i][2]);

                    //find previous full backup
                    int indexMaxFullA = Convert.ToInt32(splitIndexes[maxfullindex][0]);
                    if (indexCurrB==0 && indexCurrC == 0)
                    {
                        if (indexCurrA>indexMaxFullA)
                        {
                            maxfullindex = i;
                        }
                        if (splitIndexes[maxfullindex][1]!="0" || splitIndexes[maxfullindex][2]!="0")
                        {
                            maxfullindex = i;
                        }
                    }

                    if (indexCurrA>indexMaxA)
                    {
                        maxindex = i;
                    }else if (indexCurrA==indexMaxA)
                    {
                        if (indexCurrB>indexMaxB)
                        {
                            maxindex = i;
                        }else if (indexCurrB==indexMaxB)
                        {
                            if (indexCurrC>indexMaxC)
                            {
                                maxindex = i;
                            }
                        }
                    }
                }
            }

            int iMaxA = Convert.ToInt32(splitIndexes[maxindex][0]);
            int iMaxB = Convert.ToInt32(splitIndexes[maxindex][1]);
            int iMaxC = Convert.ToInt32(splitIndexes[maxindex][2]);
            restable[0] = splitBpFnames[maxindex][3].Split('.')[0];
            switch (bpType)
            {
                case 0:
                    iMaxA++;
                    nextprefix = "FB_"+ iMaxA + ".0.0";
                    break;
                case 1:
                    iMaxB++;
                    restable[0] = splitBpFnames[maxfullindex][3].Split('.')[0];
                    nextprefix = "IB_" + iMaxA + "." + iMaxB + ".0";
                    break;
                case 2:
                    iMaxC++;
                    nextprefix = "IDB_" + iMaxA + "." + iMaxB + "." + iMaxC;
                    break;
                default:

                    break;
            }
            
            restable[1] = nextprefix;
            return restable;
        }

        /// <summary>
        /// Logic that calculates filename chains for incremental backups
        /// </summary>
        /// <param name="filename">The name of the backup file</param>
        /// <returns>A list of the filenames in the restore chain or error for first element and a message for second</returns>
        public List<string> calculateChain(string filename)
        {
            List<string> filesChain = new List<string>();

            return filesChain;
        }
    }
}
