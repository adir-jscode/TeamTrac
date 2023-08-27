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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
            BindGridView();


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        void BindGridView()
        {

            DataTable ProductTable = Global.Get.ProductDetails();
            guna2DataGridView1.DataSource = ProductTable;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)guna2DataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            guna2DataGridView1.RowTemplate.Height = 80;

            // Manipulate the "status" column
            foreach (DataRow row in ProductTable.Rows)
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
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string ProductID = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            Global.Get.DeleteProduct(ProductID);
            BindGridView();
            MessageBox.Show("Product Deleted");
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string ProductName = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = ProductName;
            string ProductCategory = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = ProductCategory;
            string ProductPrice = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = ProductPrice;
            string ProductQuantity = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = ProductQuantity;
            string Status = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Items.Clear(); // Clear existing items before adding new ones

            if (Status == "1")
            {
                comboBox1.Items.Add("Active");
                comboBox1.Items.Add("Inactive");
            }
            else
            {
                comboBox1.Items.Add("Inactive");
                comboBox1.Items.Add("Active");
            }

            comboBox1.SelectedIndex = 0; // Set the default selection
            guna2CirclePictureBox1.Image = GetPhoto((byte[])guna2DataGridView1.CurrentRow.Cells[7].Value);

        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string ProductID = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            string ProductName = textBox4.Text;
            string ProductCategory = textBox5.Text;
            //convert product price to int
            int ProductPrice = Convert.ToInt32(textBox2.Text);
            //convert product quantity to int
            int ProductQuantity = Convert.ToInt32(textBox3.Text);
            string Status = comboBox1.SelectedIndex.ToString();
            if (comboBox1.SelectedIndex == 0)
            {
                Status = "1";
            }
            else
            {
                Status = "0";
            }
            //get image
            byte[] img = SavePhoto();
            guna2CirclePictureBox1.Image = GetPhoto((byte[])guna2DataGridView1.CurrentRow.Cells[7].Value);


            Global.Get.UpdateProductDetails(ProductID, ProductName, ProductCategory, ProductPrice, ProductQuantity, Status, img);
            BindGridView();
            MessageBox.Show("Product Updated");


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
