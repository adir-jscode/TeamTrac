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
                textBox6.Text = user.CompanyEmail;
                textBox7.Text = user.Username;
                textBox8.Text = user.OwnerFullName;
                textBox9.Text = user.OwnerEmail;
                textBox10.Text = user.NID;
                textBox11.Text = user.PhoneNo;
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
            string ID = Form1.ID;
            string CompanyName = textBox1.Text;
            string CompanyAddress = textBox2.Text;
            string CompnayBin = textBox3.Text;
            string TradeLicenceNo = textBox4.Text;
            string ContactNo = textBox5.Text;
            string CompanyEmail = textBox6.Text;
            string Username = textBox7.Text;
            string OwnerFullName = textBox8.Text;
            string OwnerEmail = textBox9.Text;
            string NID = textBox10.Text;
            string PhoneNo = textBox11.Text;

            Global.Get.UpdateCompnayDetails(ID,CompanyName, CompanyAddress, CompnayBin, TradeLicenceNo, ContactNo, CompanyEmail, Username, OwnerFullName, OwnerEmail, NID, PhoneNo);
            MessageBox.Show("Company Details Updated Successfully");
            



        }
    }
}
