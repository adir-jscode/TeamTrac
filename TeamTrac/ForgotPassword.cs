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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            bool exists = Global.Get.UserExist(textBox1.Text);
            if (!exists)
            {
                MessageBox.Show("User does not exist");
                return;
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            else
            {
                Global.Get.UpdatePassword(textBox1.Text, textBox2.Text);
                MessageBox.Show("Password Updated");
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            //if (!exists)
            //{
            //    MessageBox.Show("User does not exist");
            //    return;
            //}
        }

        private void ForgotPassword_Leave(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            bool exists = Global.Get.UserExist(textBox1.Text);
            if (string.IsNullOrEmpty(textBox1.Text) || !exists)
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.error;
                errorProvider1.SetError(this.textBox1, "Please Enter Valid Email Address");

            }
            else
            {
                errorProvider1.Icon = Properties.Resources.check;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {

                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox2, "Please Enter Password");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBox3.Text) || textBox2.Text != textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.Icon = Properties.Resources.error;
                errorProvider3.SetError(this.textBox3, "Please Enter Correct Passowrd");
                MessageBox.Show("Passwords do not match");

            }
            else
            {
                errorProvider3.Icon = Properties.Resources.check;
            }
        }
    }
}
