using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamTrac
{
    public partial class MyProducts : Form
    {
        public MyProducts()
        {
            InitializeComponent();
            BindGridView();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelegateDashboard dashboard = new DelegateDashboard();
            dashboard.Show();
        }

        void BindGridView()
        {
            string ID = Form1.ID;
            DataTable AssignTable = Global.Get.AssignedProductDel(ID);
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
                    row["status"] = "Pending";
                }
                else
                {
                    row["status"] = "Completed";
                }
            }


        }
        //void BindGridView()
        // {

        //    DataTable AssingedProduct = Global.Get.AssignedProductDelegate();
        //    guna2DataGridView1.DataSource = AssingedProduct;



        //    // Manipulate the "status" column
        //    foreach (DataRow row in AssingedProduct.Rows)
        //    {
        //        // Access the "status" column by its name
        //        if (row["status"].ToString() == "1")
        //        {
        //            // You can update the value of the "status" column
        //            row["status"] = "Active";
        //        }
        //        else
        //        {
        //            row["status"] = "Inactive";
        //        }
        //    }
        //}

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //status update
            string ProductID = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();


            Global.Get.UpdateTask(ProductID);
            BindGridView();
            MessageBox.Show("Marked as Completed");

        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Status = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (Status == "Pending")
            {
                guna2Button1.Enabled = true;
            }
            else
            {
                guna2Button1.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
