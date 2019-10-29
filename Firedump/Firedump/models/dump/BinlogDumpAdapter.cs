using Firedump.models.configuration.dynamicconfig;
using Firedump.models.databaseUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class BinlogDumpAdapter
    {
        //<events>

        //onProgress
        public delegate void progress(string progress);
        public event progress Progress;
        private void onProgress(string progress)
        {
            Progress?.Invoke(progress);
        }

        //onError
        public delegate void error(int error);
        public event error Error;
        private void onError(int error)
        {
            Error?.Invoke(error);
        }

        //onCancel
        public delegate void cancelled();
        public event cancelled Cancelled;
        private void onCancelled()
        {
            Cancelled?.Invoke();
        }

        //onCompleted
        public delegate void completed(BinlogDumpResultset status);
        public event completed Completed;
        private void onCompleted(BinlogDumpResultset status)
        {
            Completed?.Invoke(status);
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

        private BinlogDump dumpInstance;
        public BinlogDumpCredentialsConfig config { set; get; }
        public BinlogDumpAdapter() { }
        public BinlogDumpAdapter(BinlogDumpCredentialsConfig config)
        {
            this.config = config;
        }

        public void startDump()
        {
            onProgress("Binary log dump initiated.");
            if (config==null)
            {
                onError(-2);
                return;
            }
            Task mysqldumpTask = new Task(dumpExecutor);
            mysqldumpTask.Start();
        }

        private async void dumpExecutor()
        {
            
            MySQLCredentialsConfig cnf = new MySQLCredentialsConfig();
            cnf.host = config.host;
            cnf.port = config.port;
            cnf.username = config.username;
            cnf.password = config.password;
            cnf.database = config.database;
            DbConnection con = new DbConnection(cnf);
            if (!con.testConnection().wasSuccessful)
            {
                onError(-1);
                return;
            }
            onProgress("Dumping from binary logs...");
            dumpInstance = new BinlogDump();
            dumpInstance.config = config;
            dumpInstance.CompressStart += onCompressStartHandler;
            dumpInstance.CompressProgress += onCompressProgressHandler;

            BinlogDumpResultset result = dumpInstance.executeDump();
            onCompleted(result);
            dumpInstance = null;
        }

        internal void cancelDump()
        {
            if (dumpInstance != null)
            {
                dumpInstance.cancelBinlogDumpProcess();
                dumpInstance = null;
            }
        }

        public bool isDumpRunning()
        {
            return dumpInstance != null;
        }

        private void onCompressProgressHandler(int progress)
        {
            onCompressProgress(progress);
        }

        private void onCompressStartHandler()
        {
            onCompressStart();
        }
    }
}
