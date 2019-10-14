using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models
{
    public class ServiceType
    {
        public enum Type
        {
            Local = 0,
            Ftp = 1,
            DropBox = 2,
            GoogleDrive = 3
        };
    }
}
