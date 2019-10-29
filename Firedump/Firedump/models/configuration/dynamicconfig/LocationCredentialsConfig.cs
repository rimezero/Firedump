using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    public class LocationCredentialsConfig : CredentialsConfig
    {
        public string sourcePath { set; get; }
        public string locationPath { set; get; }
        public string fnamePrefix { set; get; }
    }
}
