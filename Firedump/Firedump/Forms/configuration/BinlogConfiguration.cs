using Firedump.models.configuration.jsonconfig;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;

namespace Firedump.Forms.configuration
{
    public partial class BinlogConfiguration : Form
    {
        public BinlogConfiguration()
        {
            InitializeComponent();
        }

        private void BinlogConfiguration_Load(object sender, EventArgs e)
        {
            setupFormComponents();
        }

        private void setupFormComponents()
        {
            setupTooltips();

            BinlogConfig configInstance = ConfigurationManager.getInstance().binlogConfigInstance;

            //General
            tbCharacterSetsDir.Text = configInstance.characterSetsDir;
            tbExcludeGtids.Text = configInstance.excludeGtids;
            tbBindAdress.Text = configInstance.bindAdress;

            cmbBase64.DataSource = new string[] { "","uncompressed","auto","decode-rows" };
            if (string.IsNullOrWhiteSpace(configInstance.base64output))
            {
                cmbBase64.SelectedIndex = 0;
            }
            else
            {
                cmbBase64.SelectedIndex = cmbBase64.Items.IndexOf(configInstance.base64output);
                if (cmbBase64.SelectedIndex == -1)
                {
                    cmbBase64.SelectedIndex = 0;
                }
            }
            cmbCharset.DataSource = new string[] { "utf8", "armscii8","ascii", "cp850", "cp852", "cp866", "cp1250", "cp1251", "cp1256", "cp1257", "dec8", "geostd8", "greek", "hebrew", "hp8", "Index",
                "keybcs2", "koi8r", "koi8u", "latin1", "latin2", "latin5", "latin7", "macce", "macroman", "swe7" };
            if (string.IsNullOrWhiteSpace(configInstance.charsetName))
            {
                cmbCharset.SelectedIndex = 0;
            }
            else
            {
                cmbCharset.SelectedIndex = cmbCharset.Items.IndexOf(configInstance.charsetName);
                if (cmbCharset.SelectedIndex==-1)
                {
                    cmbCharset.SelectedIndex = 0;
                }
            }
            cmbCompressionAlgorithm.DataSource = new string[] { "", "uncompressed", "zlib", "zstd" };
            if (string.IsNullOrWhiteSpace(configInstance.compressionAlgorithms))
            {
                cmbCompressionAlgorithm.SelectedIndex = 0;
            }
            else
            {
                cmbCompressionAlgorithm.SelectedIndex = cmbCompressionAlgorithm.Items.IndexOf(configInstance.compressionAlgorithms);
                if (cmbCompressionAlgorithm.SelectedIndex == -1)
                {
                    cmbCompressionAlgorithm.SelectedIndex = 0;
                }
            }
            cmbProtocol.DataSource = new string[] {"tcp", "socket", "pipe","memory" };
            if (string.IsNullOrWhiteSpace(configInstance.protocol))
            {
                cmbProtocol.SelectedIndex = 0;
            }
            else
            {
                cmbProtocol.SelectedIndex = cmbProtocol.Items.IndexOf(configInstance.protocol);
                if (cmbProtocol.SelectedIndex == -1)
                {
                    cmbProtocol.SelectedIndex = 0;
                }
            }

            if (!string.IsNullOrWhiteSpace(configInstance.rewriteDb) && configInstance.rewriteDb.Contains("->"))
            {
                string[] splitRewritedb = configInstance.rewriteDb.Split(new string[] { "->" }, StringSplitOptions.None);
                if (splitRewritedb.Length==2)
                {
                    tbRewriteFrom.Text = splitRewritedb[0];
                    tbRewriteTo.Text = splitRewritedb[1];
                }
            }

            if (configInstance.conServerId!=0)
            {
                tbConServerId.Text = configInstance.conServerId.ToString();
            }
            if (configInstance.serverId != -1)
            {
                tbServerId.Text = configInstance.serverId.ToString();
            }
            if (configInstance.rowEventMaxSize!=0)
            {
                tbRowEventMaxSize.Text = configInstance.rowEventMaxSize.ToString();
            }

            cbDisableBinaryLogging.Checked = configInstance.disableLogBin;
            cbForceIfOpen.Checked = configInstance.forceIfOpen;
            cbForceRead.Checked = configInstance.forceRead;
            cbGetServerPublicKey.Checked = configInstance.getServerPublicKey;
            cbIdempotent.Checked = configInstance.idempotent;
            cbRaw.Checked = configInstance.raw;
            cbSkipGtids.Checked = configInstance.skipGtids;
            cbServerTime.Checked = configInstance.useServerTime;

            //Debug
            tbDebugOptions.Text = configInstance.debugOptions;

            cbDebugCheck.Checked = configInstance.debugCheck;
            cbDebugInfo.Checked = configInstance.debugInfo;
            cbHexdump.Checked = configInstance.hexdump;
            cbPrintDefaults.Checked = configInstance.printDefaults;
            cbPrintTableMetadata.Checked = configInstance.printTableMetadata;
            cbVerbose.Checked = configInstance.verbose;
        }

