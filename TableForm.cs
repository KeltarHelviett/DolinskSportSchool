using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;

namespace DolinskSportSchool
{
    public partial class TableForm : Form
    {
        public TableForm(int tag)
        {
            InitializeComponent();
            this.Tag = tag;
            fillDBGrid();

        }
        private void fillDBGrid()
        { 
            const string databaseName = @"C:\Users\Kelta\Desktop\Prj\DolinskSportSchool\testdb\dss.db";
            SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            int tg = Convert.ToInt32(this.Tag);
            SQLiteCommand command = new SQLiteCommand(SQLBuilder.BuildSelectPart(tg), connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DBGrid.Font = new Font("Arial Unicode MS", 8);
            DBGrid.DataSource = dt;
        }
    }
}
