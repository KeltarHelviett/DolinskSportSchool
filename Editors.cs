using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolinskSportSchool
{
    public enum EditorType
    {
        DropDownCheckList = 0,
        TextBox = 1,
        DateInterval = 2,
        Date = 3,
        ComboBox = 4,
        ColumnEdit = 5
    }

    class ColumnEditor
    {
        private Control parent;
        private TableEdit td;
        private CheckBox showColumnBox;
        private NumericUpDown diplayIndex;
        private int colIndex;

        public int ColIndex
        {
            get { return colIndex; }
            set { colIndex = value; }
        }

        public CheckBox ShowColumnBox
        {
            get { return showColumnBox; }
        }

        public NumericUpDown DisplayIndex
        {
            get { return diplayIndex; }
        }

        public ColumnEditor(Control parent, int max, string colName, int colIndex, int displayIndex, int x, int y, TableEdit td)
        {
            this.td = td;
            this.parent = parent;
            this.showColumnBox = new CheckBox();
            this.showColumnBox.Parent = parent;
            this.showColumnBox.Left = x;
            this.showColumnBox.Top = y;
            this.showColumnBox.Text = colName;
            this.showColumnBox.Checked = true;
            this.showColumnBox.Show();

            this.diplayIndex = new NumericUpDown();
            this.diplayIndex.Parent = this.parent;
            this.diplayIndex.Minimum = 1;
            this.diplayIndex.Maximum = max;
            this.diplayIndex.Left = x;
            this.diplayIndex.Top = this.showColumnBox.Bottom + 5;
            this.diplayIndex.Width = 50;
            this.diplayIndex.Show();

            this.colIndex = colIndex;
            this.diplayIndex.Value = displayIndex;

            this.diplayIndex.ValueChanged += new EventHandler((sender, e) => 
            {
                
                this.td.Update(this);
            });

            this.showColumnBox.CheckStateChanged += new EventHandler((sender, e) => 
            {   if (!this.showColumnBox.Checked)
                {
                    this.diplayIndex.Hide();
                    this.td.ChangeMax(-1);
                }
                else
                {
                    this.td.ChangeMax(1);
                    this.diplayIndex.Show();
                }
                this.td.Update();
            });

        }
    }

    class TableEdit
    {
        private Control parent;
        private DataGridView DBGrid;
        private List<ColumnEditor> columnEditors;
        private int max;

        public TableEdit(Control parent, List<List<string>> values, int max, DataGridView dgv) // values = {ColName, ColIndex, DisplayIndex}
        {
            this.DBGrid = dgv;
            this.columnEditors = new List<ColumnEditor>();
            int x = 2, y = 5;
            this.parent = parent;
            this.max = max;
            for (int i = 0; i < values.Count; i++)
            {
                ColumnEditor ce = new ColumnEditor
                    (this.parent, max, values[i][0], Convert.ToInt32(values[i][1]), Convert.ToInt32(values[i][2]), x, y, this);
                this.columnEditors.Add(ce);
                x += 110;
                if ((i + 1) % 2 == 0)
                {
                    y += 55;
                    x = 2;
                }
            }
        }

        public void Update(ColumnEditor self = null)
        {
            if (self != null)
            {
                swapValues(self);
            }
            for (int i = 0; i < columnEditors.Count; i++)
            {
                int ci = columnEditors[i].ColIndex;
                int di = (int)columnEditors[i].DisplayIndex.Value;
                if (columnEditors[i].ShowColumnBox.Checked)
                {     
                    DBGrid.Columns[ci].Visible = true;
                    DBGrid.Columns[ci].DisplayIndex = di;
                }
                else
                {
                    DBGrid.Columns[ci].Visible = false;
                }
            }
        }

        public void swapValues(ColumnEditor self)
        {
            foreach (ColumnEditor ce in this.columnEditors)
            {
                try
                {
                    if (ce != self && ce.DisplayIndex.Value == self.DisplayIndex.Value)
                    {
                        ce.DisplayIndex.Value = DBGrid.Columns[self.ColIndex].DisplayIndex;
                        break;
                    }
                }
                catch(Exception ex)
                {

                }
                
            }
        }
        public void ChangeMax(int delta)
        {
            this.max += delta;
            for (int i = 0; i < this.columnEditors.Count; i++)
            {
                //if (this.columnEditors[i].DisplayIndex.Value >= this.max)
                //{
                //    this.columnEditors[i].DisplayIndex.Value--;
                //}
                columnEditors[i].DisplayIndex.Maximum = this.max;
            }
        }
    }

    class IntervalDateEdit
    {
        private Control parent;
        private Label title;
        private Label fromTitle;
        private Label tillTitle;
        private DateTimePicker from;
        private DateTimePicker till;

        public DateTimePicker From
        {
            get { return from; }
        }

        public DateTimePicker Till
        {
            get { return till; }
        }

        public IntervalDateEdit(Control parent, int x, int y, Label title)
        {
            this.parent = parent;
            this.title = title;
            this.from = new DateTimePicker();
            this.till = new DateTimePicker();
            this.fromTitle = new Label();
            this.tillTitle = new Label();
            this.till.Font = new System.Drawing.Font("Times New Roman", 10);
            this.from.Font = new System.Drawing.Font("Times New Roman", 10);
            this.title.Left = x;
            this.title.Top = y;
            this.title.Parent = parent;
            this.from.Parent = parent;
            this.till.Parent = parent;
            this.fromTitle.Parent = parent;
            this.tillTitle.Parent = parent;
            this.fromTitle.Text = "От";
            this.fromTitle.Left = x;
            this.fromTitle.Top = this.title.Top + this.title.Height + 10;

            this.from.Left = x;
            this.from.Top = this.fromTitle.Top + this.fromTitle.Height + 10;
            this.from.Width = 115;

            this.tillTitle.Text = "До";
            this.tillTitle.Left = x;
            this.tillTitle.Top = this.from.Top + this.from.Height + 10;

            this.till.Left = x;
            this.till.Top = this.tillTitle.Top + this.tillTitle.Height + 10;
            this.till.Width = 115;
        }

        public void Destroy()
        {
            this.parent.Controls.Remove(this.title);
            this.parent.Controls.Remove(this.from);
            this.parent.Controls.Remove(this.till);
            this.parent.Controls.Remove(this.fromTitle);
            this.parent.Controls.Remove(this.tillTitle);
        }

        public void SetPosition(int x, int y)
        {
            this.title.Left = x;
            this.title.Top = y;
            this.title.Parent = parent;

            this.fromTitle.Left = x;
            this.fromTitle.Top = this.title.Top + this.title.Height + 10;

            this.from.Left = x;
            this.from.Top = this.fromTitle.Top + this.fromTitle.Height + 10;

            this.tillTitle.Left = x;
            this.tillTitle.Top = this.from.Top + this.from.Height + 10;

            this.till.Left = x;
            this.till.Top = this.tillTitle.Top + this.tillTitle.Height + 10;
        }

    }

    class DropDownCheckList
    {
        private TextBox summary;
        private Label title;
        private Control parent;
        private Panel selectionPanel;
        private Button acceptBtn;
        private List<CheckBox> selections;

        public TextBox Summary
        {
            get { return summary; }
        }


        public DropDownCheckList(Control parent, List<string> values, int x, int y, Label title)
        {
            System.Drawing.Font f = new System.Drawing.Font("Times New Roman", 10);
            this.title = title;
            this.title.Left = x;
            this.title.Top = y;
            this.title.Font = f;
            this.parent = parent;
            this.selections = new List<CheckBox>();
            this.selectionPanel = new Panel();
            this.selectionPanel.Parent = parent;
            this.summary = new TextBox();
            this.summary.Left = x;
            this.summary.Top = this.title.Top + this.title.Height + 10;
            this.summary.ReadOnly = true;
            this.summary.Parent = parent;
            this.summary.Width = 115;
            this.summary.Font = f;
            this.summary.Click += new EventHandler((sender, e) => { this.selectionPanel.Show(); });
            this.selectionPanel.Left = this.summary.Left;
            this.selectionPanel.Top = this.summary.Top + this.summary.Height + 10;
            this.selectionPanel.BorderStyle = BorderStyle.FixedSingle;
            this.acceptBtn = new Button();
            int cbx = 2, cby = 5;
            for (int i = 0; i < values.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Text = values[i];
                cb.RightToLeft = RightToLeft.No;
                //cb.Width = 100;
                cb.Parent = this.selectionPanel;
                cb.Left = cbx;
                cb.Top = cby;
                cb.Font = f;
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
            this.acceptBtn.Font = f;
            this.acceptBtn.Show();
            this.selectionPanel.AutoScroll = true;
            this.selectionPanel.Height = 150;
            this.selectionPanel.Width = this.summary.Width;
            this.selectionPanel.HorizontalScroll.Value = this.selectionPanel.HorizontalScroll.Maximum;


            this.summary.Show();
            this.selectionPanel.Show();
        }

        public int Destroy()
        {
            int res = this.summary.Left;
            this.parent.Controls.Remove(this.selectionPanel);
            this.parent.Controls.Remove(this.summary);
            this.parent.Controls.Remove(this.title);
            return res;
        }

        public void SetPosition(int x, int y)
        {
            this.title.Left = x;
            this.title.Top = y;
            this.summary.Left = x;
            this.summary.Top = this.title.Top + this.title.Height + 10;
            this.selectionPanel.Left = this.summary.Left;
            this.selectionPanel.Top = this.summary.Top + this.summary.Height + 10;
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
}
