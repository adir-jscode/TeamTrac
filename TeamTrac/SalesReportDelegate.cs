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
    public partial class SalesReportDelegate : Form
    {
        public SalesReportDelegate()
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

            DataTable sales = Global.Get.SalesReport();
            guna2DataGridView1.DataSource = sales;

            // Manipulate the "status" column
            foreach (DataRow row in sales.Rows)
            {
                // Access the "status" column by its name
                if (row["status"].ToString() == "1")
                {
                    // You can update the value of the "status" column
                    row["status"] = "Sold";
                }
                else
                {
                    row["status"] = "Done";
                }
            }


        }
        private void SalesReportDelegate_Load(object sender, EventArgs e)
        {

        }
    }
}
