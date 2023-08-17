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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            label2.Text = Form1.UserName;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            AddCategory category = new AddCategory();
            category.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            OnBoardDelegate onBoard = new OnBoardDelegate();
            onBoard.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ManageEmployee employee = new ManageEmployee();
            employee.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            AddProduct product = new AddProduct();
            product.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            AddShop shop = new AddShop();
            shop.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            ProductRequest request = new ProductRequest();
            request.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SupportTickets tickets = new SupportTickets();
            tickets.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
