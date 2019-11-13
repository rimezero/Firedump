namespace Firedump.Forms.configuration
{
    partial class BinlogConfiguration
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
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.cmbBase64 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbRowEventMaxSize = new System.Windows.Forms.TextBox();
            this.tbServerId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbConServerId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbProtocol = new System.Windows.Forms.ComboBox();
            this.cmbCompressionAlgorithm = new System.Windows.Forms.ComboBox();
            this.cmbCharset = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRewriteTo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRewriteFrom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBindAdress = new System.Windows.Forms.TextBox();
            this.lbExcludeGtids = new System.Windows.Forms.Label();
            this.tbExcludeGtids = new System.Windows.Forms.TextBox();
            this.lbCharsetDir = new System.Windows.Forms.Label();
            this.bCharsetDir = new System.Windows.Forms.Button();
            this.tbCharacterSetsDir = new System.Windows.Forms.TextBox();
            this.gbDebug = new System.Windows.Forms.GroupBox();
            this.cbVerbose = new System.Windows.Forms.CheckBox();
            this.cbPrintTableMetadata = new System.Windows.Forms.CheckBox();
            this.cbPrintDefaults = new System.Windows.Forms.CheckBox();
            this.cbHexdump = new System.Windows.Forms.CheckBox();
            this.cbDebugInfo = new System.Windows.Forms.CheckBox();
            this.cbDebugCheck = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDebugOptions = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbServerTime = new System.Windows.Forms.CheckBox();
            this.cbSkipGtids = new System.Windows.Forms.CheckBox();
            this.cbRaw = new System.Windows.Forms.CheckBox();
            this.cbIdempotent = new System.Windows.Forms.CheckBox();
            this.cbGetServerPublicKey = new System.Windows.Forms.CheckBox();
            this.cbForceRead = new System.Windows.Forms.CheckBox();
            this.cbForceIfOpen = new System.Windows.Forms.CheckBox();
            this.cbDisableBinaryLogging = new System.Windows.Forms.CheckBox();
            this.tooltip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbGeneral.SuspendLayout();
            this.gbDebug.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.cmbBase64);
            this.gbGeneral.Controls.Add(this.label13);
            this.gbGeneral.Controls.Add(this.tbRowEventMaxSize);
            this.gbGeneral.Controls.Add(this.tbServerId);
            this.gbGeneral.Controls.Add(this.label12);
            this.gbGeneral.Controls.Add(this.tbConServerId);
            this.gbGeneral.Controls.Add(this.label11);
            this.gbGeneral.Controls.Add(this.cmbProtocol);
            this.gbGeneral.Controls.Add(this.cmbCompressionAlgorithm);
            this.gbGeneral.Controls.Add(this.cmbCharset);
            this.gbGeneral.Controls.Add(this.label10);
            this.gbGeneral.Controls.Add(this.label9);
            this.gbGeneral.Controls.Add(this.tbRewriteTo);
            this.gbGeneral.Controls.Add(this.label8);
            this.gbGeneral.Controls.Add(this.tbRewriteFrom);
            this.gbGeneral.Controls.Add(this.label7);
            this.gbGeneral.Controls.Add(this.label6);
            this.gbGeneral.Controls.Add(this.label5);
            this.gbGeneral.Controls.Add(this.label4);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.tbBindAdress);
            this.gbGeneral.Controls.Add(this.lbExcludeGtids);
            this.gbGeneral.Controls.Add(this.tbExcludeGtids);
            this.gbGeneral.Controls.Add(this.lbCharsetDir);
            this.gbGeneral.Controls.Add(this.bCharsetDir);
            this.gbGeneral.Controls.Add(this.tbCharacterSetsDir);
            this.gbGeneral.Location = new System.Drawing.Point(78, 37);
            this.gbGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbGeneral.Size = new System.Drawing.Size(765, 722);
            this.gbGeneral.TabIndex = 0;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // cmbBase64
            // 
            this.cmbBase64.FormattingEnabled = true;
            this.cmbBase64.Location = new System.Drawing.Point(200, 246);
            this.cmbBase64.Name = "cmbBase64";
            this.cmbBase64.Size = new System.Drawing.Size(227, 28);
            this.cmbBase64.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 626);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Row event max size:";
            // 
            // tbRowEventMaxSize
            // 
            this.tbRowEventMaxSize.Location = new System.Drawing.Point(200, 623);
            this.tbRowEventMaxSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRowEventMaxSize.Name = "tbRowEventMaxSize";
            this.tbRowEventMaxSize.Size = new System.Drawing.Size(177, 26);
            this.tbRowEventMaxSize.TabIndex = 27;
            // 
            // tbServerId
            // 
            this.tbServerId.Location = new System.Drawing.Point(406, 565);
            this.tbServerId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbServerId.Name = "tbServerId";
            this.tbServerId.Size = new System.Drawing.Size(67, 26);
            this.tbServerId.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(323, 568);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Server id:";
            // 
            // tbConServerId
            // 
            this.tbConServerId.Location = new System.Drawing.Point(200, 565);
            this.tbConServerId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbConServerId.Name = "tbConServerId";
            this.tbConServerId.Size = new System.Drawing.Size(67, 26);
            this.tbConServerId.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 568);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Connection server id:";
            // 
            // cmbProtocol
            // 
            this.cmbProtocol.FormattingEnabled = true;
            this.cmbProtocol.Location = new System.Drawing.Point(200, 422);
            this.cmbProtocol.Name = "cmbProtocol";
            this.cmbProtocol.Size = new System.Drawing.Size(227, 28);
            this.cmbProtocol.TabIndex = 22;
            // 
            // cmbCompressionAlgorithm
            // 
            this.cmbCompressionAlgorithm.FormattingEnabled = true;
            this.cmbCompressionAlgorithm.Location = new System.Drawing.Point(200, 364);
            this.cmbCompressionAlgorithm.Name = "cmbCompressionAlgorithm";
            this.cmbCompressionAlgorithm.Size = new System.Drawing.Size(227, 28);
            this.cmbCompressionAlgorithm.TabIndex = 21;
            // 
            // cmbCharset
            // 
            this.cmbCharset.FormattingEnabled = true;
            this.cmbCharset.Location = new System.Drawing.Point(200, 308);
            this.cmbCharset.Name = "cmbCharset";
            this.cmbCharset.Size = new System.Drawing.Size(227, 28);
            this.cmbCharset.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(500, 499);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "to:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 499);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "from:";
            // 
            // tbRewriteTo
            // 
            this.tbRewriteTo.Location = new System.Drawing.Point(535, 496);
            this.tbRewriteTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRewriteTo.Name = "tbRewriteTo";
            this.tbRewriteTo.Size = new System.Drawing.Size(177, 26);
            this.tbRewriteTo.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 499);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Rewrite database:";
            // 
            // tbRewriteFrom
            // 
            this.tbRewriteFrom.Location = new System.Drawing.Point(273, 496);
            this.tbRewriteFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRewriteFrom.Name = "tbRewriteFrom";
            this.tbRewriteFrom.Size = new System.Drawing.Size(177, 26);
            this.tbRewriteFrom.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 425);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Protocol:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 367);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Compression algorithm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 311);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Charset:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 249);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Base 64 output:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 191);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bind address:";
            // 
            // tbBindAdress
            // 
            this.tbBindAdress.Location = new System.Drawing.Point(200, 188);
            this.tbBindAdress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBindAdress.Name = "tbBindAdress";
            this.tbBindAdress.Size = new System.Drawing.Size(470, 26);
            this.tbBindAdress.TabIndex = 5;
            // 
            // lbExcludeGtids
            // 
            this.lbExcludeGtids.AutoSize = true;
            this.lbExcludeGtids.Location = new System.Drawing.Point(56, 133);
            this.lbExcludeGtids.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbExcludeGtids.Name = "lbExcludeGtids";
            this.lbExcludeGtids.Size = new System.Drawing.Size(133, 20);
            this.lbExcludeGtids.TabIndex = 4;
            this.lbExcludeGtids.Text = "Exclude gtid sets:";
            // 
            // tbExcludeGtids
            // 
            this.tbExcludeGtids.Location = new System.Drawing.Point(200, 130);
            this.tbExcludeGtids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbExcludeGtids.Name = "tbExcludeGtids";
            this.tbExcludeGtids.Size = new System.Drawing.Size(470, 26);
            this.tbExcludeGtids.TabIndex = 3;
            // 
            // lbCharsetDir
            // 
            this.lbCharsetDir.AutoSize = true;
            this.lbCharsetDir.Location = new System.Drawing.Point(8, 78);
            this.lbCharsetDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCharsetDir.Name = "lbCharsetDir";
            this.lbCharsetDir.Size = new System.Drawing.Size(181, 20);
            this.lbCharsetDir.TabIndex = 2;
            this.lbCharsetDir.Text = "Character sets directory:";
            // 
            // bCharsetDir
            // 
            this.bCharsetDir.Location = new System.Drawing.Point(681, 72);
            this.bCharsetDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bCharsetDir.Name = "bCharsetDir";
            this.bCharsetDir.Size = new System.Drawing.Size(60, 35);
            this.bCharsetDir.TabIndex = 1;
            this.bCharsetDir.Text = "...";
            this.bCharsetDir.UseVisualStyleBackColor = true;
            this.bCharsetDir.Click += new System.EventHandler(this.bCharsetDir_Click);
            // 
            // tbCharacterSetsDir
            // 
            this.tbCharacterSetsDir.Location = new System.Drawing.Point(200, 75);
            this.tbCharacterSetsDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCharacterSetsDir.Name = "tbCharacterSetsDir";
            this.tbCharacterSetsDir.ReadOnly = true;
            this.tbCharacterSetsDir.Size = new System.Drawing.Size(470, 26);
            this.tbCharacterSetsDir.TabIndex = 0;
            // 
            // gbDebug
            // 
            this.gbDebug.Controls.Add(this.cbVerbose);
            this.gbDebug.Controls.Add(this.cbPrintTableMetadata);
            this.gbDebug.Controls.Add(this.cbPrintDefaults);
            this.gbDebug.Controls.Add(this.cbHexdump);
            this.gbDebug.Controls.Add(this.cbDebugInfo);
            this.gbDebug.Controls.Add(this.cbDebugCheck);
            this.gbDebug.Controls.Add(this.label14);
            this.gbDebug.Controls.Add(this.tbDebugOptions);
            this.gbDebug.Location = new System.Drawing.Point(909, 401);
            this.gbDebug.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDebug.Name = "gbDebug";
            this.gbDebug.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDebug.Size = new System.Drawing.Size(748, 358);
            this.gbDebug.TabIndex = 1;
            this.gbDebug.TabStop = false;
            this.gbDebug.Text = "Debug";
            // 
            // cbVerbose
            // 
            this.cbVerbose.AutoSize = true;
            this.cbVerbose.Location = new System.Drawing.Point(498, 200);
            this.cbVerbose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVerbose.Name = "cbVerbose";
            this.cbVerbose.Size = new System.Drawing.Size(95, 24);
            this.cbVerbose.TabIndex = 16;
            this.cbVerbose.Text = "Verbose";
            this.cbVerbose.UseVisualStyleBackColor = true;
            // 
            // cbPrintTableMetadata
            // 
            this.cbPrintTableMetadata.AutoSize = true;
            this.cbPrintTableMetadata.Location = new System.Drawing.Point(272, 200);
            this.cbPrintTableMetadata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPrintTableMetadata.Name = "cbPrintTableMetadata";
            this.cbPrintTableMetadata.Size = new System.Drawing.Size(178, 24);
            this.cbPrintTableMetadata.TabIndex = 15;
            this.cbPrintTableMetadata.Text = "Print table metadata";
            this.cbPrintTableMetadata.UseVisualStyleBackColor = true;
            // 
            // cbPrintDefaults
            // 
            this.cbPrintDefaults.AutoSize = true;
            this.cbPrintDefaults.Location = new System.Drawing.Point(63, 200);
            this.cbPrintDefaults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPrintDefaults.Name = "cbPrintDefaults";
            this.cbPrintDefaults.Size = new System.Drawing.Size(128, 24);
            this.cbPrintDefaults.TabIndex = 14;
            this.cbPrintDefaults.Text = "Print defaults";
            this.cbPrintDefaults.UseVisualStyleBackColor = true;
            // 
            // cbHexdump
            // 
            this.cbHexdump.AutoSize = true;
            this.cbHexdump.Location = new System.Drawing.Point(498, 131);
            this.cbHexdump.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbHexdump.Name = "cbHexdump";
            this.cbHexdump.Size = new System.Drawing.Size(103, 24);
            this.cbHexdump.TabIndex = 13;
            this.cbHexdump.Text = "Hexdump";
            this.cbHexdump.UseVisualStyleBackColor = true;
            // 
            // cbDebugInfo
            // 
            this.cbDebugInfo.AutoSize = true;
            this.cbDebugInfo.Location = new System.Drawing.Point(272, 131);
            this.cbDebugInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDebugInfo.Name = "cbDebugInfo";
            this.cbDebugInfo.Size = new System.Drawing.Size(115, 24);
            this.cbDebugInfo.TabIndex = 12;
            this.cbDebugInfo.Text = "Debug Info";
            this.cbDebugInfo.UseVisualStyleBackColor = true;
            // 
            // cbDebugCheck
            // 
            this.cbDebugCheck.AutoSize = true;
            this.cbDebugCheck.Location = new System.Drawing.Point(63, 131);
            this.cbDebugCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDebugCheck.Name = "cbDebugCheck";
            this.cbDebugCheck.Size = new System.Drawing.Size(129, 24);
            this.cbDebugCheck.TabIndex = 11;
            this.cbDebugCheck.Text = "Debug check";
            this.cbDebugCheck.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(59, 61);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 20);
            this.label14.TabIndex = 10;
            this.label14.Text = "Debug Options:";
            // 
            // tbDebugOptions
            // 
            this.tbDebugOptions.Location = new System.Drawing.Point(192, 58);
            this.tbDebugOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDebugOptions.Name = "tbDebugOptions";
            this.tbDebugOptions.Size = new System.Drawing.Size(470, 26);
            this.tbDebugOptions.TabIndex = 9;
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bCancel.Location = new System.Drawing.Point(1515, 808);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(142, 57);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bReset
            // 
            this.bReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bReset.Location = new System.Drawing.Point(1122, 808);
            this.bReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(276, 57);
            this.bReset.TabIndex = 4;
            this.bReset.Text = "Reset to defaults";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bSave.Image = global::Firedump.Properties.Resources.save_image1;
            this.bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSave.Location = new System.Drawing.Point(78, 808);
            this.bSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(258, 57);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Save Options";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbServerTime);
            this.groupBox1.Controls.Add(this.cbSkipGtids);
            this.groupBox1.Controls.Add(this.cbRaw);
            this.groupBox1.Controls.Add(this.cbIdempotent);
            this.groupBox1.Controls.Add(this.cbGetServerPublicKey);
            this.groupBox1.Controls.Add(this.cbForceRead);
            this.groupBox1.Controls.Add(this.cbForceIfOpen);
            this.groupBox1.Controls.Add(this.cbDisableBinaryLogging);
            this.groupBox1.Location = new System.Drawing.Point(909, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(765, 331);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // cbServerTime
            // 
            this.cbServerTime.AutoSize = true;
            this.cbServerTime.Location = new System.Drawing.Point(272, 218);
            this.cbServerTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbServerTime.Name = "cbServerTime";
            this.cbServerTime.Size = new System.Drawing.Size(189, 24);
            this.cbServerTime.TabIndex = 11;
            this.cbServerTime.Text = "Use mysql server time";
            this.cbServerTime.UseVisualStyleBackColor = true;
            // 
            // cbSkipGtids
            // 
            this.cbSkipGtids.AutoSize = true;
            this.cbSkipGtids.Location = new System.Drawing.Point(63, 218);
            this.cbSkipGtids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSkipGtids.Name = "cbSkipGtids";
            this.cbSkipGtids.Size = new System.Drawing.Size(104, 24);
            this.cbSkipGtids.TabIndex = 10;
            this.cbSkipGtids.Text = "Skip gtids";
            this.cbSkipGtids.UseVisualStyleBackColor = true;
            // 
            // cbRaw
            // 
            this.cbRaw.AutoSize = true;
            this.cbRaw.Location = new System.Drawing.Point(498, 151);
            this.cbRaw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRaw.Name = "cbRaw";
            this.cbRaw.Size = new System.Drawing.Size(67, 24);
            this.cbRaw.TabIndex = 9;
            this.cbRaw.Text = "Raw";
            this.cbRaw.UseVisualStyleBackColor = true;
            // 
            // cbIdempotent
            // 
            this.cbIdempotent.AutoSize = true;
            this.cbIdempotent.Location = new System.Drawing.Point(272, 151);
            this.cbIdempotent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIdempotent.Name = "cbIdempotent";
            this.cbIdempotent.Size = new System.Drawing.Size(117, 24);
            this.cbIdempotent.TabIndex = 8;
            this.cbIdempotent.Text = "Idempotent";
            this.cbIdempotent.UseVisualStyleBackColor = true;
            // 
            // cbGetServerPublicKey
            // 
            this.cbGetServerPublicKey.AutoSize = true;
            this.cbGetServerPublicKey.Location = new System.Drawing.Point(63, 151);
            this.cbGetServerPublicKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGetServerPublicKey.Name = "cbGetServerPublicKey";
            this.cbGetServerPublicKey.Size = new System.Drawing.Size(182, 24);
            this.cbGetServerPublicKey.TabIndex = 7;
            this.cbGetServerPublicKey.Text = "Get server public key";
            this.cbGetServerPublicKey.UseVisualStyleBackColor = true;
            // 
            // cbForceRead
            // 
            this.cbForceRead.AutoSize = true;
            this.cbForceRead.Location = new System.Drawing.Point(498, 83);
            this.cbForceRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbForceRead.Name = "cbForceRead";
            this.cbForceRead.Size = new System.Drawing.Size(112, 24);
            this.cbForceRead.TabIndex = 6;
            this.cbForceRead.Text = "Force read";
            this.cbForceRead.UseVisualStyleBackColor = true;
            // 
            // cbForceIfOpen
            // 
            this.cbForceIfOpen.AutoSize = true;
            this.cbForceIfOpen.Location = new System.Drawing.Point(272, 83);
            this.cbForceIfOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbForceIfOpen.Name = "cbForceIfOpen";
            this.cbForceIfOpen.Size = new System.Drawing.Size(128, 24);
            this.cbForceIfOpen.TabIndex = 5;
            this.cbForceIfOpen.Text = "Force if open";
            this.cbForceIfOpen.UseVisualStyleBackColor = true;
            // 
            // cbDisableBinaryLogging
            // 
            this.cbDisableBinaryLogging.AutoSize = true;
            this.cbDisableBinaryLogging.Location = new System.Drawing.Point(63, 83);
            this.cbDisableBinaryLogging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDisableBinaryLogging.Name = "cbDisableBinaryLogging";
            this.cbDisableBinaryLogging.Size = new System.Drawing.Size(197, 24);
            this.cbDisableBinaryLogging.TabIndex = 4;
            this.cbDisableBinaryLogging.Text = "Disable Binary Logging";
            this.cbDisableBinaryLogging.UseVisualStyleBackColor = true;
            // 
            // tooltip1
            // 
            this.tooltip1.AutoPopDelay = 5000;
            this.tooltip1.InitialDelay = 100;
            this.tooltip1.ReshowDelay = 100;
            // 
            // BinlogConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1716, 883);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.gbDebug);
            this.Controls.Add(this.gbGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BinlogConfiguration";
            this.Text = "BinlogConfiguration";
            this.Load += new System.EventHandler(this.BinlogConfiguration_Load);
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.gbDebug.ResumeLayout(false);
            this.gbDebug.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Label lbCharsetDir;
        private System.Windows.Forms.Button bCharsetDir;
        private System.Windows.Forms.TextBox tbCharacterSetsDir;
        private System.Windows.Forms.GroupBox gbDebug;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.ComboBox cmbProtocol;
        private System.Windows.Forms.ComboBox cmbCompressionAlgorithm;
        private System.Windows.Forms.ComboBox cmbCharset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRewriteTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRewriteFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBindAdress;
        private System.Windows.Forms.Label lbExcludeGtids;
        private System.Windows.Forms.TextBox tbExcludeGtids;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbRowEventMaxSize;
        private System.Windows.Forms.TextBox tbServerId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbConServerId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbVerbose;
        private System.Windows.Forms.CheckBox cbPrintTableMetadata;
        private System.Windows.Forms.CheckBox cbPrintDefaults;
        private System.Windows.Forms.CheckBox cbHexdump;
        private System.Windows.Forms.CheckBox cbDebugInfo;
        private System.Windows.Forms.CheckBox cbDebugCheck;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbDebugOptions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbSkipGtids;
        private System.Windows.Forms.CheckBox cbRaw;
        private System.Windows.Forms.CheckBox cbIdempotent;
        private System.Windows.Forms.CheckBox cbGetServerPublicKey;
        private System.Windows.Forms.CheckBox cbForceRead;
        private System.Windows.Forms.CheckBox cbForceIfOpen;
        private System.Windows.Forms.CheckBox cbDisableBinaryLogging;
        private System.Windows.Forms.ComboBox cmbBase64;
        private System.Windows.Forms.CheckBox cbServerTime;
        private System.Windows.Forms.ToolTip tooltip1;
    }
}