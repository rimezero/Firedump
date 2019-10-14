using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    public class LocationResultSet
    {
        public bool wasSuccessful { set; get; }
        public string path { set; get; }
        public string errorMessage { set; get; }
        public LocationResultSet() { } 
    }
}
