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
    public partial class CreateSupportTicket : Form
    {
        public CreateSupportTicket()
        {
            InitializeComponent();
        }

        private void CreateSupportTicket_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelegateDashboard dashboard = new DelegateDashboard();
            dashboard.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string DelegateID = Form1.ID;
            string Description = textBox2.Text;
            Global.Get.CreateSupportTicket(DelegateID, Description);
            MessageBox.Show("Support Ticket Created");
            textBox2.Clear();

        }
    }
}
