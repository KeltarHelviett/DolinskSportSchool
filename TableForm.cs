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
        private TableEdit TEdit;

        public TableForm(int tag)
        {
            InitializeComponent();
            this.Tag = tag;
            this.Text = MetaData.tables[Convert.ToInt32(this.Tag)].displayName;
            FillDBGrid();
            AdjustColNames();
            CreateFilters();
            CreateTableEdit();
            Notifier.LookAfterTable(this);

        }
        private void FillDBGrid()
        { 
            SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", MetaData.DBName));
            connection.Open();
            int tg = Convert.ToInt32(this.Tag);
            SQLiteCommand command = new SQLiteCommand(
                SQLBuilder.BuildSelectPart(tg).Insert(8, MetaData.tables[(int)Tag].name + ".ID, "), connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DBGrid.Font = new Font("Time New Roman", 14);
            DBGrid.DataSource = dt;
            DBGrid.Columns[0].Visible = false;
            Table t = MetaData.tables[(int)Tag];
            int curCol = 1;
            for (int i = 1; i < t.fields.Count; i++)
            {
                if (t.fields[i].displayName == "")
                    continue;
                if (t.fields[i].referenceTable == -1)
                {
                    DBGrid.Columns[curCol].DefaultCellStyle.Alignment = t.fields[i].aligment;
                    curCol++;
                }
                else
                {
                    Table tt = MetaData.tables[t.fields[i].referenceTable];
                    for (int j = 0; j < tt.fields.Count; j++)
                    {
                        if (tt.fields[j].displayName == "")
                            continue;
                        DBGrid.Columns[curCol].DefaultCellStyle.Alignment = tt.fields[j].aligment;
                        curCol++;
                    }
                }
            }
            connection.Close();
        }

        private void AdjustColNames()
        {
            for (int i = 0; i < DBGrid.ColumnCount; i++)
            {
                DBGrid.Columns[i].HeaderText = MetaData.tables[Convert.ToInt32(this.Tag)].fields[i].displayName;
            }
        }

        private void CreateTableEdit()
        {
            List<List<string>> values = new List<List<string>>();
            int realColCount = DBGrid.Columns.Count;
            int displayIndex = 1;
            for (int i = 0; i < DBGrid.Columns.Count; i++)
            {
                if (!DBGrid.Columns[i].Visible)
                {
                    --realColCount;
                    continue;
                }

                List<string> ls = new List<string>();
                ls.Add(DBGrid.Columns[i].HeaderText);
                ls.Add(i.ToString());
                ls.Add(Convert.ToString(displayIndex++));
                values.Add(ls);
            }
            TEdit = new TableEdit(ColumnViewPanel, values, realColCount, DBGrid);
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
                string.Format("{0} WHERE {1}", SQLBuilder.BuildSelectPart(tg).Insert(8, MetaData.tables[(int)Tag].name + ".ID, "), SQLBuilder.BuildFiltersWherePart(Flist, out prms)), connection);
            File.WriteAllText(@"C:\Users\Kelta\Desktop\sqltest.txt", command.CommandText);
            command.Prepare();
            if (prms.Count == 0)
            {
                connection.Close();
                FillDBGrid();
                return;
            }
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
            DBGrid.Columns[0].Visible = false;
            
            connection.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Card f = new Card(-1, (int)this.Tag);
            f.Text = "Добавление";
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Card f = new Card(Convert.ToInt32(DBGrid.SelectedCells[0].Value), (int)Tag);
            f.Text = "Редактирование";
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Удалить запись?", "Удалить запись?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", MetaData.DBName));
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                string id = Convert.ToString(DBGrid.SelectedCells[0].Value);
                command.CommandText = "DELETE FROM " + MetaData.tables[(int)Tag].name + " WHERE ID = " + id;
                command.Connection = connection;
                command.ExecuteNonQuery();
                Notifier.UpdateTables();
            }
        }

        public void UpdateTable()
        {
            AcceptBtn_Click(null, null);
        }

        private void CloseTable(object sender, FormClosingEventArgs e)
        {
            Notifier.DropTable(this);
        }
    }
}