        private void bCharsetDir_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            cofd.InitialDirectory = tbCharacterSetsDir.Text;  
            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tbCharacterSetsDir.Text = cofd.FileName;
            }          
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            BinlogConfig configInstance = ConfigurationManager.getInstance().binlogConfigInstance;
            //add some extra checks in here later
            /*
            MessageBox.Show("Header encryption only works with .7z file format. Switch to .7z format or disable header encryption.",
                        "Header Encryption", MessageBoxButtons.OK, MessageBoxIcon.Error);*/

            //checks
            int conServerId = 0;
            int serverId = -1;
            long rowEventMaxSize = 0;
            if ((!string.IsNullOrWhiteSpace(tbRewriteFrom.Text) && string.IsNullOrWhiteSpace(tbRewriteTo.Text)) || (string.IsNullOrWhiteSpace(tbRewriteFrom.Text) && !string.IsNullOrWhiteSpace(tbRewriteTo.Text)))
            {
                MessageBox.Show("To rewrite database name both from and to fields must be set.",
                        "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbConServerId.Text))
            {
                try
                {
                    conServerId = Convert.ToInt32(tbConServerId.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The conncetion server id must be an integer.",
                        "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(tbServerId.Text))
            {
                try
                {
                    serverId = Convert.ToInt32(tbServerId.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The server id must be an integer.",
                        "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(tbRowEventMaxSize.Text))
            {
                try
                {
                    rowEventMaxSize = Convert.ToInt64(tbRowEventMaxSize.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The row event max size must be a long number.",
                        "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //checks

            configInstance.characterSetsDir = tbCharacterSetsDir.Text;
            configInstance.excludeGtids = tbExcludeGtids.Text;
            configInstance.bindAdress = tbBindAdress.Text;
            configInstance.base64output = cmbBase64.SelectedValue.ToString();
            configInstance.charsetName = cmbCharset.SelectedValue.ToString();
            configInstance.compressionAlgorithms = cmbCompressionAlgorithm.SelectedValue.ToString();
            configInstance.protocol = cmbProtocol.SelectedValue.ToString();
            if (!string.IsNullOrWhiteSpace(tbRewriteFrom.Text) && !string.IsNullOrWhiteSpace(tbRewriteTo.Text))
            {
                configInstance.rewriteDb = tbRewriteFrom.Text + "->" + tbRewriteTo.Text;
            }
            configInstance.conServerId = conServerId;
            configInstance.serverId = serverId;
            configInstance.rowEventMaxSize = rowEventMaxSize;
            configInstance.disableLogBin = cbDisableBinaryLogging.Checked;
            configInstance.forceIfOpen = cbForceIfOpen.Checked;
            configInstance.forceRead = cbForceRead.Checked;
            configInstance.getServerPublicKey = cbGetServerPublicKey.Checked;
            configInstance.idempotent = cbIdempotent.Checked;
            configInstance.raw = cbRaw.Checked;
            configInstance.skipGtids = cbSkipGtids.Checked;
            configInstance.useServerTime = cbServerTime.Checked;
            //debug
            configInstance.debugCheck = cbDebugCheck.Checked;
            configInstance.debugInfo = cbDebugInfo.Checked;
            configInstance.hexdump = cbHexdump.Checked;
            configInstance.printDefaults = cbPrintDefaults.Checked;
            configInstance.printTableMetadata = cbPrintTableMetadata.Checked;
            configInstance.verbose = cbVerbose.Checked;
            configInstance.debugOptions = tbDebugOptions.Text;

            configInstance.saveConfig();
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset the configuration to default values?","Configuration Reset",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                ConfigurationManager.getInstance().binlogConfigInstance = ConfigurationManager.getInstance().binlogConfigInstance.resetToDefaults();
                setupFormComponents();
            }
        }

        private void setupTooltips()
        {
            //tooltips
            tooltip1.SetToolTip(tbCharacterSetsDir, "" +
                "The permitted compression algorithms for connections to the server. \n" +
                "The available algorithms are the same as for the protocol_compression_algorithms\n" +
                "system variable. The default value is uncompressed.\n"+
                "valid values = zlib,zstd,uncompressed");
            tooltip1.SetToolTip(tbExcludeGtids, "Do not display any of the groups listed in the gtid_set.");
            tooltip1.SetToolTip(tbBindAdress, "0 disabled\n" +
                "Specify the maximum size of a row-based binary log event, in bytes.\n" +
                "Rows are grouped into events smaller than this size if possible. \n" +
                "The value should be a multiple of 256. The default is 4GB.");

            tooltip1.SetToolTip(cmbBase64, "" +
                "This option determines when events should be displayed encoded as base-64 strings\n" +
                " using BINLOG statements. The option has these permissible values (not case-sensitive):\n"+
         "AUTO - ('automatic') or UNSPEC ('unspecified') displays BINLOG statements automatically\n" +
         " when necessary (that is, for format description events and row events).\n" +
         " If no --base64-output option is given, the effect is the same as --base64-output=AUTO.\n"+
         "NEVER - causes BINLOG statements not to be displayed. mysqlbinlog exits with an error\n" +
         " if a row event is found that must be displayed using BINLOG.\n"+
         "DECODE-ROWS - specifies to mysqlbinlog that you intend for row events to be decoded and \n" +
         "displayed as commented SQL statements by also specifying the --verbose option");
            tooltip1.SetToolTip(cmbCharset, "" +
                "Add a SET NAMES charset_name statement to the output to specify\n" +
                "the character set to be used for processing log files.");
            tooltip1.SetToolTip(cmbCompressionAlgorithm, "For now if either zlib or zstd is selected it uses the default 'n" +
                "--compress option");
            tooltip1.SetToolTip(cmbProtocol, "" +
                "The connection protocol to use for connecting to the server.\n" +
                "It is useful when the other connection parameters normally \n" +
                "result in use of a protocol other than the one you want.");

            tooltip1.SetToolTip(tbRewriteFrom, "The initial database name");
            tooltip1.SetToolTip(tbRewriteTo, "The name to change to in the result dump file");

            tooltip1.SetToolTip(tbConServerId, "0 disabled\n" +
                "--connection-server-id specifies the server ID that mysqlbinlog reports when it connects to the server.\n" +
                "It can be used to avoid a conflict with the ID of a slave server or another mysqlbinlog process.");
            tooltip1.SetToolTip(tbServerId, "Display only those events created by the server having the given server ID.");
            tooltip1.SetToolTip(tbRowEventMaxSize, "The directory where character sets are installed (On the server).");

            tooltip1.SetToolTip(cbDisableBinaryLogging, "" +
                "Disable binary logging. This is useful for avoiding an endless loop if you use\n" +
                "the --to-last-log option and are sending the output to the same MySQL server.\n" +
                "This option also is useful when restoring after a crash to avoid duplication\n" +
                "of the statements you have logged.");
            tooltip1.SetToolTip(cbForceIfOpen, "Read binary log files even if they are open or were not closed properly.");
            tooltip1.SetToolTip(cbForceRead, "" +
                "With this option, if mysqlbinlog reads a binary log event that it does not recognize,\n" +
                "it prints a warning, ignores the event, and continues. Without this option,\n" +
                "mysqlbinlog stops if it reads such an event.");
            tooltip1.SetToolTip(cbGetServerPublicKey, "" +
                "Request from the server the public key required for RSA key pair-based password exchange.\n" +
                "This option applies to clients that authenticate with the caching_sha2_password authentication plugin.\n" +
                "For that plugin, the server does not send the public key unless requested.\n" +
                "This option is ignored for accounts that do not authenticate with that plugin.\n" +
                "It is also ignored if RSA-based password exchange is not used, as is the case when\n" +
                "the client connects to the server using a secure connection.");
            tooltip1.SetToolTip(cbIdempotent, "" +
                "Tell the MySQL Server to use idempotent mode while processing updates;\n" +
                "this causes suppression of any duplicate-key or key-not-found errors that\n" +
                "the server encounters in the current session while processing updates.\n" +
                "This option may prove useful whenever it is desirable or necessary to\n" +
                "replay one or more binary logs to a MySQL Server which may not contain\n" +
                "all of the data to which the logs refer.");
            tooltip1.SetToolTip(cbRaw, "" +
                "By default, mysqlbinlog reads binary log files and writes events in text format.\n" +
                "The --raw option tells mysqlbinlog to write them in their original binary format.");
            tooltip1.SetToolTip(cbSkipGtids, "" +
                "Do not display any GTIDs in the output. This is needed when writing to\n" +
                "a dump file from one or more binary logs containing GTIDs");
            tooltip1.SetToolTip(cbServerTime, "" +
                "Use mysql server time instead of local machine's to increase dump time precision\n" +
                "WARNING: the server and the client must be set in the same time zone for this option to work correctly");

            tooltip1.SetToolTip(gbDebug, "" +
                "Activating debug options may render the \n" +
                "incremental backup non functional use only\n" +
                "for debug puproses.");
            tooltip1.SetToolTip(tbDebugOptions, "--debug[=debug_options]\n" +
                "Write a debugging log. A typical debug_options string is d:t:o,file_name. The default is d:t:o,/tmp/mysqlbinlog.trace.");
            tooltip1.SetToolTip(cbDebugCheck, "Print some debugging information when the program exits.");
            tooltip1.SetToolTip(cbDebugInfo, "Print debugging information and memory and CPU usage statistics when the program exits.");
            tooltip1.SetToolTip(cbHexdump, "" +
                "Display a hex dump of the log in comments, as described in Section 4.6.8.1,\n" +
                " “mysqlbinlog Hex Dump Format”. The hex output can be helpful for replication debugging.");
            tooltip1.SetToolTip(cbPrintDefaults, "Print the program name and all options that it gets from option files.");
            tooltip1.SetToolTip(cbPrintTableMetadata, "" +
                "Print table related metadata from the binary log. Configure the amount \n" +
                "of table related metadata binary logged using binlog-row-metadata.");
            tooltip1.SetToolTip(cbVerbose, "" +
                "Reconstruct row events and display them as commented SQL statements, \n" +
                "with table partition information where applicable.");
            //tooltips
        }
    }
}
