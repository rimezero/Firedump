using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class CompressionResultSet
    {
        public bool wasSucessful { set; get; }
        public string resultAbsPath { set; get; }
        public string standardError { set; get; }
    }
}
