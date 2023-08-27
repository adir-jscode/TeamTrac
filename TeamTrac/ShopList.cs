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
    public partial class ShopList : Form
    {
        public ShopList()
        {
            InitializeComponent();
            BindGridView();
        }


        void BindGridView()
        {

            DataTable shop = Global.Get.AllShops();
            guna2DataGridView1.DataSource = shop;

            // Manipulate the "status" column
            //foreach (DataRow row in shop.Rows)
            //{
            //    // Access the "status" column by its name
            //    if (row["status"].ToString() == "1")
            //    {
            //        // You can update the value of the "status" column
            //        row["status"] = "Active";
            //    }
            //    else
            //    {
            //        row["status"] = "Inactive";
            //    }
            //}

        }

        private void ShopList_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string ShopID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Global.Get.DeleteShop(ShopID);
            MessageBox.Show("Shop Deleted");
            BindGridView();
        }
    }
}
