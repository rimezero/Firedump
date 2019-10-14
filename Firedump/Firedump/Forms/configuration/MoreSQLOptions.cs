using Firedump.models.configuration.jsonconfig;
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
    public partial class MoreSQLOptions : Form
    {
        public MoreSQLOptions()
        {
            InitializeComponent();
        }

        private void MoreSQLOptions_Load(object sender, EventArgs e)
        {
            ConfigurationManager configManagerInstance = ConfigurationManager.getInstance();

            //general
            cbAddComments.Checked = configManagerInstance.mysqlDumpConfigInstance.includeComments;
            cbForeignKey.Checked = configManagerInstance.mysqlDumpConfigInstance.disableForeignKeyChecks;
            if(configManagerInstance.mysqlDumpConfigInstance.singleTransaction || configManagerInstance.mysqlDumpConfigInstance.lockTables)
            {
                cbEnableDataPreservation.Checked = true;
                if (configManagerInstance.mysqlDumpConfigInstance.singleTransaction)
                {
                    rbSingleTransaction.Checked = true;
                }
                else
                {
                    rbLockTables.Checked = true;
                }
            }
            else
            {
                cbEnableDataPreservation.Checked = false;
            }
            disableOrEnableRadioButtons(cbEnableDataPreservation.Checked);
            cbNoAutocommit.Checked = configManagerInstance.mysqlDumpConfigInstance.noAutocommit;
            tbCustomComment.Text = configManagerInstance.mysqlDumpConfigInstance.addCustomCommentInHeader;
            cbIncreasedComp.Checked = configManagerInstance.mysqlDumpConfigInstance.moreCompatible;
            string[] charsets = { "utf8", "armscii8","ascii", "cp850", "cp852", "cp866", "cp1250", "cp1251", "cp1256", "cp1257", "dec8", "geostd8", "greek", "hebrew", "hp8", "Index",
                "keybcs2", "koi8r", "koi8u", "latin1", "latin2", "latin5", "latin7", "macce", "macroman", "swe7" };
            cmbCharacterSet.DataSource = charsets;
            cmbCharacterSet.SelectedItem = configManagerInstance.mysqlDumpConfigInstance.characterSet;
            cbXml.Checked = configManagerInstance.mysqlDumpConfigInstance.xml;

            //structure
            cbAddDropDatabase.Checked = configManagerInstance.mysqlDumpConfigInstance.addDropDatabase;
            cbAddCreateDatabase.Checked = configManagerInstance.mysqlDumpConfigInstance.createDatabase;
            cbAddDropTable.Checked = configManagerInstance.mysqlDumpConfigInstance.addDropTable;
            cbAddLocks.Checked = configManagerInstance.mysqlDumpConfigInstance.addLocks;
            cbAddDateComment.Checked = configManagerInstance.mysqlDumpConfigInstance.addInfoComments;
            cbEncloseBackquotes.Checked = configManagerInstance.mysqlDumpConfigInstance.encloseWithBackquotes;

            //data
            cbUseCompleteInserts.Checked = configManagerInstance.mysqlDumpConfigInstance.completeInsertStatements;
            cbUseExtendedInserts.Checked = configManagerInstance.mysqlDumpConfigInstance.extendedInsertStatements;
            cbUseIgnoreInserts.Checked = configManagerInstance.mysqlDumpConfigInstance.useIgnoreInserts;
            cbUseHexadecimal.Checked = configManagerInstance.mysqlDumpConfigInstance.useHexadecimal;
            nudMaxLength.Value = configManagerInstance.mysqlDumpConfigInstance.maximumLengthOfQuery;
            nudMaxPacketSize.Value = configManagerInstance.mysqlDumpConfigInstance.maximumPacketLength;
            string[] exportTypes = { "INSERT","REPLACE" };
            cmbExportType.DataSource = exportTypes;
            cmbExportType.SelectedIndex = configManagerInstance.mysqlDumpConfigInstance.exportType;
        }

        private void disableOrEnableRadioButtons(bool action)
        {
            rbSingleTransaction.Enabled = action;
            rbLockTables.Enabled = action;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            ConfigurationManager configManagerInstance = ConfigurationManager.getInstance();

            //general
            configManagerInstance.mysqlDumpConfigInstance.includeComments = cbAddComments.Checked;
            configManagerInstance.mysqlDumpConfigInstance.disableForeignKeyChecks = cbForeignKey.Checked;
            if (cbEnableDataPreservation.Checked)
            {
                configManagerInstance.mysqlDumpConfigInstance.singleTransaction = rbSingleTransaction.Checked;
                configManagerInstance.mysqlDumpConfigInstance.lockTables = rbLockTables.Checked;
            }
            else
            {
                configManagerInstance.mysqlDumpConfigInstance.singleTransaction = false;
                configManagerInstance.mysqlDumpConfigInstance.lockTables = false;
            }
            configManagerInstance.mysqlDumpConfigInstance.noAutocommit = cbNoAutocommit.Checked;
            configManagerInstance.mysqlDumpConfigInstance.addCustomCommentInHeader = tbCustomComment.Text;
            configManagerInstance.mysqlDumpConfigInstance.moreCompatible = cbIncreasedComp.Checked;
            configManagerInstance.mysqlDumpConfigInstance.characterSet = (string)cmbCharacterSet.SelectedItem;
            configManagerInstance.mysqlDumpConfigInstance.xml = cbXml.Checked;

            //structure
            configManagerInstance.mysqlDumpConfigInstance.addDropDatabase = cbAddDropDatabase.Checked;
            configManagerInstance.mysqlDumpConfigInstance.createDatabase = cbAddCreateDatabase.Checked;
            configManagerInstance.mysqlDumpConfigInstance.addDropTable = cbAddDropTable.Checked;
            configManagerInstance.mysqlDumpConfigInstance.addLocks = cbAddLocks.Checked;
            configManagerInstance.mysqlDumpConfigInstance.addInfoComments = cbAddDateComment.Checked;
            configManagerInstance.mysqlDumpConfigInstance.encloseWithBackquotes = cbEncloseBackquotes.Checked;

            //data
            configManagerInstance.mysqlDumpConfigInstance.completeInsertStatements = cbUseCompleteInserts.Checked;
            configManagerInstance.mysqlDumpConfigInstance.extendedInsertStatements = cbUseExtendedInserts.Checked;
            configManagerInstance.mysqlDumpConfigInstance.useIgnoreInserts = cbUseIgnoreInserts.Checked;
            configManagerInstance.mysqlDumpConfigInstance.useHexadecimal = cbUseHexadecimal.Checked;
            configManagerInstance.mysqlDumpConfigInstance.maximumLengthOfQuery = (int)nudMaxLength.Value;
            configManagerInstance.mysqlDumpConfigInstance.maximumPacketLength = (int)nudMaxPacketSize.Value;
            configManagerInstance.mysqlDumpConfigInstance.exportType = cmbExportType.SelectedIndex;
            

            configManagerInstance.mysqlDumpConfigInstance.saveConfig();
            this.Close();
        }

        private void cbEnableDataPreservation_CheckedChanged(object sender, EventArgs e)
        {
            disableOrEnableRadioButtons(cbEnableDataPreservation.Checked);
        }
    }
}
