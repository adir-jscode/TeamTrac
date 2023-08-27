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
    public partial class RegisterCompany : Form
    {
        public RegisterCompany()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string CompanyName = textBox1.Text;
            string Address = textBox2.Text;
            string Bin = textBox3.Text;
            string TradeLicence = textBox9.Text;
            string ContactNo = textBox4.Text;
            string OwnerName = textBox7.Text;
            string CompanyEmail = textBox12.Text;
            string OwnerEmail = textBox11.Text;
            string NID = textBox5.Text;
            string Phone = textBox6.Text;
            string Username = textBox8.Text;
            string Password = textBox10.Text;
            Global.Get.RegisterCompnay(CompanyName, Address, Bin, TradeLicence, ContactNo, OwnerName, CompanyEmail, OwnerEmail, NID, Phone, Username, Password, SavePhoto());
            MessageBox.Show("Welcome to OnBoard " + CompanyName);
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
