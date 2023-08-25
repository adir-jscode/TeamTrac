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

            DataTable employeeTable = Global.Get.EmployeeDetails();
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
                else
                {
                    row["status"] = "Inactive";
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILE (*.PNG) | *.PNG";
            ofd.Filter = "ALL IMAGE FILE (*.*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string EmployeeName = textBox1.Text;
            string EmployeePhone = textBox2.Text;
            string Address = textBox3.Text;
            string Position = textBox4.Text;
            DateTime JoinDate = dateTimePicker2.Value;
        }
    }
}
