using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HamSpotsCallEdit
{
    public partial class Form1 : Form
    {
        string? webData = null;
        private bool haveEdge;  //Hmmm...  I wonder if I can use this to determine which browser to use?
        private bool haveBrave;
        private bool haveChrome;

        public Form1()
        {
            InitializeComponent();

        }

        public static void KillMSEdgeProcesses()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("msedge"))
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        void KillAll(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                foreach (var process2 in Process.GetProcessesByName(processName))
                {
                    process2.CloseMainWindow();
                }
            }
            Thread.Sleep(1000);
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill(); ;
            }
        }

        bool haveEdgeData()
        {
            webData = GetLocalAppDataPath("Microsoft/Edge/User Data/Default/Web Data");
            if (File.Exists(webData))
            {
                haveEdge = true;
                return true;
            }
            return false;
        }

        bool haveBraveData()
        {
            webData = GetLocalAppDataPath("BraveSoftware\\Brave-Browser\\User Data\\Default\\Web Data");
            if (File.Exists(webData))
            {
                haveBrave = true;
                return true;
            }
            return false;

        }

        bool haveChromeData()
        {
            webData = GetLocalAppDataPath("Google\\Chrome\\User Data\\Default\\Web Data");
            if (File.Exists(webData))
            {
                haveChrome = true;
                return true;
            }
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int nBrowsers = 0;
            if (!haveEdgeData()) menuStrip1.Items.Remove(openEdgeToolStripMenuItem);
            if (!haveBraveData()) menuStrip1.Items.Remove(openBraveToolStripMenuItem);
            if (!haveChromeData()) menuStrip1.Items.Remove(openChromeToolStripMenuItem);

            do
            {
                nBrowsers = 0;
                Process[] processes = Process.GetProcessesByName("msedge");
                if (processes.Length > 0)
                {
                    webData = GetLocalAppDataPath("Microsoft/Edge/User Data/Default/Web Data");
                    if (File.Exists(webData))
                    {
                        nBrowsers++;
                    }
                }
                processes = Process.GetProcessesByName("brave");
                if (processes.Length > 0)
                {
                    webData = GetLocalAppDataPath("BraveSoftware\\Brave-Browser\\User Data\\Default\\Web Data");
                    if (File.Exists(webData))
                    {
                        nBrowsers++;
                    }
                }
                processes = Process.GetProcessesByName("chrome");
                if (processes.Length > 0)
                {
                    webData = GetLocalAppDataPath("Google\\Chrome\\User Data\\Default\\Web Data");
                    nBrowsers++;
                }
                if (webData == null)
                {
                    MessageBox.Show("Defaulting to Edge data", "HamSpotsCallEdit");
                    webData = GetLocalAppDataPath("Microsoft/Edge/User Data/Default/Web Data");
                    //Application.Exit();
                }
                else if (nBrowsers == 0)
                {
                    AccessSQliteDB();
                }
                else if (nBrowsers > 0)
                {
                    var reply = MessageBox.Show(Text = $"Found {nBrowsers} browser(s)\nDo you want me to close all?", "HamSpotsCallEdit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (reply == DialogResult.Yes)
                    {
                        KillAll("msedge");
                        KillAll("brave");
                        KillAll("chrome");
                    }
                    else
                    {
                        if (nBrowsers == 0) AccessSQliteDB();
                        nBrowsers = 0; // force the loop to end
                        //MessageBox.Show("Exiting without closing browsers", "HamSpotsCallEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Application.Exit();
                    }
                }
            } while (nBrowsers > 0);
        }

        // Edge uses SQLite to store autofill data
        // CREATE TABLE autofill(name VARCHAR, value VARCHAR, value_lower VARCHAR, date_created INTEGER DEFAULT 0, date_last_used
        // INSERT INTO autofill VALUES('hist_call_1','wa1sxk','wa1sxk',1688053227,1688058074,2);
        private void AccessSQliteDB()
        {
            var dataSource = "Data Source=" + webData;
            try
            {
                //var db = new SqliteConnectionStringBuilder("Data Source=C:/Users/mdbla/AppData/Local/Microsoft/Edge/User Data/Default/Web Data");
                var db = new SqliteConnectionStringBuilder(dataSource);

                using (var connection = new SqliteConnection(db.ConnectionString))
                {
                    connection.Open();
                    var readCmd = connection.CreateCommand();
                    readCmd.CommandText = "SELECT value FROM autofill where name='hist_call_1';";
                    using (var reader = readCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //var output = $"Reading from table: ID = {reader.GetString(0)}, Value = {reader.GetString(1)}";
                            //Console.WriteLine(output);
                            //richTextBox1.AppendText(output + "\n");
                            dataGridView1.Rows.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred accessing {dataSource}\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = "Data Source=" + webData;
                var db = new SqliteConnectionStringBuilder(dataSource);
                using (var connection = new SqliteConnection(db.ConnectionString))
                {
                    connection.Open();
                    var deleteCmd = connection.CreateCommand();
                    deleteCmd.CommandText = "DELETE FROM autofill where name='hist_call_1';";
                    var ret = deleteCmd.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        MessageBox.Show($"Deleted {ret} rows");
                        dataGridView1.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to delete rows");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred tryin to dolete all: : {ex.Message}\n{ex.StackTrace}");

            }
        }

        string GetLocalAppDataPath(string filename)
        {
            // Get the LOCALAPPDATA path
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Append the filename to the path
            string fullFilePath = System.IO.Path.Combine(localAppDataPath, filename);

            return fullFilePath;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sender == null) throw new ArgumentNullException(nameof(sender));
            // Ignore if a column or row header is clicked
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DataGridViewCell clickedCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];

                        // Here you can do whatever you want with the cell
                        this.dataGridView1.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                        // Get mouse position relative to the vehicles grid
                        var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);

                        // Show the context menu
                        this.contextMenuStrip1.Show(dataGridView1, relativeMousePosition);
                    }
                }
            }
        }

        private bool DeleteCall(string call)
        {
            try
            {
                var dataSource = "Data Source=" + webData;
                var db = new SqliteConnectionStringBuilder(dataSource);

                using (var connection = new SqliteConnection(db.ConnectionString))
                {
                    connection.Open();
                    var deleteCmd = connection.CreateCommand();
                    deleteCmd.CommandText = "DELETE FROM autofill where name='hist_call_1' and value='" + call + "';";
                    var ret = deleteCmd.ExecuteNonQuery();
                    if (ret == 1)
                    {
                        //MessageBox.Show($"Deleted {call}");
                        return true;
                    }
                    MessageBox.Show($"Failed to delete {call}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred tryin to dolete all: : {ex.Message}\n{ex.StackTrace}");

            }
            return false;
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRow = dataGridView1.CurrentCell.RowIndex;
            var call = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();
            if (call != null && DeleteCall(call))
            {
                dataGridView1.Rows.RemoveAt(currentRow);
            }
        }

        private void openEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            haveEdge = true;
            webData = GetLocalAppDataPath("Microsoft/Edge/User Data/Default/Web Data");
            AccessSQliteDB();
        }

        private void openChromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            haveChrome = true;
            webData = GetLocalAppDataPath("Google\\Chrome\\User Data\\Default\\Web Data");
            AccessSQliteDB();
        }

        private bool braveIsRunning()
        {
            foreach (var process in Process.GetProcessesByName("brave"))
            {
                return true;
            }
            return false;
        }
        private void openBraveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            haveBrave = true;
            webData = GetLocalAppDataPath("BraveSoftware\\Brave-Browser\\User Data\\Default\\Web Data");
            if (braveIsRunning())
            {
                MessageBox.Show("Brave is running, close it first");
            }
            else
            {
                AccessSQliteDB();
            }
        }
    }
}