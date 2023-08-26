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

                if (row["status"].ToString() == "1")
                {

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

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string TicketID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            Global.Get.UpdateTicket(TicketID);
            BindGridView();
            MessageBox.Show("Ticket has been marked as done");
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Status = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (Status == "Requested")
            {
                guna2Button2.Enabled = true;
            }
            else
            {
                guna2Button2.Enabled = false;
            }
        }
    }
}
