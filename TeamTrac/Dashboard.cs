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
            label3.Text = Form1.UserName;
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            AddShop shop = new AddShop();
            shop.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccessControl access = new AccessControl();
            access.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProduct product = new AddProduct();
            product.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OnBoardDelegate onBoard = new OnBoardDelegate();
            onBoard.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEmployee manageEmployee = new ManageEmployee();
            manageEmployee.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCategory category = new AddCategory();
            category.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupportTickets support = new SupportTickets();
            support.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompanyProfile profile = new CompanyProfile();
            profile.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inventory = new Inventory();
            inventory.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            AssignProduct assign = new AssignProduct();
            assign.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageDelegates manageDelegates = new ManageDelegates();
            manageDelegates.Show();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
