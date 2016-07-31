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
        Date = 2
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
            this.from.Width = 110;

            this.tillTitle.Text = "До";
            this.tillTitle.Left = x;
            this.tillTitle.Top = this.from.Top + this.from.Height + 10;

            this.till.Left = x;
            this.till.Top = this.tillTitle.Top + this.tillTitle.Height + 10;
            this.till.Width = 110;
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
            this.title = title;
            this.title.Left = x;
            this.title.Top = y;
            this.parent = parent;
            this.selections = new List<CheckBox>();
            this.selectionPanel = new Panel();
            this.selectionPanel.Parent = parent;
            this.summary = new TextBox();
            this.summary.Left = x;
            this.summary.Top = this.title.Top + this.title.Height + 10;
            this.summary.ReadOnly = true;
            this.summary.Parent = parent;
            this.summary.Width = 110;
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
