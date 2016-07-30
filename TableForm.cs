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
using System.IO;

namespace DolinskSportSchool
{
    
    public partial class TableForm : Form
    {
        private FilterList Flist;

        public TableForm(int tag)
        {
            InitializeComponent();
            this.Tag = tag;
            this.Text = MetaData.tables[Convert.ToInt32(this.Tag)].displayName;
            FillDBGrid();
            AdjustColNames();
            CreateFilters();

        }
        private void FillDBGrid()
        { 
            SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", MetaData.DBName));
            connection.Open();
            int tg = Convert.ToInt32(this.Tag);
            SQLiteCommand command = new SQLiteCommand(SQLBuilder.BuildSelectPart(tg), connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DBGrid.Font = new Font("Arial Unicode MS", 10);
            DBGrid.DataSource = dt;
            connection.Close();
        }

        private void AdjustColNames()
        {
            for (int i = 0; i < DBGrid.ColumnCount; i++)
            {
                DBGrid.Columns[i].HeaderText = MetaData.tables[Convert.ToInt32(this.Tag)].fields[i + 1].displayName;
            }
        }

        private void CreateFilters()
        {
            int tg = (int)this.Tag;
            List<List<string>> l = new List<List<string>>();
            for (int i = 1; i < MetaData.tables[tg].fields.Count; i++)
            {
                List<string> ls = new List<string>();
                if (MetaData.tables[tg].fields[i].type == DataType.Date)
                {
                    ls.Add(MetaData.tables[tg].fields[i].displayName);
                    ls.Add(Convert.ToString(tg));
                    ls.Add(Convert.ToString(i));
                    ls.Add("2");
                    l.Add(ls);
                }
                else if (MetaData.tables[tg].fields[i].referenceTable != -1)
                {
                    int rt = MetaData.tables[tg].fields[i].referenceTable;
                    for (int j = 1; j < MetaData.tables[rt].fields.Count; j++)
                    {
                        ls.Add(MetaData.tables[rt].fields[j].displayName);
                        ls.Add(Convert.ToString(rt));
                        ls.Add(Convert.ToString(j));
                        ls.Add("0");
                        l.Add(ls);
                        ls = new List<string>();
                    }
                }
                else
                {
                    ls.Add(MetaData.tables[tg].fields[i].displayName);
                    ls.Add(Convert.ToString(tg));
                    ls.Add(Convert.ToString(i));
                    ls.Add("1");
                    l.Add(ls);
                }
            }
            Flist = new FilterList(FilterPanel, SelectionFilter, l);
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", MetaData.DBName));
            connection.Open();
            int tg = Convert.ToInt32(this.Tag);
            List<ParameterInfo> prms;
            SQLiteCommand command = new SQLiteCommand(
                string.Format("{0} WHERE {1}", SQLBuilder.BuildSelectPart(tg), SQLBuilder.BuildFiltersWherePart(Flist, out prms)), connection);
            File.WriteAllText(@"C:\Users\Kelta\Desktop\sqltest.txt", command.CommandText);
            command.Prepare();
            for (int i = 0; i < prms.Count; i++)
            {
                switch (prms[i].type)
                {
                    case DataType.String:
                        command.Parameters.AddWithValue(prms[i].id, prms[i].value);
                        break;
                    case DataType.Integer:
                        command.Parameters.AddWithValue(prms[i].id, Convert.ToInt32(prms[i].value));
                        break;
                    case DataType.Date:
                        SQLiteParameter strParam = new SQLiteParameter(prms[i].id, DbType.String, 100);
                        strParam.Value = Convert.ToDateTime(prms[i].value).ToString("yyyy-MM-dd");
                        command.Parameters.Add(strParam);
                        break;
                }
            }
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //DBGrid.Font = new Font("Arial Unicode MS", 10);
            DBGrid.DataSource = dt;
            connection.Close();
        }
    }
}
