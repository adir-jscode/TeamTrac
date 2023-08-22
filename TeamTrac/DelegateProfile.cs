using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeamTrac
{
    public partial class DelegateProfile : Form
    {
        public DelegateProfile()
        {
            InitializeComponent();
            DelegateInfo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DelegateDashboard dashboard = new DelegateDashboard();
            dashboard.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void DelegateInfo()
        {
            List<Model.DelegateDetails> delegateDetails = Global.Get.LoginDelegate(Form1.UserName, Form1.Password);
            foreach (var user in delegateDetails)
            {
                textBox1.Text = user.DelegateName;
                textBox2.Text = user.Email;
                textBox3.Text = user.NID;
                textBox4.Text = user.DelegateArea;
                textBox5.Text = user.DelegateDistrict;
                textBox6.Text = user.DOB;
                textBox7.Text = user.Username;
                guna2CirclePictureBox1.Image = GetPhoto((byte[])user.Image);




            }
        }
    }
}
