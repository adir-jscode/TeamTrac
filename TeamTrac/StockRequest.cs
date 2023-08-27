using Guna.UI2.WinForms;
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
    public partial class StockRequest : Form
    {
        public StockRequest()
        {
            InitializeComponent();
            BindGridView();
        }

        void BindGridView()
        {

            DataTable Stock = Global.Get.AllStockRequest();
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string StockrequestID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Global.Get.ApproveStock(StockrequestID);
            BindGridView();
            MessageBox.Show("Stock Request Approved");
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Status = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (Status == "Requested")
            {
                guna2Button1.Enabled = true;
            }
            else
            {
                guna2Button1.Enabled = false;
            }
        }
    }
}
