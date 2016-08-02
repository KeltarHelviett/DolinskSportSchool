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

    
    
    class Filter
    {
        private EditorType type;
        private Label title;
        private TextBox text;
        private DropDownCheckList checkList;
        private IntervalDateEdit date;
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

        public IntervalDateEdit Date
        {
            get { return date; }
        }

        public FilterInfo Info
        {
            get { return info; }
        }
        
        public Filter(Control parent, EditorType editorType, List<string> values, int x, int y, FilterInfo fi)
        {
            this.title = new Label();
            this.title.Text = MetaData.tables[fi.tableTag].fields[fi.fieldNum].displayName;
            this.title.Parent = parent;
            this.title.Left = x;
            this.title.Top = y;
            this.type = editorType;
            this.info = fi;
            switch (this.type)
            {
                case EditorType.DropDownCheckList:
                    checkList = new DropDownCheckList(parent, values, x, y, this.title);
                    break;
                case EditorType.TextBox:
                    text = new TextBox();
                    text.Parent = parent;
                    text.Left = x;
                    text.Top = this.title.Top + this.title.Height + 10;
                    text.Width = 110;
                    break;
                case EditorType.DateInterval:
                    this.date = new IntervalDateEdit(parent, x, y, title);
                    break;
            }
        }

        public int Destroy()
        {
            switch (type)
            {
                case EditorType.DropDownCheckList:
                    return this.checkList.Destroy();
                case EditorType.TextBox:
                    int res = this.text.Left;
                    this.title.Parent.Controls.Remove(this.title);
                    this.text.Parent.Controls.Remove(this.text);
                    return res;
                case EditorType.DateInterval:
                    this.date.Destroy();
                    return 0;
                default:
                    return 0;
            }
        }

        public void SetPosition(int x, int y)
        {
            switch (type)
            {
                case EditorType.DropDownCheckList:
                    this.checkList.SetPosition(x, y);
                    break;
                case EditorType.TextBox:
                    this.title.Left = x;
                    this.title.Top = y;
                    this.text.Left = x;
                    this.text.Top = this.title.Top + this.title.Height + 10;
                    break;
                case EditorType.DateInterval:
                    this.date.SetPosition(x, y);
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
                        left = filters[i].Destroy();
                        filters.Remove(filters[i]);
                        for (int j = i; j < filters.Count; j++)
                        {
                            filters[j].SetPosition(j * 120 + 5, 10);
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

        public List<Filter> GetFilters()
        {
            return this.filters;
        }

    }

    
    
}
