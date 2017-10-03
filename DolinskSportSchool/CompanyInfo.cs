using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolinskSportSchool
{
    public partial class CompanyInfo : Form
    {
        public CompanyInfo()
        {
            InitializeComponent();
        }

        private void ContactsLabel_Click(object sender, EventArgs e)
        {

        }

        private void RB_LinkClick(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
