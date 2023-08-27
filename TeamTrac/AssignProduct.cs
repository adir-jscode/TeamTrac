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




        }

        void BindGridView()
        {

            DataTable AssignTable = Global.Get.DelegateProductView();
            guna2DataGridView1.DataSource = AssignTable;

            // Manipulate the "status" column
            foreach (DataRow row in AssignTable.Rows)
            {
                // Access the "status" column by its name
                if (row["status"].ToString() == "1")
                {
                    // You can update the value of the "status" column
                    row["status"] = "Assigned";
                }
                else
                {
                    row["status"] = "Delivered";
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
            string ProductID = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string selectedProductName = comboBox1.SelectedItem.ToString();

            int AvailableQuantity = Global.Get.GetProductQuantity(selectedProductName);
            int AssignQuantity = Convert.ToInt32(textBox1.Text);

            if (AssignQuantity > AvailableQuantity)
            {
                MessageBox.Show("Quantity is greater than Available Quantity");
            }
            //update Quantity in Product Table




            else
            {
                int NewQuantity = AvailableQuantity - AssignQuantity;

                Global.Get.UpdateQuantity(ProductID, NewQuantity);


                string selectedDelegateName = comboBox2.SelectedItem.ToString();

                string productID = Global.Get.GetProductID(selectedProductName);
                string delegateID = Global.Get.GetDelegateID(selectedDelegateName);
                Global.Get.AssignProduct(productID, delegateID, AssignQuantity);
                MessageBox.Show("Product Assigned Successfully");
                BindGridView();
            }





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProductName = comboBox1.SelectedItem.ToString();
            int Quantity = Global.Get.GetProductQuantity(selectedProductName);
            //after assign quantity make it visible

            if (Quantity > 0)
            {
                label6.Visible = true;
                label6.Text = Quantity.ToString();
            }
            else
            {
                label6.Visible = false;
            }
        }
    }
}
