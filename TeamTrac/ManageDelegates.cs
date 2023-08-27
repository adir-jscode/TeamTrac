using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TeamTrac
{
    public partial class ManageDelegates : Form
    {
        public ManageDelegates()
        {
            InitializeComponent();
            BindGridView();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        void BindGridView()
        {

            DataTable DelegateInfo = Global.Get.DelegateDetails();
            guna2DataGridView1.DataSource = DelegateInfo;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)guna2DataGridView1.Columns[8];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            guna2DataGridView1.RowTemplate.Height = 80;

            // Manipulate the "status" column
            //foreach (DataRow row in DelegateInfo.Rows)
            //{
            //    // Access the "status" column by its name
            //    if (row["status"].ToString() == "1")
            //    {
            //        // You can update the value of the "status" column
            //        row["status"] = "Active";
            //    }
            //    else
            //    {
            //        row["status"] = "Inactive";
            //    }
            //}


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void ManageDelegates_Load(object sender, EventArgs e)
        {

        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string DelegateID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            string DelegateName = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = DelegateName;
            string PhoneNo = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = PhoneNo;
            string Email = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = Email;
            string NID = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = NID;
            string DelegateArea = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = DelegateArea;
            string DelegateDistrict = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = DelegateDistrict;
            string Username = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox5.Text = Username;

            guna2CirclePictureBox1.Image = GetPhoto((byte[])guna2DataGridView1.CurrentRow.Cells[8].Value);


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string DelegateID = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            Global.Get.DeleteDelegate(DelegateID);
            BindGridView();
            MessageBox.Show("Dekegate Deleted");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string DelegateID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            string DelegateName = textBox1.Text;
            string PhoneNo = textBox2.Text;
            string Email = textBox3.Text;
            string NID = textBox4.Text;
            string DelegateArea = textBox7.Text;
            string DelegateDistrict = textBox8.Text;
            string Username = textBox5.Text;




            byte[] img = SavePhoto();



            Global.Get.UpdateDelegateDetails(DelegateID, DelegateName, Email, NID, DelegateArea, Username, DelegateDistrict, img);
            BindGridView();
            MessageBox.Show("Delegate Updated");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
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
