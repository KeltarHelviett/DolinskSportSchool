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
    public partial class Card : Form
    {
        
        struct Editor
        {
            public Control c;
            public EditorType et;

        }

        private int cardId;

        class ComboBoxItem
        {
            private int id;

            public int ID
            {
                get { return id; }
            }

            private string value;

            public string Value
            {
                get { return value; }
            }

            public ComboBoxItem(int id, string value)
            {
                this.id = id;
                this.value = value;
            }

            public override string ToString()
            {
                return value;
            }
        }

        private List<Editor> editors;

        
        
        public Card(int id, int tableTag)
        {
            editors = new List<Editor>();
            this.Tag = tableTag;
            InitializeComponent();
            this.cardId = id;
            switch (id)
            {
                case -1:
                    CreateAddCard();
                    break;
                default:
                    break;
            }
        }

        private void FillComboBox(ComboBox cb, int ttag, int ftag)
        {
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data source = {0}", MetaData.DBName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(
                string.Format("SELECT id, {0} FROM {1}", MetaData.tables[ttag].fields[ftag].name, MetaData.tables[ttag].name));
            command.Connection = connection;
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                cb.Items.Add(new ComboBoxItem(Convert.ToInt32(record[0]), record[1].ToString()));
            }
            connection.Close();
        }

        private Editor CreateEditor(int x, int y, EditorType et, Control parent, int ttag, int ftag)
        {
            Editor e = new Editor();
            e.et = et;
            Control ctrl;
            switch (et)
            {
                case EditorType.TextBox:
                    ctrl = new TextBox();
                    break;
                case EditorType.Date:
                    ctrl = new DateTimePicker();
                    break;
                case EditorType.ComboBox:
                    ctrl = new ComboBox();
                    (ctrl as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;
                    FillComboBox((ComboBox)ctrl, ttag, ftag);
                    break;
                default:
                    ctrl = new TextBox();
                    break;
            }
            ctrl.Left = x;
            ctrl.Top = y;
            ctrl.Width = 110;
            parent.Controls.Add(ctrl);
            e.c = ctrl;
            return e;
        }

        public void CreateAddCard()
        {
            int tg = (int)this.Tag;
            int x = 10, y = 20;
            for (int i = 0; i < MetaData.tables[tg].fields.Count; i++)
            {
                Field f = MetaData.tables[tg].fields[i];
                if (f.displayName == "")
                    continue;
                if (f.referenceTable == -1)
                {
                    Label l = new Label();
                    l.Left = x;
                    l.Top = y;
                    l.Text = f.displayName;
                    EditorPanel.Controls.Add(l);
                    switch (f.type)
                    {
                        case DataType.String:
                            editors.Add(CreateEditor(x, y + l.Height + 10, EditorType.TextBox, EditorPanel, tg, i));
                            break;
                        case DataType.Date:
                            editors.Add(CreateEditor(x, y + l.Height + 10, EditorType.Date, EditorPanel, tg, i));
                            break;

                    }
                    x += 120;
                }
                else
                {
                    for (int j = 0; j < MetaData.tables[f.referenceTable].fields.Count; j++)
                    {
                        Field rf = MetaData.tables[f.referenceTable].fields[j];
                        if (rf.displayName == "")
                            continue;
                        Label l = new Label();
                        l.Left = x;
                        l.Top = y;
                        l.Text = rf.displayName;
                        EditorPanel.Controls.Add(l);
                        editors.Add(CreateEditor(x, y + l.Height + 10, EditorType.ComboBox, EditorPanel, f.referenceTable, j));
                        x += 120;
                    }
                }

            }

        }

        private string CreateInsertString(out List<string> prms)
        {
            string res = string.Format("INSERT INTO {0} VALUES(NULL, ", MetaData.tables[(int)Tag].name);
            Table t = MetaData.tables[(int)Tag];
            int count = 0;
            prms = new List<string>();
            for (int i = 0; i < MetaData.tables[(int)Tag].fields.Count; i++)
            {
                if (t.fields[i].referenceTable == -1)
                {
                    if (t.fields[i].displayName == "")//@[TableName][FieldName][randomint]
                        continue;
                    prms.Add("@" + t.name + t.fields[i].name + (count++).ToString());
                    res += prms[prms.Count - 1] + ", ";
                }
                else
                {
                    Table rt = MetaData.tables[t.fields[i].referenceTable];
                    for (int j = 0; j < rt.fields.Count; j++)
                    {
                        if (rt.fields[j].displayName == "")
                            continue;
                        prms.Add("@" + rt.name + rt.fields[j].name + (count++).ToString());
                        res += prms[prms.Count - 1] + ", ";
                    }
                }
            }
            res = res.Remove(res.Length - 2, 2);
            res += ");";
            return res;
        }

        private void AddNewRecord()
        {
            SQLiteCommand command = new SQLiteCommand();
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data source = {0}", MetaData.DBName));
            connection.Open();
            command.Connection = connection;
            List<string> prms;
            command.CommandText = CreateInsertString(out prms);
            command.Prepare();

            for (int i = 0; i < editors.Count; i++)
            {
                switch (editors[i].et)
                {
                    case EditorType.TextBox:
                        command.Parameters.AddWithValue(prms[i], (editors[i].c as TextBox).Text);
                        break;
                    case EditorType.Date:
                        command.Parameters.AddWithValue(prms[i], (editors[i].c as DateTimePicker).Value.ToString("yyyy-MM-dd"));
                        break;
                    case EditorType.ComboBox:
                        command.Parameters.AddWithValue(prms[i], Convert.ToString(((editors[i].c as ComboBox).SelectedItem as ComboBoxItem).ID));
                        break;
                }
            }
            command.ExecuteNonQuery();
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (cardId == -1)
                AddNewRecord();
            else
                return;
            
        }

        private void CanceleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
