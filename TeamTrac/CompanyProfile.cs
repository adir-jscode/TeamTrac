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
    public partial class CompanyProfile : Form
    {
        public CompanyProfile()
        {
            InitializeComponent();
            CompnayInfo();
            //textBox1.Text = Form1.ID;

        }

        private void CompnayInfo()
        {
            List<Model.CompanyDetails> userList = Global.Get.LoginCompany(Form1.UserName,Form1.Password);
            foreach (var user in userList)
            {
                textBox1.Text = user.CompanyName;
                textBox2.Text = user.CompanyAddress;
                textBox3.Text = user.CompnayBin;
                textBox4.Text = user.TradeLicenceNo;
                textBox5.Text = user.ContactNo;
                textBox6.Text = user.OwnerFullName;
                textBox7.Text = user.CompanyEmail;
                textBox8.Text = user.OwnerEmail;
                textBox9.Text = user.NID;
                textBox10.Text = user.PhoneNo;
                textBox11.Text = user.Username;
                //textBox12.Text = user.Password;
                //textBox13.Text = user.Status;
                //textBox14.Text = user.Logo;
            }
        }


        private void CompanyProfile_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
