﻿using System;
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
    public partial class OnBoardDelegate : Form
    {
        public OnBoardDelegate()
        {
            InitializeComponent();
        }

        private void OnBoardDelegate_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();



            //numericUpDown1.Value = 0;
            //guna2CirclePictureBox1.Image = Properties.Resources.login_teamtrac;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Phone = textBox2.Text;
            string Email = textBox3.Text;
            string NID = textBox4.Text;
            string DOB = dateTimePicker1.Text;
            string JoiningDate = dateTimePicker2.Text;
            string Username = textBox5.Text;
            string Password = textBox6.Text;
            string DelegatingArea = textBox7.Text;
            string DelegatingDistrict = textBox8.Text;
            string DelegateAddress = textBox9.Text;
            string ZipCode = textBox10.Text;
            byte[] imageBytes = SavePhoto();
            //string Image = Convert.ToBase64String(imageBytes);



            if (Name == "" || Phone == "" || Email == "" || DelegateAddress == "" || NID == "" || DOB == "" || JoiningDate == "" || Username == "" || Password == "" || DelegatingArea == "" || DelegatingDistrict == "" || imageBytes == null || ZipCode == "")
            {
                MessageBox.Show("Please Fill All The Fields");
            }
            else
            {
                Global.Get.OnboardDelegate(Name, Phone, Email, DelegateAddress, NID, DOB, JoiningDate, Username, Password, DelegatingArea, DelegatingDistrict, imageBytes, ZipCode);
                MessageBox.Show("Delegate Onboarded Successfully");
            }

            ResetControl();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
