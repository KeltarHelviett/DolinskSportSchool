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
