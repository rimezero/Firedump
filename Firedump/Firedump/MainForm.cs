using Firedump;
using Firedump.Forms;
using Firedump.Forms.configuration;
using Firedump.Forms.email;
using Firedump.Forms.mysql;
using Firedump.Forms.mysql.sqlviewer;
using Firedump.Forms.mysql.status;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Firedump
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bDumpForm_Click(object sender, EventArgs e)
        {
           
        }

        private void bTest1_Click(object sender, EventArgs e)
        {
            Form form1 = new Test1();
            form1.Show();          
        }

        private void bGenConfig_Click(object sender, EventArgs e)
        {
            Form form = new GeneralConfiguration();
            form.Show();
        }

        private void email_click(object sender, EventArgs e)
        {
            Form form = new email();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewMySQLServer form = new NewMySQLServer();
            form.Show();
        }

        private void home_form_click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Firedump.Forms.SplashScreen sc = new Firedump.Forms.SplashScreen();
            sc.Show();
        }
    }
}
