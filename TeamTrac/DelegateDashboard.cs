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
    public partial class DelegateDashboard : Form
    {
        public DelegateDashboard()
        {
            InitializeComponent();
            label3.Text = Form1.UserName;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            CreateSupportTicket CreateSupportTicket = new CreateSupportTicket();
            CreateSupportTicket.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddShop shop = new AddShop();
            shop.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ProductRequest request = new ProductRequest();
            request.Show();
        }
    }
}
