using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    public class MySQLCredentialsConfig : CredentialsConfig
    {
        public string database { set; get; }
    }
}
