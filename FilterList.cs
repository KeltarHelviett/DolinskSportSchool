using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;

namespace DolinskSportSchool
{
    public enum EditorType
    {
        DropDownCheckList = 0,
        TextBox = 1,
        Date = 2
    }

    struct FilterInfo
    {
        public int tableTag;
        public int fieldNum;
        public EditorType type;

        public static bool operator ==(FilterInfo fi1, FilterInfo fi2)
        {
            if (fi1.type == fi2.type && fi1.fieldNum == fi2.fieldNum
                && fi1.tableTag == fi2.tableTag)
                return true;
            return false;
        }

        public static bool operator !=(FilterInfo fi1, FilterInfo fi2)
        {
            if (fi1.type == fi2.type && fi1.fieldNum == fi2.fieldNum
                && fi1.tableTag == fi2.tableTag)
                return false;
            return true;
        }

        public FilterInfo(int tag, int fnum, EditorType editorType)
        {
            this.tableTag = tag;
            this.fieldNum = fnum;
            this.type = editorType;
        }
    }



    struct FilterCheckBox
    {
        CheckBox box;
        FilterInfo info;

        public FilterCheckBox(string labelText, int tag, int fnum, EditorType editorType, Control parent, int x, int y, EventHandler onCheck)
        {
            this.box = new CheckBox();
            this.box.Parent = parent;
            this.info = new FilterInfo(tag, fnum, editorType);
            this.box.Text = labelText;
            this.box.Left = x;
            this.box.Top = y;
            this.box.RightToLeft = RightToLeft.Yes;
            this.box.CheckedChanged += onCheck;
            this.box.Tag = info;
        }       
    }
    class FilterSelection
    {
        private Control parent;
        private List<FilterCheckBox> filtersCBs;

        // filterInfo [name, tableTag, fieldNum, editorType]
        public FilterSelection(Control parent, List<List<string>> filterInfo, EventHandler onCheck) 
        {
            this.filtersCBs = new List<FilterCheckBox>();
            this.parent = parent;
            int x = 5; int y = 5;
            for (int i = 0; i < filterInfo.Count; i++)
            {
                int tt = Convert.ToInt32(filterInfo[i][1]);
                int fn = Convert.ToInt32(filterInfo[i][2]);
                this.filtersCBs.Add(new FilterCheckBox(filterInfo[i][0], tt, fn, (EditorType)Convert.ToInt32(filterInfo[i][3]), parent, x, y, onCheck));
                x += 0; y += 20;
            }
        }
        
    }


    class DropDownCheckList
    {
        private TextBox summary;
        private Control parent;
        private Panel selectionPanel;
        private Button acceptBtn;
        private List<CheckBox> selections;

        public TextBox Summary
        {
            get { return summary; }
        }
        

        public DropDownCheckList(Control parent, List<string> values, int x, int y)
        {
            this.parent = parent;
            this.selections = new List<CheckBox>();
            this.selectionPanel = new Panel();
            this.selectionPanel.Parent = parent;
            this.summary = new TextBox();
            this.summary.Left = x;
            this.summary.Top = y;
            this.summary.ReadOnly = true;
            this.summary.Parent = parent;
            this.summary.Width = 110;
            this.selectionPanel.Left = this.summary.Left;
            this.selectionPanel.Top = this.summary.Top + 30;
            this.selectionPanel.BorderStyle = BorderStyle.FixedSingle;
            this.acceptBtn = new Button();
            int cbx = 0, cby = 5;
            for (int i = 0; i < values.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Text = values[i];
                cb.RightToLeft = RightToLeft.No;
                cb.Width = 100;
                cb.Parent = this.selectionPanel;
                cb.Left = cbx;
                cb.Top = cby;
                cby += 20;
                this.selections.Add(cb);
            }
            this.acceptBtn.Parent = this.selectionPanel;
            this.acceptBtn.Left = cbx;
            this.acceptBtn.Top = cby;
            this.acceptBtn.Width = 40;
            this.acceptBtn.Height = 20;
            this.acceptBtn.Text = "OK";
            this.acceptBtn.Click += new EventHandler(onAcceptBtnClick);
            this.acceptBtn.Show();
            this.selectionPanel.AutoScroll = true;
            this.selectionPanel.Height = 150;
            this.selectionPanel.Width = this.summary.Width;
            this.selectionPanel.HorizontalScroll.Value = this.selectionPanel.HorizontalScroll.Maximum;
            

            this.summary.Show();
            this.selectionPanel.Show();
        }

