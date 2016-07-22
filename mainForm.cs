using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace DolinskSportSchool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string databaseName = @"C:\Users\Kelta\Desktop\Prj\DolinskSportSchool\testdb\dss.db";
            SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'STAGES';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                string s = record["STAGE_NAME"].ToString();
                Encoding utf8 = Encoding.UTF8;
                Encoding cp1251 = Encoding.GetEncoding(1251);
                byte[] inUtf8 = utf8.GetBytes(s);
                byte[] cp1251Bytes = Encoding.Convert(utf8, cp1251, inUtf8);
                char[] cp1251Chars = new char[cp1251.GetCharCount(cp1251Bytes, 0, cp1251Bytes.Length)];
                cp1251.GetChars(cp1251Bytes, 0, cp1251Bytes.Length, cp1251Chars, 0);
                string ns = new string(cp1251Chars);
                MessageBox.Show(s);
                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem tables = Menu.Items[0] as ToolStripMenuItem;
            for (int i = 0; i < MetaData.tables.Count; i++)
            {
                if (MetaData.tables[i].displayName != "")
                { 
                    ToolStripMenuItem m = new ToolStripMenuItem(MetaData.tables[i].displayName);
                    m.Click += new EventHandler(onMenuTableClick);
                    m.Tag = i;
                    tables.DropDownItems.Add(m);

                }
            }
        }

        private void onMenuTableClick(object sender, EventArgs e)
        {
            ToolStripMenuItem m = sender as ToolStripMenuItem;
            TableForm f = new TableForm(Convert.ToInt32(m.Tag));
            f.Show();
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
         
        }
    }
}
