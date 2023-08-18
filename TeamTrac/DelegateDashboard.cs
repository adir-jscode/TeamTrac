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
            //CreateSupportTicket CreateSupportTicket = new CreateSupportTicket();
            //CreateSupportTicket.Show();
           
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddShop shop = new AddShop();
            shop.Show();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelegateProfile profile = new DelegateProfile();
            profile.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyProducts myProducts = new MyProducts();
            myProducts.Show();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SalesReportDelegate salesReportDelegate = new SalesReportDelegate();
            salesReportDelegate.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductRequest productRequest = new ProductRequest();
            productRequest.Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            AddControlsToPanel(new CreateSupportTicket());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void AddControlsToPanel(Form F)
        {
            panel4.Controls.Clear();
            F.TopLevel = false;
            F.Dock = DockStyle.Fill;
            panel4.Controls.Add(F);
            F.Show();

        }
    }
}
