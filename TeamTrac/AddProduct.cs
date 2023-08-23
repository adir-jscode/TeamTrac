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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void LoadCategory()
        {
            DataTable CategoryTable = Global.Get.ProductCategory();
            comboBox1.DataSource = CategoryTable;
            comboBox1.DisplayMember = CategoryTable.Columns[1].ToString();
            comboBox1.ValueMember = CategoryTable.Columns[0].ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            DataTable CategoryTable = Global.Get.ProductCategory();

            comboBox1.DisplayMember = CategoryTable.Columns[1].ToString();
            comboBox1.ValueMember = CategoryTable.Columns[0].ToString();

            comboBox1.DataSource = CategoryTable;
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            DataTable CategoryTable = Global.Get.ProductCategory();
           
            comboBox1.DisplayMember = CategoryTable.Columns[1].ToString();
            comboBox1.ValueMember = CategoryTable.Columns[0].ToString();

            comboBox1.DataSource = CategoryTable;
        }
    }
}
