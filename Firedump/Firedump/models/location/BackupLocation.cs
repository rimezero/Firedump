using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    public class BackupLocation
    {
        public int id { set; get; }
        public string path { set; get; }

        public object Tag { get; set; }

        public BackupLocation() { }
        public override bool Equals(object obj) //dokimasa na kanw impement to equitable kai to icomparable alla gia kapoio logo mono me override doulepse
        {
            try
            {
                return this.id == ((BackupLocation)obj).id;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
