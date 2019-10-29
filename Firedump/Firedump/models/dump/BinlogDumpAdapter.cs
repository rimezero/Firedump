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
        public delegate void completed(DumpResultSet status);
        public event completed Completed;
        private void onCompleted(DumpResultSet status)
        {
            Completed?.Invoke(status);
        }

        //onTableRowCount
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
    }
}
