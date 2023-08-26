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
    public partial class OnBoardEmployee : Form
    {
        public OnBoardEmployee()
        {
            InitializeComponent();
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EmployeeName = textBox1.Text;
            string EmployeePhone = textBox2.Text;
            string Address = textBox3.Text;
            string Position = textBox4.Text;
            DateTime JoinDate = dateTimePicker2.Value;
            string Username = textBox5.Text;
            string Password = textBox6.Text;
            string Email = textBox7.Text;
            byte[] imageBytes = SavePhoto();
            Global.Get.AddNewEmployee(EmployeeName, EmployeePhone, Address, Position, JoinDate, Username, Password, Email, imageBytes);
            MessageBox.Show("Employee Added Successfully");

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
    }
}
