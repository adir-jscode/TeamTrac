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
    public partial class SellProduct : Form
    {
        public SellProduct()
        {
            InitializeComponent();

            string DelegateID = Form1.ID;
            DataTable ProductTable = Global.Get.AssignedProductDelegate(DelegateID);
            //for loop to get product name in combobox
            foreach (DataRow row in ProductTable.Rows)
            {
                comboBox1.Items.Add(row["ProductName"].ToString());
            }

            DataTable DelegateTable = Global.Get.ShopDetails();
            foreach (DataRow row in DelegateTable.Rows)
            {
                comboBox2.Items.Add(row["ShopName"].ToString());
            }

            BindGridView();
        }


        void BindGridView()
        {

            DataTable AssignTable = Global.Get.Sales();
            guna2DataGridView1.DataSource = AssignTable;

            // Manipulate the "status" column
            foreach (DataRow row in AssignTable.Rows)
            {
                // Access the "status" column by its name
                if (row["status"].ToString() == "1")
                {
                    // You can update the value of the "status" column
                    row["status"] = "Sold";
                }
                else
                {
                    row["status"] = "Pending";
                }
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string selectedProductName = comboBox1.SelectedItem.ToString();
            string ProductID = Global.Get.GetProductID(selectedProductName);
            string DelegateID = Form1.ID;

            string ShopName = comboBox2.SelectedItem.ToString();
            string ShopID = Global.Get.GetShopID(ShopName);

            //is sold or not
            bool IsSold = Global.Get.IsSold(ProductID, ShopID);
            if (IsSold)
            {
                MessageBox.Show("Product is already sold");
                return;
            }

            int AvailableQuantity = Global.Get.GetAssignedQuantity(ProductID);
            int AssignQuantity = Convert.ToInt32(textBox1.Text);

            if (AssignQuantity > AvailableQuantity)
            {
                MessageBox.Show("Quantity is greater than Available Quantity");
            }

            else
            {
                int NewQuantity = AvailableQuantity - AssignQuantity;

                Global.Get.UpdateAssignedQuantity(ProductID, NewQuantity);

                Global.Get.NewSell(ProductID, DelegateID, ShopID, AssignQuantity);
                MessageBox.Show("Product Sold Successfully");
                BindGridView();
            }
        }

        private void SellProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
