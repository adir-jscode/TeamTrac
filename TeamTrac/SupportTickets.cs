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
    public partial class SupportTickets : Form
    {
        public SupportTickets()
        {
            InitializeComponent();
            BindGridView();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }


        void BindGridView()
        {

            DataTable SupportTickets = Global.Get.SupportTickets();
            guna2DataGridView1.DataSource = SupportTickets;

            // Manipulate the "status" column
            foreach (DataRow row in SupportTickets.Rows)
            {
                // Access the "status" column by its name
                if (row["status"].ToString() == "1")
                {
                    // You can update the value of the "status" column
                    row["status"] = "Requested";
                }
                else
                {
                    row["status"] = "Done";
                }
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
