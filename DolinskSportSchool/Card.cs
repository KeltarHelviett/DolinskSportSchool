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

        public int CardId
        {
            get { return cardId; }
        }

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
            CreateCard();
            switch (id)
            {
                case -1:
                    break;
                default:
                    FillCard();
                    break;
            }
            if (Notifier.CheckCardExistence(this.cardId, (int)this.Tag))
                this.Close();
            Notifier.LookAfterCard(this);
            SaveBtn.Left = this.Width / 2 - SaveBtn.Width - 50;
            CanceleBtn.Left = this.Width / 2 + CanceleBtn.Width + 50;
            this.Show();
        }

        private void FillComboBox(ComboBox cb, int ttag, int ftag)
        {
            SQLBuilder.Connection.Open();
            SQLiteCommand command = new SQLiteCommand(
                string.Format("SELECT id, {0} FROM {1}", MetaData.tables[ttag].fields[ftag].name, MetaData.tables[ttag].name));
            command.Connection = SQLBuilder.Connection;
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                cb.Items.Add(new ComboBoxItem(Convert.ToInt32(record[0]), record[1].ToString()));
            }
            SQLBuilder.Connection.Close();
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
            ctrl.Font = new System.Drawing.Font("Times New Roman", 10);
            ctrl.Left = x;
            ctrl.Top = y;
            ctrl.Width = 110;
            parent.Controls.Add(ctrl);
            e.c = ctrl;
            return e;
        }

        private void FillCard()
        {
            SQLBuilder.Connection.Open();
            SQLiteCommand command = new SQLiteCommand(
                SQLBuilder.BuildSelectPart((int)Tag) + " WHERE " + MetaData.tables[(int)Tag].name + ".ID = " + cardId.ToString(), SQLBuilder.Connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i < editors.Count; i++)
            {
                switch (editors[i].et)
                {
                    case EditorType.TextBox:
                        (editors[i].c as TextBox).Text = reader.GetString(i);
                        break;
                    case EditorType.Date:
                        (editors[i].c as DateTimePicker).Value = reader.GetDateTime(i);
                        break;
                    case EditorType.ComboBox:
                        ComboBox cb = editors[i].c as ComboBox;
                        string s = reader.GetString(i);
                        for (int j = 0; j < cb.Items.Count; j++)
                        {
                            ComboBoxItem cbi = cb.Items[j] as ComboBoxItem;
                            if (cbi.Value == s)
                            {
                                cb.SelectedIndex = j;
                                break;
                            }
                        }
                        break;
                }
            }
            SQLBuilder.Connection.Close();
        }

        private void CreateCard()
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
                    l.Font = new System.Drawing.Font("Times New Roman", 10);
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
                        l.Font = new System.Drawing.Font("Times New Roman", 10);
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
            string attribs = "(ID, ";
            string res = string.Format("INSERT INTO {0}~ VALUES(NULL, ", MetaData.tables[(int)Tag].name);
            Table t = MetaData.tables[(int)Tag];
            int count = 0;
            prms = new List<string>();
            for (int i = 0; i < MetaData.tables[(int)Tag].fields.Count; i++)
            {
                if (t.fields[i].displayName == "")//@[TableName][FieldName][randomint]
                    continue;
                attribs += t.fields[i].name + ", ";
                prms.Add("@" + t.name + t.fields[i].name + (count++).ToString());
                res += prms[prms.Count - 1] + ", ";
            }
            attribs = attribs.Remove(attribs.Length - 2, 2);
            res = res.Remove(res.Length - 2, 2);
            res = res.Replace("~", attribs + ")");
            res += ");";
            return res;
        }

        private void AddNewRecord()
        {
            SQLBuilder.Connection.Open();
            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = SQLBuilder.Connection;
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
            }
            SQLBuilder.Connection.Close();
            SQLBuilder.Connection.Open();
            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = SQLBuilder.Connection;
                command.CommandText = string.Format("SELECT ID FROM {0} ORDER BY ID DESC LIMIT 1", MetaData.tables[(int)Tag].name);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                try
                {
                    this.cardId = Convert.ToInt32(dt.Rows[0][0]);
                }
                catch (Exception ex)
                {

                }
            }
            SQLBuilder.Connection.Close();
            this.Close();
        }

        private string CreateUpdateString(out List<string>prms)
        {
            string res = string.Format("UPDATE {0} SET ", MetaData.tables[(int)Tag].name);
            Table t = MetaData.tables[(int)Tag];
            int count = 0;
            prms = new List<string>();
            for (int i = 0; i < t.fields.Count; i++)
            {
                if (t.fields[i].displayName == "")
                    continue;
                prms.Add("@" + t.name + t.fields[i].name + (count++).ToString());
                res += t.fields[i].name + " = " + prms[prms.Count - 1] + ", ";
            }
            res = res.Remove(res.Length - 2, 2);
            res += " WHERE ID = " + this.cardId.ToString() ;
            return res;
        }

        private void EditRecord()
        {
            SQLBuilder.Connection.Open();
            SQLiteCommand command = new SQLiteCommand();
            List<string> prms;
            command.Connection = SQLBuilder.Connection;
            command.CommandText = CreateUpdateString(out prms);
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
            SQLBuilder.Connection.Close();
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cardId == -1)
                    AddNewRecord();
                else
                    EditRecord();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка ввода!");
                SQLBuilder.Connection.Close();
                return;
            }
            
            Notifier.UpdateTables(cardId);
            
        }

        private void CanceleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseCard(object sender, FormClosingEventArgs e)
        {
            Notifier.DropCard(this);
        }

        private void BResize(object sender, EventArgs e)
        {
            
        }

        private void EResize(object sender, EventArgs e)
        {
           
        }
    }
}
