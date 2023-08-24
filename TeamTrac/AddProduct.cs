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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void LoadCategory()
        {
            DataTable CategoryTable = Global.Get.ProductCategory();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            DataTable CategoryTable = Global.Get.ProductCategory();

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string ProductName = textBox1.Text;
            string ProductCategory = textBox4.Text;
            int Price = Convert.ToInt32(textBox2.Text);
            int Quantity = Convert.ToInt32(textBox3.Text);
            byte[] imageBytes = SavePhoto();
            Global.Get.AddNewProduct(ProductName, ProductCategory, Price, Quantity, imageBytes);
            MessageBox.Show("Product Added Successfully");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            DataTable CategoryTable = Global.Get.ProductCategory();

           
        }
    }
}
