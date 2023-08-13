using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TeamTrac.Model;

namespace TeamTrac
{
    public partial class ManageEmployee : Form
    {
        
        public ManageEmployee()
        {
            InitializeComponent();
        }

        void BindGridView()
        {

            DataTable employeeTable = Global.EmployeeDetails();
            guna2DataGridView1.DataSource = employeeTable;

            // Manipulate the "status" column
            foreach (DataRow row in employeeTable.Rows)
            {
                // Access the "status" column by its name
                if (row["status"].ToString() == "1")
                {
                    // You can update the value of the "status" column
                    row["status"] = "Active";
                }
            }

           // After manipulation, update the DataGridView
           //((BindingSource) guna2DataGridView1.DataSource).ResetBindings(false);



            //DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            //dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            //dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dataGridView1.RowTemplate.Height = 80;
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            BindGridView();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}
