namespace Firedump.Forms.schedule
{
    partial class NewJobForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cblocation = new System.Windows.Forms.ComboBox();
            this.cbchoosealldatabases = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbdatabase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbactivate = new System.Windows.Forms.CheckBox();
            this.numericMinute = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericHour = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericDay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.tbjobname = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbIncremental = new System.Windows.Forms.CheckBox();
            this.numericIBInterval = new System.Windows.Forms.NumericUpDown();
            this.numericIDBInterval = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDay)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIBInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIDBInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cblocation);
            this.groupBox1.Controls.Add(this.cbchoosealldatabases);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbdatabase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbServers);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(646, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Server";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Location";
            // 
            // cblocation
            // 
            this.cblocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cblocation.FormattingEnabled = true;
            this.cblocation.Location = new System.Drawing.Point(422, 63);
            this.cblocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cblocation.Name = "cblocation";
            this.cblocation.Size = new System.Drawing.Size(193, 28);
            this.cblocation.TabIndex = 9;
            // 
            // cbchoosealldatabases
            // 
            this.cbchoosealldatabases.AutoSize = true;
            this.cbchoosealldatabases.Location = new System.Drawing.Point(218, 105);
            this.cbchoosealldatabases.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbchoosealldatabases.Name = "cbchoosealldatabases";
            this.cbchoosealldatabases.Size = new System.Drawing.Size(129, 24);
            this.cbchoosealldatabases.TabIndex = 8;
            this.cbchoosealldatabases.Text = "all databases";
            this.cbchoosealldatabases.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Database";
            // 
            // cmbdatabase
            // 
            this.cmbdatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdatabase.FormattingEnabled = true;
            this.cmbdatabase.Location = new System.Drawing.Point(218, 63);
            this.cmbdatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbdatabase.Name = "cmbdatabase";
            this.cmbdatabase.Size = new System.Drawing.Size(193, 28);
            this.cmbdatabase.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server";
            // 
            // cmbServers
            // 
            this.cmbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.Location = new System.Drawing.Point(14, 63);
            this.cmbServers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(193, 28);
            this.cmbServers.TabIndex = 4;
            this.cmbServers.SelectionChangeCommitted += new System.EventHandler(this.cmbServers_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbactivate);
            this.groupBox2.Controls.Add(this.numericMinute);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericHour);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericDay);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 361);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(648, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Date";
            // 
            // cbactivate
            // 
            this.cbactivate.AutoSize = true;
            this.cbactivate.Checked = true;
            this.cbactivate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbactivate.Location = new System.Drawing.Point(15, 105);
            this.cbactivate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbactivate.Name = "cbactivate";
            this.cbactivate.Size = new System.Drawing.Size(169, 24);
            this.cbactivate.TabIndex = 6;
            this.cbactivate.Text = "Activate On Create";
            this.cbactivate.UseVisualStyleBackColor = true;
            // 
            // numericMinute
            // 
            this.numericMinute.Location = new System.Drawing.Point(326, 55);
            this.numericMinute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericMinute.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMinute.Name = "numericMinute";
            this.numericMinute.Size = new System.Drawing.Size(130, 26);
            this.numericMinute.TabIndex = 5;
            this.numericMinute.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Minute";
            // 
            // numericHour
            // 
            this.numericHour.Location = new System.Drawing.Point(170, 55);
            this.numericHour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericHour.Name = "numericHour";
            this.numericHour.Size = new System.Drawing.Size(130, 26);
            this.numericHour.TabIndex = 3;
            this.numericHour.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hour";
            // 
            // numericDay
            // 
            this.numericDay.Location = new System.Drawing.Point(15, 55);
            this.numericDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericDay.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDay.Name = "numericDay";
            this.numericDay.Size = new System.Drawing.Size(130, 26);
            this.numericDay.TabIndex = 1;
            this.numericDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Day Of the Week";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(552, 519);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set Job";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.setjobclick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 527);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Job Name:";
            // 
            // tbjobname
            // 
            this.tbjobname.Location = new System.Drawing.Point(102, 522);
            this.tbjobname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbjobname.Name = "tbjobname";
            this.tbjobname.Size = new System.Drawing.Size(278, 26);
            this.tbjobname.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.numericIDBInterval);
            this.groupBox3.Controls.Add(this.numericIBInterval);
            this.groupBox3.Controls.Add(this.cbIncremental);
            this.groupBox3.Location = new System.Drawing.Point(18, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(646, 164);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Incremental";
            // 
            // cbIncremental
            // 
            this.cbIncremental.AutoSize = true;
            this.cbIncremental.Location = new System.Drawing.Point(13, 35);
            this.cbIncremental.Name = "cbIncremental";
            this.cbIncremental.Size = new System.Drawing.Size(231, 24);
            this.cbIncremental.TabIndex = 0;
            this.cbIncremental.Text = "Enable Incremental Backup";
            this.cbIncremental.UseVisualStyleBackColor = true;
            // 
            // numericIBInterval
            // 
            this.numericIBInterval.Location = new System.Drawing.Point(15, 117);
            this.numericIBInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericIBInterval.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericIBInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericIBInterval.Name = "numericIBInterval";
            this.numericIBInterval.Size = new System.Drawing.Size(130, 26);
            this.numericIBInterval.TabIndex = 2;
            this.numericIBInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericIDBInterval
            // 
            this.numericIDBInterval.Location = new System.Drawing.Point(170, 117);
            this.numericIDBInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericIDBInterval.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericIDBInterval.Name = "numericIDBInterval";
            this.numericIDBInterval.Size = new System.Drawing.Size(130, 26);
            this.numericIDBInterval.TabIndex = 3;
            this.numericIDBInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Intervals";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Incremental";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(170, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Incremental Delta";
            // 
            // NewJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 576);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tbjobname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NewJobForm";
            this.Text = "JobForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDay)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIBInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIDBInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbdatabase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericDay;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbjobname;
        private System.Windows.Forms.CheckBox cbchoosealldatabases;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cblocation;
        private System.Windows.Forms.CheckBox cbactivate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericIDBInterval;
        private System.Windows.Forms.NumericUpDown numericIBInterval;
        private System.Windows.Forms.CheckBox cbIncremental;
    }
}