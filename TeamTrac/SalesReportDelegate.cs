using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamTrac
{
    public partial class SalesReportDelegate : Form
    {
        public SalesReportDelegate()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelegateDashboard dashboard = new DelegateDashboard();
            dashboard.Show();
        }
    }
}