        public int destroy()
        {
            int res = this.summary.Left;
            this.parent.Controls.Remove(this.selectionPanel);
            this.parent.Controls.Remove(this.summary);
            return res;
        }

        public void setPosition(int x, int y)
        {
            this.summary.Left = x;
            this.summary.Top = y;
            this.selectionPanel.Left = this.summary.Left;
            this.selectionPanel.Top = this.summary.Top + 30;
        }

        private void onAcceptBtnClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string res = "";
            for (int i = 0; i < this.selections.Count; i++)
            {
                if (selections[i].Checked)
                {
                    res += selections[i].Text + ", ";
                }
            }
            if (res != "")
                this.summary.Text = res.Remove(res.Length - 2, 2);
            this.selectionPanel.Hide();

        }

    }
    
    class Filter
    {
        private EditorType type;
        private TextBox text;
        private DropDownCheckList checkList;
        private FilterInfo info;

        public EditorType Type
        {
            get { return type; }
        }

        public TextBox Text
        {
            get { return text; }
        }

        public DropDownCheckList CheckList
        {
            get { return checkList; }
        }

        public FilterInfo Info
        {
            get { return info; }
        }
        
        public Filter(Control parent, EditorType editorType, List<string> values, int x, int y, FilterInfo fi)
        {
            this.type = editorType;
            this.info = fi;
            switch (this.type)
            {
                case EditorType.DropDownCheckList:
                    checkList = new DropDownCheckList(parent, values, x, y);
                    break;
                case EditorType.TextBox:
                    text = new TextBox();
                    text.Parent = parent;
                    text.Left = x;
                    text.Top = y;
                    text.Width = 110;
                    break;
            }
        }

        public int destroy()
        {
            switch (type)
            {
                case EditorType.DropDownCheckList:
                    return this.checkList.destroy();
                case EditorType.TextBox:
                    int res = this.text.Left;
                    this.text.Parent.Controls.Remove(this.text);
                    return res;
                default:
                    return 0;
            }
        }

        public void setPosition(int x, int y)
        {
            switch (type)
            {
                case EditorType.DropDownCheckList:
                    checkList.setPosition(x, y);
                    break;
                case EditorType.TextBox:
                    text.Left = x;
                    text.Top = y;
                    break;
            }
        }
    }

    class FilterList
    {
        FilterSelection selection;
        List<Filter> filters;
        Control parent;
        int left = 10;
        int top = 10;

        private void onSelectionCheck(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            FilterInfo fi = (FilterInfo)cb.Tag;
            if (cb.Checked)
            {
                List<string> ls = new List<string>();
                SQLiteConnection connection =
                    new SQLiteConnection(string.Format("Data Source={0};", MetaData.DBName));
                connection.Open();
                SQLiteCommand com = new SQLiteCommand();
                com.CommandText = " SELECT " + MetaData.tables[fi.tableTag].name + "."
                    + MetaData.tables[fi.tableTag].fields[fi.fieldNum].name + " FROM " + MetaData.tables[fi.tableTag].name;
                com.Connection = connection;
                SQLiteDataReader reader = com.ExecuteReader();
                foreach (DbDataRecord rec in reader)
                {
                    ls.Add(rec[0].ToString());
                }
                left = (filters.Count) * 120 + 5;
                Filter f = new Filter(this.parent, fi.type, ls, this.left, this.top, fi);
                filters.Add(f);
                connection.Close();
            }
            else
            {
                for (int i = 0; i < filters.Count; i++)
                {
                    if (filters[i] != null && filters[i].Info == fi)
                    {                         
                        left = filters[i].destroy();
                        filters.Remove(filters[i]);
                        for (int j = i; j < filters.Count; j++)
                        {
                            filters[j].setPosition(j * 120 + 5, 10);
                        }
                        break;
                    }
                }
            }
            

        }

        public FilterList(Control parent, Control filterSelectonParent, List<List<string>> filterInfo)
        {
            this.filters = new List<Filter>();
            this.parent = parent;
            this.selection = new FilterSelection(filterSelectonParent, filterInfo, new EventHandler(onSelectionCheck));
        }

        public List<Filter> getFilters()
        {
            return this.filters;
        }

    }

    
    
}
