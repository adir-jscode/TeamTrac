using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeamTrac
{
    public partial class ProductRequest : Form
    {
        public ProductRequest()
        {
            InitializeComponent();

            DataTable ProductTable = Global.Get.ProductDetails();
            //for loop to get product name in combobox
            foreach (DataRow row in ProductTable.Rows)
            {
                comboBox1.Items.Add(row["ProductName"].ToString());
            }

            BindGridView();

        }



        void BindGridView()
        {
            string ID = Form1.ID;
            DataTable Stock = Global.Get.StockRequest(ID);
            guna2DataGridView1.DataSource = Stock;

            // Manipulate the "status" column
            foreach (DataRow row in Stock.Rows)
            {
                // Access the "status" column by its name
                if (row["status"].ToString() == "1")
                {
                    // You can update the value of the "status" column
                    row["status"] = "Requested";
                }
                else
                {
                    row["status"] = "Approved";
                }
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelegateDashboard dashboard = new DelegateDashboard();
            dashboard.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string selectedProductName = comboBox1.SelectedItem.ToString();

            //get product id and delegate id from database
            string productID = Global.Get.GetProductID(selectedProductName);
            int Quantity = Convert.ToInt32(textBox1.Text);
            string DelegateID = Form1.ID;
            Global.Get.CreateStockRequest(productID, DelegateID, Quantity);
            MessageBox.Show("Stock Request Created");
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            BindGridView();
        }
    }
}
