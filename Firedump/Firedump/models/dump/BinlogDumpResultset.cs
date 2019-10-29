using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class BinlogDumpResultset
    {
        /// <summary>
        /// wether the dump was successful or not
        /// </summary>
        public bool wasSuccessful { set; get; }
        /// <summary>
        /// absolute path of the temporal dump file (use if the dump was successful to get the path to the saved file)
        /// </summary>
        public string fileAbsPath { set; get; }
        /// <summary>
        /// The incremental prefix for the filename
        /// example: FB_1.0.0_date || IB_1.2.0 || IDB_1.2.5
        /// </summary>
        public string incrementalFormatPrefix { set; get; }
        /// <summary>
        /// -1 - obvious mistake in credentials (Message in errorMessage). -2 - mysqldump.exe exited with exit
        /// code diffent from 0 (use mysqldumpexeStandardError). -3 compression failed mysqldumpexeStandardError
        /// has the compression standardError output
        /// </summary>
        public int errorNumber { set; get; }
        /// <summary>
        /// The error message (use if errorNumber is -1)
        /// </summary>
        public string errorMessage { set; get; }
        /// <summary>
        /// standard error of mysqldump.exe (use if errorNumber is -2)
        /// </summary>
        public string mysqlbinlogexeStandardError { set; get; }

        public BinlogDumpResultset() { }


        public override string ToString()
        {
            return "wasSuccessful:" + wasSuccessful + ",fileAbsPath:" + fileAbsPath + ",errorNumber:" + errorNumber
                + ",errorMessage" + errorMessage + ",mysqldumpexeStandardError:" + mysqlbinlogexeStandardError;
        }
    }
}
