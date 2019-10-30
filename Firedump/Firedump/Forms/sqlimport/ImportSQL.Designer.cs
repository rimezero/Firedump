namespace Firedump.Forms.sqlimport
{
    partial class ImportSQL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbMainProgress = new System.Windows.Forms.ProgressBar();
            this.lStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.mysqlserversBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firedumpdbDataSet = new Firedump.firedumpdbDataSet();
            this.cmbDatabases = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbDatabase = new System.Windows.Forms.GroupBox();
            this.bManageServers = new System.Windows.Forms.Button();
            this.cbShowSysDb = new System.Windows.Forms.CheckBox();
            this.gbFile = new System.Windows.Forms.GroupBox();
            this.bManageSaveLocs = new System.Windows.Forms.Button();
            this.tbDelimeter = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.linfo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bChoosePathFs = new System.Windows.Forms.Button();
            this.bChoosePathSv = new System.Windows.Forms.Button();
            this.tbFilePathFs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFilePathSv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSaveLocations = new System.Windows.Forms.ComboBox();
            this.backuplocationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bStartImport = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.mysql_serversTableAdapter = new Firedump.firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();
            this.backup_locationsTableAdapter = new Firedump.firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            this.gbCompressed = new System.Windows.Forms.GroupBox();
            this.lPassHelp = new System.Windows.Forms.Label();
            this.tbConfirmPass = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.lConfirmPass = new System.Windows.Forms.Label();
            this.lPass = new System.Windows.Forms.Label();
            this.cbEncryptedFile = new System.Windows.Forms.CheckBox();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.cImportChain = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mysqlserversBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firedumpdbDataSet)).BeginInit();
            this.gbDatabase.SuspendLayout();
            this.gbFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backuplocationsBindingSource)).BeginInit();
            this.gbCompressed.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMainProgress
            // 
            this.pbMainProgress.Location = new System.Drawing.Point(18, 1002);
            this.pbMainProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbMainProgress.Name = "pbMainProgress";
            this.pbMainProgress.Size = new System.Drawing.Size(1029, 35);
            this.pbMainProgress.TabIndex = 0;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(18, 977);
            this.lStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(64, 20);
            this.lStatus.TabIndex = 1;
            this.lStatus.Text = "Status: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database: ";
            // 
            // cmbServers
            // 
            this.cmbServers.DataSource = this.mysqlserversBindingSource;
            this.cmbServers.DisplayMember = "name";
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.Location = new System.Drawing.Point(110, 83);
            this.cmbServers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(412, 28);
            this.cmbServers.TabIndex = 4;
            this.cmbServers.ValueMember = "id";
            this.cmbServers.SelectedIndexChanged += new System.EventHandler(this.cmbServers_SelectedIndexChanged);
            // 
            // mysqlserversBindingSource
            // 
            this.mysqlserversBindingSource.DataMember = "mysql_servers";
            this.mysqlserversBindingSource.DataSource = this.firedumpdbDataSet;
            // 
            // firedumpdbDataSet
            // 
            this.firedumpdbDataSet.DataSetName = "firedumpdbDataSet";
            this.firedumpdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.FormattingEnabled = true;
            this.cmbDatabases.Location = new System.Drawing.Point(110, 132);
            this.cmbDatabases.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(412, 28);
            this.cmbDatabases.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Apply to: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "From save location: ";
            // 
            // gbDatabase
            // 
            this.gbDatabase.Controls.Add(this.bManageServers);
            this.gbDatabase.Controls.Add(this.cbShowSysDb);
            this.gbDatabase.Controls.Add(this.cmbServers);
            this.gbDatabase.Controls.Add(this.label1);
            this.gbDatabase.Controls.Add(this.label2);
            this.gbDatabase.Controls.Add(this.label3);
            this.gbDatabase.Controls.Add(this.cmbDatabases);
            this.gbDatabase.Location = new System.Drawing.Point(22, 18);
            this.gbDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDatabase.Name = "gbDatabase";
            this.gbDatabase.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDatabase.Size = new System.Drawing.Size(1024, 235);
            this.gbDatabase.TabIndex = 8;
            this.gbDatabase.TabStop = false;
            this.gbDatabase.Text = "Pick a database";
            // 
            // bManageServers
            // 
            this.bManageServers.Location = new System.Drawing.Point(666, 80);
            this.bManageServers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bManageServers.Name = "bManageServers";
            this.bManageServers.Size = new System.Drawing.Size(204, 35);
            this.bManageServers.TabIndex = 24;
            this.bManageServers.Text = "Manage Servers";
            this.bManageServers.UseVisualStyleBackColor = true;
            this.bManageServers.Visible = false;
            // 
            // cbShowSysDb
            // 
            this.cbShowSysDb.AutoSize = true;
            this.cbShowSysDb.Location = new System.Drawing.Point(558, 135);
            this.cbShowSysDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbShowSysDb.Name = "cbShowSysDb";
            this.cbShowSysDb.Size = new System.Drawing.Size(208, 24);
            this.cbShowSysDb.TabIndex = 7;
            this.cbShowSysDb.Text = "Show system databases";
            this.cbShowSysDb.UseVisualStyleBackColor = true;
            this.cbShowSysDb.CheckedChanged += new System.EventHandler(this.cbShowSysDb_CheckedChanged);
            // 
            // gbFile
            // 
            this.gbFile.Controls.Add(this.cImportChain);
            this.gbFile.Controls.Add(this.bManageSaveLocs);
            this.gbFile.Controls.Add(this.tbDelimeter);
            this.gbFile.Controls.Add(this.label12);
            this.gbFile.Controls.Add(this.linfo);
            this.gbFile.Controls.Add(this.label11);
            this.gbFile.Controls.Add(this.label10);
            this.gbFile.Controls.Add(this.bChoosePathFs);
            this.gbFile.Controls.Add(this.bChoosePathSv);
            this.gbFile.Controls.Add(this.tbFilePathFs);
            this.gbFile.Controls.Add(this.label9);
            this.gbFile.Controls.Add(this.label8);
            this.gbFile.Controls.Add(this.label7);
            this.gbFile.Controls.Add(this.tbFilePathSv);
            this.gbFile.Controls.Add(this.label6);
            this.gbFile.Controls.Add(this.label5);
            this.gbFile.Controls.Add(this.cmbSaveLocations);
            this.gbFile.Controls.Add(this.label4);
            this.gbFile.Location = new System.Drawing.Point(22, 263);
            this.gbFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbFile.Name = "gbFile";
            this.gbFile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbFile.Size = new System.Drawing.Size(1024, 351);
            this.gbFile.TabIndex = 9;
            this.gbFile.TabStop = false;
            this.gbFile.Text = "Pick a file";
            // 
            // bManageSaveLocs
            // 
            this.bManageSaveLocs.Location = new System.Drawing.Point(666, 134);
            this.bManageSaveLocs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bManageSaveLocs.Name = "bManageSaveLocs";
            this.bManageSaveLocs.Size = new System.Drawing.Size(204, 35);
            this.bManageSaveLocs.TabIndex = 23;
            this.bManageSaveLocs.Text = "Manage Save Locations";
            this.bManageSaveLocs.UseVisualStyleBackColor = true;
            this.bManageSaveLocs.Click += new System.EventHandler(this.bManageSaveLocs_Click);
            // 
            // tbDelimeter
            // 
            this.tbDelimeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbDelimeter.Location = new System.Drawing.Point(794, 268);
            this.tbDelimeter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDelimeter.Name = "tbDelimeter";
            this.tbDelimeter.Size = new System.Drawing.Size(134, 35);
            this.tbDelimeter.TabIndex = 22;
            this.tbDelimeter.Text = ";";
            this.tbDelimeter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(662, 280);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Script delimeter:";
            // 
            // linfo
            // 
            this.linfo.AutoSize = true;
            this.linfo.Location = new System.Drawing.Point(554, 74);
            this.linfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linfo.Name = "linfo";
            this.linfo.Size = new System.Drawing.Size(38, 20);
            this.linfo.TabIndex = 20;
            this.linfo.Text = "linfo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.Location = new System.Drawing.Point(554, 48);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(348, 25);
            this.label11.TabIndex = 19;
            this.label11.Text = ".sql .7z .rar .gzip .zip .bzip2 .tar .iso .udf";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(554, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(371, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Selected file must have extension.  Works for types:";
            // 
            // bChoosePathFs
            // 
            this.bChoosePathFs.Location = new System.Drawing.Point(532, 272);
            this.bChoosePathFs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bChoosePathFs.Name = "bChoosePathFs";
            this.bChoosePathFs.Size = new System.Drawing.Size(54, 35);
            this.bChoosePathFs.TabIndex = 17;
            this.bChoosePathFs.Text = "...";
            this.bChoosePathFs.UseVisualStyleBackColor = true;
            this.bChoosePathFs.Click += new System.EventHandler(this.bChoosePathFs_Click);
            // 
            // bChoosePathSv
            // 
            this.bChoosePathSv.Location = new System.Drawing.Point(532, 135);
            this.bChoosePathSv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bChoosePathSv.Name = "bChoosePathSv";
            this.bChoosePathSv.Size = new System.Drawing.Size(54, 35);
            this.bChoosePathSv.TabIndex = 16;
            this.bChoosePathSv.Text = "...";
            this.bChoosePathSv.UseVisualStyleBackColor = true;
            this.bChoosePathSv.Click += new System.EventHandler(this.bChoosePathSv_Click);
            // 
            // tbFilePathFs
            // 
            this.tbFilePathFs.Location = new System.Drawing.Point(110, 275);
            this.tbFilePathFs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFilePathFs.Name = "tbFilePathFs";
            this.tbFilePathFs.ReadOnly = true;
            this.tbFilePathFs.Size = new System.Drawing.Size(412, 26);
            this.tbFilePathFs.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 280);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "File path: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 195);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "OR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 228);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Local file:";
            // 
            // tbFilePathSv
            // 
            this.tbFilePathSv.Location = new System.Drawing.Point(110, 138);
            this.tbFilePathSv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFilePathSv.Name = "tbFilePathSv";
            this.tbFilePathSv.ReadOnly = true;
            this.tbFilePathSv.Size = new System.Drawing.Size(412, 26);
            this.tbFilePathSv.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 143);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "File path: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Name:";
            // 
            // cmbSaveLocations
            // 
            this.cmbSaveLocations.DataSource = this.backuplocationsBindingSource;
            this.cmbSaveLocations.DisplayMember = "name";
            this.cmbSaveLocations.FormattingEnabled = true;
            this.cmbSaveLocations.Location = new System.Drawing.Point(110, 86);
            this.cmbSaveLocations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSaveLocations.Name = "cmbSaveLocations";
            this.cmbSaveLocations.Size = new System.Drawing.Size(412, 28);
            this.cmbSaveLocations.TabIndex = 8;
            this.cmbSaveLocations.ValueMember = "id";
            // 
            // backuplocationsBindingSource
            // 
            this.backuplocationsBindingSource.DataMember = "backup_locations";
            this.backuplocationsBindingSource.DataSource = this.firedumpdbDataSet;
            // 
            // bStartImport
            // 
            this.bStartImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bStartImport.Location = new System.Drawing.Point(18, 888);
            this.bStartImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bStartImport.Name = "bStartImport";
            this.bStartImport.Size = new System.Drawing.Size(256, 65);
            this.bStartImport.TabIndex = 10;
            this.bStartImport.Text = "Start Import";
            this.bStartImport.UseVisualStyleBackColor = true;
            this.bStartImport.Click += new System.EventHandler(this.bStartImport_Click);
            // 
            // bCancel
            // 
            this.bCancel.ForeColor = System.Drawing.Color.Red;
            this.bCancel.Location = new System.Drawing.Point(934, 957);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(112, 35);
            this.bCancel.TabIndex = 11;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // mysql_serversTableAdapter
            // 
            this.mysql_serversTableAdapter.ClearBeforeFill = true;
            // 
            // backup_locationsTableAdapter
            // 
            this.backup_locationsTableAdapter.ClearBeforeFill = true;
            // 
            // gbCompressed
            // 
            this.gbCompressed.Controls.Add(this.lPassHelp);
            this.gbCompressed.Controls.Add(this.tbConfirmPass);
            this.gbCompressed.Controls.Add(this.tbPass);
            this.gbCompressed.Controls.Add(this.lConfirmPass);
            this.gbCompressed.Controls.Add(this.lPass);
            this.gbCompressed.Controls.Add(this.cbEncryptedFile);
            this.gbCompressed.Enabled = false;
            this.gbCompressed.Location = new System.Drawing.Point(22, 623);
            this.gbCompressed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCompressed.Name = "gbCompressed";
            this.gbCompressed.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCompressed.Size = new System.Drawing.Size(1024, 242);
            this.gbCompressed.TabIndex = 12;
            this.gbCompressed.TabStop = false;
            this.gbCompressed.Text = "Compressed file";
            // 
            // lPassHelp
            // 
            this.lPassHelp.AutoSize = true;
            this.lPassHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lPassHelp.ForeColor = System.Drawing.Color.Red;
            this.lPassHelp.Location = new System.Drawing.Point(186, 188);
            this.lPassHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPassHelp.Name = "lPassHelp";
            this.lPassHelp.Size = new System.Drawing.Size(216, 20);
            this.lPassHelp.TabIndex = 11;
            this.lPassHelp.Text = "Passwords do not match";
            this.lPassHelp.Visible = false;
            // 
            // tbConfirmPass
            // 
            this.tbConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbConfirmPass.Location = new System.Drawing.Point(190, 137);
            this.tbConfirmPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbConfirmPass.Name = "tbConfirmPass";
            this.tbConfirmPass.PasswordChar = '*';
            this.tbConfirmPass.Size = new System.Drawing.Size(256, 26);
            this.tbConfirmPass.TabIndex = 10;
            this.tbConfirmPass.Leave += new System.EventHandler(this.tbConfirmPass_Leave);
            // 
            // tbPass
            // 
            this.tbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbPass.Location = new System.Drawing.Point(190, 80);
            this.tbPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(256, 26);
            this.tbPass.TabIndex = 9;
            // 
            // lConfirmPass
            // 
            this.lConfirmPass.AutoSize = true;
            this.lConfirmPass.Location = new System.Drawing.Point(44, 142);
            this.lConfirmPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lConfirmPass.Name = "lConfirmPass";
            this.lConfirmPass.Size = new System.Drawing.Size(140, 20);
            this.lConfirmPass.TabIndex = 8;
            this.lConfirmPass.Text = "Confirm password:";
            // 
            // lPass
            // 
            this.lPass.AutoSize = true;
            this.lPass.Location = new System.Drawing.Point(99, 85);
            this.lPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPass.Name = "lPass";
            this.lPass.Size = new System.Drawing.Size(82, 20);
            this.lPass.TabIndex = 7;
            this.lPass.Text = "Password:";
            // 
            // cbEncryptedFile
            // 
            this.cbEncryptedFile.AutoSize = true;
            this.cbEncryptedFile.Location = new System.Drawing.Point(16, 31);
            this.cbEncryptedFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEncryptedFile.Name = "cbEncryptedFile";
            this.cbEncryptedFile.Size = new System.Drawing.Size(149, 24);
            this.cbEncryptedFile.TabIndex = 0;
            this.cbEncryptedFile.Text = "File is encrypted";
            this.cbEncryptedFile.UseVisualStyleBackColor = true;
            this.cbEncryptedFile.CheckedChanged += new System.EventHandler(this.cbEncryptedFile_CheckedChanged);
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(448, 972);
            this.lbSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(64, 20);
            this.lbSpeed.TabIndex = 13;
            this.lbSpeed.Text = "Speed: ";
            this.lbSpeed.Visible = false;
            // 
            // cImportChain
            // 
            this.cImportChain.AutoSize = true;
            this.cImportChain.Location = new System.Drawing.Point(666, 209);
            this.cImportChain.Name = "cImportChain";
            this.cImportChain.Size = new System.Drawing.Size(126, 24);
            this.cImportChain.TabIndex = 14;
            this.cImportChain.Text = "Import Chain";
            this.cImportChain.UseVisualStyleBackColor = true;
            // 
            // ImportSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 1055);
            this.Controls.Add(this.lbSpeed);
            this.Controls.Add(this.gbCompressed);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bStartImport);
            this.Controls.Add(this.gbFile);
            this.Controls.Add(this.gbDatabase);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.pbMainProgress);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ImportSQL";
            this.Text = "SQLImport";
            this.Load += new System.EventHandler(this.SQLImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mysqlserversBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firedumpdbDataSet)).EndInit();
            this.gbDatabase.ResumeLayout(false);
            this.gbDatabase.PerformLayout();
            this.gbFile.ResumeLayout(false);
            this.gbFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backuplocationsBindingSource)).EndInit();
            this.gbCompressed.ResumeLayout(false);
            this.gbCompressed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbMainProgress;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.ComboBox cmbDatabases;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbDatabase;
        private System.Windows.Forms.GroupBox gbFile;
        private System.Windows.Forms.Button bChoosePathFs;
        private System.Windows.Forms.Button bChoosePathSv;
        private System.Windows.Forms.TextBox tbFilePathFs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFilePathSv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSaveLocations;
        private System.Windows.Forms.Button bStartImport;
        private System.Windows.Forms.Button bCancel;
        private firedumpdbDataSet firedumpdbDataSet;
        private System.Windows.Forms.BindingSource mysqlserversBindingSource;
        private firedumpdbDataSetTableAdapters.mysql_serversTableAdapter mysql_serversTableAdapter;
        private System.Windows.Forms.BindingSource backuplocationsBindingSource;
        private firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backup_locationsTableAdapter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbCompressed;
        private System.Windows.Forms.Label linfo;
        private System.Windows.Forms.CheckBox cbEncryptedFile;
        private System.Windows.Forms.Label lPassHelp;
        private System.Windows.Forms.TextBox tbConfirmPass;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label lConfirmPass;
        private System.Windows.Forms.Label lPass;
        private System.Windows.Forms.CheckBox cbShowSysDb;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.TextBox tbDelimeter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bManageServers;
        private System.Windows.Forms.Button bManageSaveLocs;
        private System.Windows.Forms.CheckBox cImportChain;
    }
}