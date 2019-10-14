using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.sqlimport
{
    public class ImportResultSet
    {
        public bool wasSuccessful { set; get; }
        public string errorMessage { set; get; }
    }
}
