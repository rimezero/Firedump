using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Firedump.models.databaseUtils;
using System.Runtime.InteropServices;

namespace Firedump.Forms.mysql.sqlviewer
{
    
    public partial class SqlDbViewerForm : Form, IIntelliSense
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetGUIThreadInfo(uint idThread, ref CaretPosition.frmTooltip.GUITHREADINFO lpgui);
        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        private bool skip = false;
        private string lastQuery = "";
        private string currentWord = "";
        private Stack<string> undoList = new Stack<string>();
        private Stack<string> redoList = new Stack<string>();
        private CaretPosition.frmTooltip.GUITHREADINFO guiInfo = new CaretPosition.frmTooltip.GUITHREADINFO();
        private Point point = new Point();
        private IntelliSense intellform;

        private mysql_servers server;
        //merge whene database mysql_server gets database field
        private string database;

        private string[] limits = new string[] {
            "Limit to 50 rows",
            "Limit to 100 rows",
            "Limit to 500 rows",
            "Limit to 1000 rows",
            "Limit to 5000 rows",
            "No Limit"
        };

        public SqlDbViewerForm(mysql_servers server,string database)
        {
            InitializeComponent();          
            DbConnection connection = DbConnection.Instance();
            connection.username = server.username;
            connection.password = server.password;
            connection.Host = server.host;
            connection.port = (int)server.port;

            try {
                if (connection.testConnection().wasSuccessful)
                {
                    this.server = server;
                    this.database = database;
                    List<string> tables = connection.getTables(database);
                    MysqlWords.tables = tables;

                    TreeNode[] nodearray = new TreeNode[tables.Count];
                    for (int i = 0; i < tables.Count; i++)
                    {
                        TreeNode treenode = new TreeNode(tables[i]);
                        treenode.ImageIndex = 1;
                        nodearray[i] = treenode;
                    }
                    for (int i = 0; i < MysqlWords.tables.Count; i++)
                    {
                        MysqlWords.tables[i] = MysqlWords.tables[i].ToUpper();
                    }

                    ImageList imagelist = new ImageList();
                    imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\databaseimage.bmp"));
                    imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\tableimage.bmp"));

                    TreeNode rootNode = new TreeNode("database:" + database, nodearray);
                    rootNode.ImageIndex = 1;
                    rootNode.ImageIndex = 0;
                    rootNode.Expand();

                    treeView1.Nodes.Add(rootNode);

                    treeView1.ImageIndex = 0;
                    treeView1.ImageList = imagelist;
                    
                }
                else
                {
                    MessageBox.Show("Couldent connect to " + database + " database");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            richTextBox1.Text = "";
            for(int i =0; i < limits.Length; i++)
            {
                toolStripComboBox1.Items.Add(limits[i]);
            }
            toolStripComboBox1.SelectedIndex = 2;

            intellform = new IntelliSense();
            intellform.setListener(this,this);
            intellform.Location = point;
            intellform.Show();
            intellform.Visible = false;
            intellform.Hide();
        }


        private void EvaluateCaretPosition()
        {
            Point caretPosition = new Point();

            // Fetch GUITHREADINFO
            GetCaretPosition();

            caretPosition.X = (int)guiInfo.rcCaret.Left + 5;
            caretPosition.Y = (int)guiInfo.rcCaret.Bottom;

            ClientToScreen(guiInfo.hwndCaret, ref caretPosition);
            
            point.X = caretPosition.X;
            point.Y = caretPosition.Y;

            string x = (caretPosition.X).ToString();
            string y = caretPosition.Y.ToString();
            Console.WriteLine("X:"+x);
            Console.WriteLine("y:" + y);
        }

        public void GetCaretPosition()
        {
            guiInfo = new CaretPosition.frmTooltip.GUITHREADINFO();
            guiInfo.cbSize = (uint)Marshal.SizeOf(guiInfo);
            // Get GuiThreadInfo into guiInfo
          
            GetGUIThreadInfo(0,ref guiInfo);
        }


        private void executesql_click(object sender, EventArgs e)
        {
            string queryText = richTextBox1.Text.ToUpper();
            if (queryText.Contains( "UPDATE ") || queryText.Contains(" INSERT ") || queryText.StartsWith("UPDATE ") || queryText.StartsWith("INSERT "))
                executeUpdateOrInsertQuery(richTextBox1.Text);
            else
                executeQuery(richTextBox1.Text);         
        }
        
        private void executeUpdateOrInsertQuery(string query)
        {
            if(!String.IsNullOrEmpty(query))
            {
                undoList.Push(query);
                try {
                    string connectionString = DbConnection.conStringBuilder(server.host, server.username, server.password, database,(int)server.port);
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        MySqlCommand command = new MySqlCommand();
                        command.Connection = con;
                        command.CommandText = query;
                        con.Open();
                        int numofrowsupdated = command.ExecuteNonQuery();
                        command.Dispose();

                        if (!String.IsNullOrEmpty(lastQuery))
                        {
                            string[] sqlarr = lastQuery.Split(' ');
                            richTextBox1.Text = "";
                            for (int i = 0; i < sqlarr.Length; i++)
                            {
                                richTextBox1.AppendText(sqlarr[i] + " ");
                                richTextBox1.SelectionStart = richTextBox1.TextLength;
                                setSqlHighlight();
                            }
                            executeQuery(lastQuery);
                        }

                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    DataSet dataset = new DataSet();
                    DataTable datatable = new DataTable("MySql Error");
                    datatable.Columns.Add(new DataColumn("Type", typeof(string)));
                    datatable.Columns.Add(new DataColumn("Message", typeof(string)));
                    DataRow datarow = datatable.NewRow();
                    datarow["Type"] = "MySql Error";
                    datarow["Message"] = ex.Message;
                    datatable.Rows.Add(datarow);
                    dataset.Tables.Add(datatable);

                    dataGridView1.DataSource = dataset.Tables[0];
                }
            }
        }

        private void executeQuery(string query)
        {
            
            if (!String.IsNullOrEmpty(query))
            {
                undoList.Push(query);
                string sql = limitQuery(query);

                try {
                    string connectionString = DbConnection.conStringBuilder(server.host, server.username, server.password, database, (int)server.port);
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection))
                        {
                            try
                            {
                                DataSet dataset = new DataSet();
                                BindingSource bs = new BindingSource();
                                adapter.Fill(dataset);

                                //if its byte[] == blob is db
                                //then set it to null
                                for(int i =0; i < dataset.Tables[0].Rows.Count; i++)
                                {
                                    for (int x =0; x < dataset.Tables[0].Rows[i].Table.Columns.Count; x++)
                                    {
                                        if (dataset.Tables[0].Rows[i].Table.Columns[x].DataType.ToString() == "System.Byte[]")
                                        {
                                            dataset.Tables[0].Rows[i][x] = null;
                                        }
                                    }
                                }

                                bs.DataSource = dataset.Tables[0].DefaultView;
                                dataGridView1.DataSource = bs;

                                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            }
                            catch (MySqlException ex)
                            {
                                
                                Console.WriteLine(ex.Message);
                               
                            }

                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }
            }
        }


        private void nodeSelectEvent(object sender, TreeViewEventArgs e)
        {
            if(!e.Node.Text.StartsWith("database:"))
            {
                string table = e.Node.Text;
                string sql = "SELECT * FROM "+table + " ";
                lastQuery = sql;
                string[] sqlarr = sql.Split(' ');
                richTextBox1.Text = "";
                for(int i =0; i < sqlarr.Length; i++)
                {
                    richTextBox1.AppendText(sqlarr[i] + " ");
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    setSqlHighlight();
                }
                executeQuery(sql);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
           
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
           
        }
        

        private void setSqlHighlight()
        {
            undoList.Push(richTextBox1.Text);

            int i = 0;
            string word = "";
            int c = 0;
            for (i = richTextBox1.SelectionStart - 2; i >= 0; i--)
            {
                if (richTextBox1.Text[i] == ' ' || i == 0)
                {
                    word = richTextBox1.Text.Substring(i, c + 1).Trim().ToUpper();
                    break;
                }
                c++;
            }
            int cursorpos = richTextBox1.SelectionStart;
            if (!String.IsNullOrEmpty(word))
            {
                if (i == -1)
                    i = 0;
              
                richTextBox1.Select(i, word.Length + 1);              
                    
                if (MysqlWords.words.Contains(word))
                {
                    richTextBox1.SelectionColor = Color.Blue;
                }
                else if (MysqlWords.tables.Contains(word))
                {
                    richTextBox1.SelectionColor = Color.Purple;
                }
                else if (MysqlWords.operators.Contains(word))
                {
                    richTextBox1.SelectionColor = Color.Red;
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Black;
                }

                richTextBox1.Select(richTextBox1.TextLength, 0);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
                richTextBox1.SelectionStart = cursorpos;
            }
        }

        private void onKeyUpEvent(object sender, KeyEventArgs e)
        {
            EvaluateCaretPosition();
            
            //space
            if (((char)e.KeyCode) == ' ' && ((char)e.KeyCode) != (char)Keys.Back)
            {
               setSqlHighlight();
            }
            else if (((char)e.KeyCode) == (char)Keys.Back)
            {
                //richTextBox1.Select(richTextBox1.TextLength,0);
                //richTextBox1.SelectionColor = richTextBox1.ForeColor;
            }

            currentWord = getCurrentWord();
            string word = currentWord.ToUpper();
            if(word.Length >= 3)
            {
                List<string> words = MysqlWords.words;
                List<string> tables = MysqlWords.tables;
                List<string> candidatewords = new List<string>();
                foreach(string i in words)
                {
                    if (i.Contains(word))
                        candidatewords.Add(i);
                }
                foreach(string t in tables)
                {
                    if (t.Contains(word))
                        candidatewords.Add(t);
                }

                if(candidatewords.Count > 0)
                {
                    intellform.Location = point;
                    intellform.Visible = false;
                    intellform.setItemsToListView(candidatewords);
                    intellform.Show(this);
                }
            } else
            {
                intellform.Visible = false;
            }
        
        }

        


        private string limitQuery(string query)
        {
            if (!query.ToUpper().StartsWith("SHOW"))
            {
                if (query.ToUpper().Contains("LIMIT"))
                {
                    return query;
                }
                else
                {
                    int pos = toolStripComboBox1.SelectedIndex;
                    if (pos == 0)
                    {
                        return query+" LIMIT 50";
                    }
                    if (pos == 1)
                        return query+" LIMIT 100";
                    if (pos == 2)
                        return query+" LIMIT 500";
                    if (pos == 3)
                        return query+" LIMIT 1000";
                    if (pos == 4)
                        return query+" LIMIT 5000";
                    return query;
                }
            }

            return query;
        }

        private void clearQueryField(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        

        private void unduTextClick(object sender, EventArgs e)
        {
            if(undoList.Count != 0)
            {
                string unduText = undoList.Pop();
                richTextBox1.Text = unduText;
                redoList.Push(unduText);
            }         
        }

        private void redoClick(object sender, EventArgs e)
        {
            if(redoList.Count != 0)
            {
                string content = redoList.Pop();
                richTextBox1.Text = content;
                undoList.Push(content);
            }
        }

        private void saveToExcelClick(object sender, EventArgs e)
        {
                    
        }



        private string getCurrentWord()
        {
            if (richTextBox1.SelectionStart > 1)
            {
                int cursorPosition = richTextBox1.SelectionStart;
                int nextSpace = richTextBox1.Text.IndexOf(' ', cursorPosition);
                int selectionStart = 0;
                string trimmedString = string.Empty;
                if (nextSpace != -1)
                {
                    trimmedString = richTextBox1.Text.Substring(0, nextSpace);
                }
                else
                {
                    trimmedString = richTextBox1.Text;
                }

                if (trimmedString.LastIndexOf(' ') != -1)
                {
                    selectionStart = 1 + trimmedString.LastIndexOf(' ');
                    trimmedString = trimmedString.Substring(1 + trimmedString.LastIndexOf(' '));
                }

                string word = richTextBox1.Text.Substring(selectionStart, trimmedString.Length);
                Console.WriteLine(word);
                return word;

                //select the word
                //richTextBox1.SelectionStart = selectionStart;
                //richTextBox1.SelectionLength = trimmedString.Length;
            }
            return "";
        }


        public void MyOnKeyUp(KeyPressEventArgs e, string value)
        {
            if (e.KeyChar == (char)Keys.Up || e.KeyChar == (char)Keys.Down)
            {

            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                richTextBox1.Text = richTextBox1.Text.Replace(currentWord, value);
                intellform.Visible = false;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;

                initText();
            }
            else
            {               
                if(e.KeyChar != (char)Keys.Back)
                {
                    Console.WriteLine(e.KeyChar.ToString());
                    richTextBox1.Focus();
                    richTextBox1.AppendText(e.KeyChar.ToString());
                } else
                {
                    richTextBox1.Focus();
                    richTextBox1.Text = richTextBox1.Text.Substring(0,richTextBox1.Text.Length-1);
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;

                    //initText();
                    string[] sqlarr = richTextBox1.Text.Split(' ');
                    richTextBox1.Text = "";
                    for (int i = 0; i < sqlarr.Length; i++)
                    {
                        int n = i;
                        int t = ++n;
                        if (t == sqlarr.Length)
                            richTextBox1.AppendText(sqlarr[i]);
                        else
                            richTextBox1.AppendText(sqlarr[i] + " ");

                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        setSqlHighlight();
                    }
                }                
            }

        }


        //---interface method
        public void onValueSelected(string value)
        {

            this.Invoke((MethodInvoker)delegate ()
            {
                richTextBox1.Text = richTextBox1.Text.Replace(currentWord, value);
                intellform.Visible = false;
                richTextBox1.SelectionStart = richTextBox1.Text.Length + 1;

                initText();
            });
                
        }




        private void initText()
        {
            string[] sqlarr = richTextBox1.Text.Split(' ');
            richTextBox1.Text = "";
            for (int i = 0; i < sqlarr.Length; i++)
            {              
                richTextBox1.AppendText(sqlarr[i] + " ");
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                setSqlHighlight();
            }
        }

       
    }
}
