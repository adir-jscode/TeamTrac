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
    public partial class AssignProduct : Form
    {
        public AssignProduct()
        {
            InitializeComponent();
            BindGridView();

            DataTable ProductTable = Global.Get.ProductDetails();
            //for loop to get product name in combobox
            foreach (DataRow row in ProductTable.Rows)
            {
                comboBox1.Items.Add(row["ProductName"].ToString());
            }

            //get delegate name in combobox from delegate table
            DataTable DelegateTable = Global.Get.DelegateDetails();
            foreach (DataRow row in DelegateTable.Rows)
            {
                comboBox2.Items.Add(row["DelegateName"].ToString());
            }

            //if (comboBox1.SelectedIndex != -1)
            //{
            //    string selectedProductName = comboBox1.SelectedItem.ToString();
            //    int productQuantity = Global.Get.GetProductQuantity(selectedProductName);
            //    textBox1.Text = productQuantity.ToString();
            //    // Now you can use the productQuantity as needed
            //    MessageBox.Show($"Quantity of {selectedProductName}: {productQuantity}");
            //}
            //else
            //{
            //    MessageBox.Show("Please select a product from the list.");
            //}
        }

        void BindGridView()
        {

            DataTable AssignTable = Global.Get.DelegateProductView();
            guna2DataGridView1.DataSource = AssignTable;

            //DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            //dgv = (DataGridViewImageColumn)guna2DataGridView1.Columns[7];
            //dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //guna2DataGridView1.RowTemplate.Height = 80;

            // Manipulate the "status" column
            foreach (DataRow row in AssignTable.Rows)
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //after click assign button
            //get product name and delegate name from combobox
            string selectedProductName = comboBox1.SelectedItem.ToString();
            string selectedDelegateName = comboBox2.SelectedItem.ToString();
            //get product id and delegate id from database
            string productID = Global.Get.GetProductID(selectedProductName);
            string delegateID = Global.Get.GetDelegateID(selectedDelegateName);
            Global.Get.AssignProduct(productID, delegateID);
            MessageBox.Show("Product Assigned Successfully");
            BindGridView();

        }
    }
}
