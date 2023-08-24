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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        void BindGridView()
        {

            DataTable ProductTable = Global.Get.ProductDetails();
            guna2DataGridView1.DataSource = ProductTable;

            // Manipulate the "status" column
            foreach (DataRow row in ProductTable.Rows)
            {
                // Access the "status" column by its name
                if (row["status"].ToString() == "1")
                {
                    // You can update the value of the "status" column
                    row["status"] = "Active";
                }
                else
                {
                    row["status"] = "Inactive";
                }
            }
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string ProductID = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            Global.Get.DeleteProduct(ProductID);
            BindGridView();
            MessageBox.Show("Product Deleted");
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string ProductName = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = ProductName;
            string ProductCategory = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = ProductCategory;
            string ProductPrice = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = ProductPrice;
            string ProductQuantity = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = ProductQuantity;
            string Status = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (Status == "1")
            {
                comboBox1.Items.Add(guna2DataGridView1.CurrentRow.Cells[5].Value.ToString());
            }
            else
            {
               comboBox1.Items.Add("Inactive");
            }
            
        }
    }
}
