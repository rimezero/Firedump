using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.mysql.sqlviewer
{
    public partial class IntelliSense : Form
    {
        private IIntelliSense listener;
        private SqlDbViewerForm form;
        public IntelliSense()
        {
            InitializeComponent();
            this.listView1.KeyPress += IntelliSense_KeyUp;
        }

        public void setListener(IIntelliSense listener, SqlDbViewerForm form)
        {
            this.listener = listener;
            this.form = form;
        }


        public void setItemsToListView(List<string> items)
        {
            this.listView1.Items.Clear();
            foreach (string item in items)
                this.listView1.Items.Add(item);
            listView1.Items[0].Selected = true;
            listView1.Select();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string value = listView1.SelectedItems[0].Text;

            if(listener != null)
            {
                listener.onValueSelected(value);
            }
        }

        private void IntelliSense_KeyUp(object sender, KeyPressEventArgs e)
        {
            string value = listView1.SelectedItems[0].Text;
            form.MyOnKeyUp(e,value);
        }
    }
}
