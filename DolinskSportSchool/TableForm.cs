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
        private List<int> DateCols;

        public TableForm(int tag)
        {
            InitializeComponent();
            this.Tag = tag;
            this.Text = MetaData.tables[Convert.ToInt32(this.Tag)].displayName;
            GetDateCols();
            FillDBGrid();           
            CreateFilters();
            CreateTableEdit();
            Notifier.LookAfterTable(this);

        }

        public void CreateDBGridMenu()
        {

        }

        public void RefillRowNumColumn()
        {
            DBGrid.Columns[DBGrid.Columns.Count - 1].HeaderText = "№";
            DBGrid.Columns[DBGrid.Columns.Count - 1].Name = "rownum";
            DBGrid.Columns[DBGrid.Columns.Count - 1].ValueType = typeof(string);
            for (int i = 0; i < DBGrid.RowCount; i++)
            {
                DBGrid[DBGrid.Columns.Count - 1, i].Value = (i + 1).ToString() + ".";
            }
            DBGrid.Columns[DBGrid.Columns.Count - 1].DisplayIndex = 0;
        }

        public void GetDateCols()
        {
            DateCols = new List<int>();
            int curCol = 1;
            Table t = MetaData.tables[(int)Tag];
            for (int i = 1; i < t.fields.Count; i++)
            {
                if (t.fields[i].displayName == "")
                    continue;
                if (t.fields[i].referenceTable == -1)
                {
                    if (t.fields[i].type == DataType.Date)
                    {
                        DateCols.Add(curCol);
                    }
                    curCol++;
                }
                else
                {
                    Table tt = MetaData.tables[t.fields[i].referenceTable];
                    for (int j = 0; j < tt.fields.Count; j++)
                    {
                        if (tt.fields[j].displayName == "")
                            continue;
                        if (tt.fields[j].type == DataType.Date)
                            DateCols.Add(curCol);
                        curCol++;
                    }
                }
            }

        }

        private void FillDBGrid()
        {
            SQLBuilder.Connection.Open();
            int tg = Convert.ToInt32(this.Tag);
            SQLiteCommand command = new SQLiteCommand(
                SQLBuilder.BuildSelectPart(tg).Insert(8, MetaData.tables[(int)Tag].name + ".ID, ") +
                SQLBuilder.BuildOrderPart(tg), SQLBuilder.Connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DBGrid.Font = new Font("Time New Roman", 14);
            DBGrid.DataSource = dt;
            RefillRowNumColumn();
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
            ChangeDateFormat(DateCols);
            DBGrid.Columns[0].Visible = false;
            AdjustColNames();
            UpdateStats();
            SQLBuilder.Connection.Close();
        }

        private void ChangeDateFormat(List<int> cols)
        {
            for (int i = 0; i < cols.Count; i++)
            {
                for (int j = 0; j < DBGrid.RowCount; j++)
                {
                    DBGrid[cols[i], j].Value = Convert.ToDateTime(DBGrid[cols[i], j].Value).ToString("dd.MM.yyyy");

                }

            }
        }

        private void AdjustColNames()
        {
            for (int i = 0; i < DBGrid.ColumnCount - 1; i++)
            {
                if (MetaData.tables[Convert.ToInt32(this.Tag)].fields[i].displayName != "")
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
                if (!DBGrid.Columns[i].Visible || DBGrid.Columns[i].HeaderText == "№")
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
            DBGrid.DataSource = null;
            DBGrid.Rows.Clear();
            int tg = Convert.ToInt32(this.Tag);
            List<ParameterInfo> prms;
            SQLiteCommand command = new SQLiteCommand(
                string.Format("{0} WHERE {1}", SQLBuilder.BuildSelectPart(tg).Insert(8, MetaData.tables[(int)Tag].name + ".ID, "), 
                SQLBuilder.BuildFiltersWherePart(Flist, out prms)) +
                SQLBuilder.BuildOrderPart(tg), SQLBuilder.Connection);
            command.Prepare();
            if (prms.Count == 0)
            {
                FillDBGrid();
                SQLBuilder.Connection.Close();
                return;
            }
            SQLBuilder.Connection.Open();
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
            RefillRowNumColumn();
            AdjustColNames();
            ChangeDateFormat(DateCols);
            DBGrid.Columns[0].Visible = false;
            SQLBuilder.Connection.Close();
            UpdateStats();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Card f = new Card(-1, (int)this.Tag);
            f.Text = "Добавление";
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Card f = new Card(Convert.ToInt32(DBGrid.SelectedCells[0].Value), (int) Tag);
                f.Text = "Редактирование";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не выбрана запись для редактирования");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (DBGrid.SelectedCells.Count <= 0)
                return;
            if (MessageBox.Show(
                "Удалить запись?", "Удалить запись?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLBuilder.Connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                string id = Convert.ToString(DBGrid.SelectedCells[0].Value);
                command.CommandText = "DELETE FROM " + MetaData.tables[(int)Tag].name + " WHERE ID = " + id;
                command.Connection = SQLBuilder.Connection;
                command.ExecuteNonQuery();
                SQLBuilder.Connection.Close();
                Notifier.UpdateTables();               
            }
        }

        public void UpdateTable(int id = 0)
        {
            AcceptBtn_Click(null, null);
            if (DBGrid.Rows.Count <= 0)
                return;
            if (id == 0)
                DBGrid.Rows[0].Selected = true;
            else if (id == -1)
            {
                DBGrid.Rows[0].Selected = false;
                DBGrid.Rows[DBGrid.Rows.Count - 1].Selected = true;
                DBGrid.FirstDisplayedScrollingRowIndex = DBGrid.SelectedRows[0].Index;
            }
            else
            {
                DBGrid.Rows[0].Selected = false;
                for (int i = 0; i < DBGrid.Rows.Count; i++)
                {
                    if ((Int64)DBGrid.Rows[i].Cells[0].Value == id)
                    {
                        DBGrid.Rows[i].Selected = true;
                        DBGrid.FirstDisplayedScrollingRowIndex = DBGrid.SelectedRows[0].Index;
                    }
                }
            }
            
        }

        private void CloseTable(object sender, FormClosingEventArgs e)
        {
            Notifier.DropTable(this);
        }

        private void UpdateStats()
        {
            Stats.Text = "Кол-во записей: " + DBGrid.RowCount.ToString();
        }

        private void DBGrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditBtn_Click(null, null);
        }

        private void MTableDuplicates_Click(object sender, EventArgs e)
        {
            SQLBuilder.Connection.Open();
            if (MetaData.tables[(int)Tag].name == "STUDENTS")
            {
                string s = SQLBuilder.BuildSelectPart((int)Tag).Insert(8, MetaData.tables[(int)Tag].name + ".ID, ");
                s += " WHERE EXISTS (SELECT t2.FIRST_NAME, t2.FAMILY_NAME, t2.BIRTH_DATE FROM STUDENTS t2 "
                    + "  WHERE STUDENTS.FIRST_NAME = t2.FIRST_NAME AND STUDENTS.FAMILY_NAME = t2.FAMILY_NAME AND STUDENTS.ID <> t2.ID) ";
                SQLiteCommand command = new SQLiteCommand(s, SQLBuilder.Connection);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SQLBuilder.Connection.Close();
                int yellow = dt.Rows.Count;
                SQLBuilder.Connection.Open();
                s = SQLBuilder.BuildSelectPart((int)Tag).Insert(8, MetaData.tables[(int)Tag].name + ".ID, ");
                s += " WHERE EXISTS (SELECT t2.FIRST_NAME, t2.FAMILY_NAME, t2.BIRTH_DATE FROM STUDENTS t2 "
                    + "  WHERE STUDENTS.FIRST_NAME = t2.FIRST_NAME AND STUDENTS.FAMILY_NAME = t2.FAMILY_NAME"
                    + " AND DATE(STUDENTS.BIRTH_DATE) = DATE(t2.BIRTH_DATE) AND STUDENTS.ID<> t2.ID) ";
                SQLiteCommand com = new SQLiteCommand(s, SQLBuilder.Connection);
                SQLiteDataAdapter da1 = new SQLiteDataAdapter(com);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dt.Merge(dt1);
                DBGrid.DataSource = dt;
                for (int i = 0; i < yellow; i++)
                {
                    DBGrid.Rows[i].DefaultCellStyle.ForeColor = Color.GreenYellow;
                }

                for (int i = yellow; i < DBGrid.RowCount; i++)
                {
                    DBGrid.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                ChangeDateFormat(DateCols);
                DBGrid.Columns[0].Visible = false;
            }
            else
            {
                string s = SQLBuilder.BuildSelectPart((int)Tag).Insert(8, MetaData.tables[(int)Tag].name + ".ID, ");
                s += "WHERE EXISTS ( SELECT ";
                string w = " WHERE ";
                Table t = MetaData.tables[(int)Tag];
                for (int i = 0; i < t.fields.Count; i++)
                {
                    s += " t2." + t.fields[i].name + ", ";
                    if (t.fields[i].displayName == "")
                        continue;
                    w += t.name + "." + t.fields[i].name + " = " + "t2." + t.fields[i].name + " AND ";
                }
                s = s.Remove(s.Length - 2, 1);
                w += t.name + ".ID" + " <> " + "t2.ID)";
                s += " FROM " + t.name + " t2 ";
                s += w ;
                SQLiteCommand command = new SQLiteCommand(s, SQLBuilder.Connection);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DBGrid.DataSource = dt;
                for (int i = 0; i < DBGrid.RowCount; i++)
                {
                    DBGrid.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                ChangeDateFormat(DateCols);
                DBGrid.Columns[0].Visible = false;
            }
            
            SQLBuilder.Connection.Close();
        }

        private void HeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RefillRowNumColumn();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataObject dobj = DBGrid.GetClipboardContent();
            if (dobj != null)
                Clipboard.SetDataObject(dobj);
        }

        private void FDG_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            FillDBGrid();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            MessageBox.Show(elapsedMs.ToString());
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            DBGrid.DataSource = null;
            DBGrid.Rows.Clear();
        }
    }
}
