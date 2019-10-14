using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    public class FTPCredentialsConfig : LocationCredentialsConfig
    {
        public Int64 id { set; get; }
        public bool useSFTP { set; get; }
        public string SshHostKeyFingerprint { set; get; }
        /// <summary>
        /// Use private key for SFTP login (useSFTP must be true or this is disregarded)
        /// If used privateKeyPath must also be set
        /// </summary>
        public bool usePrivateKey { set; get; }
        /// <summary>
        /// The path to the private key file
        /// </summary>
        public string privateKeyPath { set; get; }
    }
}
