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
            CompanyInfo ci = new CompanyInfo();
            ci.Show();
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

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDialog.ShowDialog();

            if (SaveDialog.FileName != "")
            {
                MessageBox.Show(SaveDialog.FileName);
                if (System.IO.File.Exists(SaveDialog.FileName))
                    System.IO.File.Delete(SaveDialog.FileName);
                System.IO.File.Copy(MetaData.DBName, SaveDialog.FileName);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenDialog.FileName = MetaData.DBName;
            OpenDialog.ShowDialog();
            if (OpenDialog.FileName != "")
            {
                if (System.IO.File.Exists(OpenDialog.FileName))
                {
                    Notifier.CloseEverything();
                    MetaData.DBName = OpenDialog.FileName;
                    SQLBuilder.UpdateConnection();
                    FileStream fs = new FileStream(Application.StartupPath + "\\config", FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(fs);
                    writer.WriteLine(MetaData.DBName);
                    writer.Close();
                    fs.Close();
                    
                }
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            s += "CREATE TABLE COACHES(";
            s += "ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,";
            s += "COACH_FFM TEXT NOT NULL";
            s += ");";

            s += "CREATE TABLE SPORTS(";
            s += "ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,";
            s += "SPORT_NAME TEXT NOT NULL";
            s += ");";

            s += "CREATE TABLE SCHOOLS(";
            s += "ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,";
            s += "SCHOOL_NAME TEXT NOT NULL";
            s += ");";

            s += "CREATE TABLE CLASSES(";
            s += "ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,";
            s += "CLASS_NAME TEXT NOT NULL";
            s += ");";

            s += "CREATE TABLE GENDERS(";
            s += "ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,";
            s += "GENDER TEXT NOT NULL";
            s += ");";

            s += "CREATE TABLE STAGES(";
            s += "ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,";
            s += "STAGE_NAME TEXT NOT NULL";
            s += ");";

            s += "CREATE TABLE STUDENTS( ";
            s += "ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
              + "FAMILY_NAME TEXT NOT NULL,"
              + "FIRST_NAME TEXT NOT NULL,"
              + "BIRTH_DATE TEXT NOT NULL,"
              + "GENDER_ID INTEGER NOT NULL REFERENCES GENDERS(ID),"
              + "SCHOOL_ID INTEGER NOT NULL REFERENCES SCHOOLS(ID),"
              + "CLASS_ID INTEGER NOT NULL REFERENCES CLASSES(ID),"
              + "SPORT_ID INTEGER NOT NULL REFERENCES SPORTS(ID),"
              + "COACH_ID INTEGER NOT NULL REFERENCES COACHES(ID),"
              + "STAGE_ID INTEGER NOT NULL REFERENCES STAGES(ID)"
              + ");";

            MetaData.DBName = Application.StartupPath + "\\asd.db";

            SQLBuilder.UpdateConnection();
            SQLiteCommand command = new SQLiteCommand(s, SQLBuilder.Connection);
            SQLiteConnection.CreateFile(MetaData.DBName);
            SQLBuilder.Connection.Open();
            command.ExecuteNonQuery();
            SQLBuilder.Connection.Close();
        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeveloperInfo di = new DeveloperInfo();
            di.Show();
        }
    }
}
