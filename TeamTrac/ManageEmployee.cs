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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TeamTrac.Model;

namespace TeamTrac
{
    public partial class ManageEmployee : Form
    {

        public ManageEmployee()
        {
            InitializeComponent();
            BindGridView();
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
            string EID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            string EmployeeName = textBox1.Text;
            string Email = textBox7.Text;
            string Phone = textBox2.Text;
            string Address = textBox3.Text;
            string Position = textBox4.Text;




            byte[] img = SavePhoto();
            Global.Get.UpdateEmployeeDetails(EID, EmployeeName, Email, Phone, Address, Position, img);
            BindGridView();
            MessageBox.Show("Employee Updated");

        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string EID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            string EmployeeName = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = EmployeeName;
            string Email = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox7.Text = Email;
            string Phone = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox2.Text = Phone;
            string Address = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = Address;
            string Position = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox4.Text = Position;


            guna2CirclePictureBox1.Image = GetPhoto((byte[])guna2DataGridView1.CurrentRow.Cells[7].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string EID = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            Global.Get.DeleteEmployee(EID);
            BindGridView();
            MessageBox.Show("Employee Removed");
        }
    }
}
