using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.jsonconfig
{
    public interface ConfigurationClass<T>
    {
        T initializeConfig();
        void saveConfig();
        T resetToDefaults();
    }
}
