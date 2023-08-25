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
    public partial class AddShop : Form
    {
        public AddShop()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelegateDashboard dashboard = new DelegateDashboard();
            dashboard.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //string shopName, string address, string area, string zipCode, string ownerName, string nid, byte[] image, string tradeLicense
            string ShopName = textBox1.Text;
            string Address = textBox2.Text;
            string OwnerName = textBox3.Text;


        }
    }
}
