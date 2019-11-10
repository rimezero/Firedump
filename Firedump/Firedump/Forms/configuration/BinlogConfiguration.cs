using Firedump.models.configuration.jsonconfig;
using Firedump.utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
