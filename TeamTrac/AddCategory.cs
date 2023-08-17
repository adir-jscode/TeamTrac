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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        void BindGridView()
        {

            DataTable CategoryTable = Global.Get.ProductCategory();
            guna2DataGridView1.DataSource = CategoryTable;

            // Manipulate the "status" column
            foreach (DataRow row in CategoryTable.Rows)
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


        private void AddCategory_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MainCategory = textBox1.Text;
            string SubCategory = textBox2.Text;
            Global.Get.AddCategory(MainCategory, SubCategory);
            BindGridView();
            MessageBox.Show("Category Added");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();

            Global.Get.DeleteProductCategory(id);
            BindGridView();
            MessageBox.Show("Category Deleted");

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MainCategory = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = MainCategory;
            string SubCategory = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = SubCategory;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();

            Global.Get.UpdateProductCategory(id, textBox1.Text, textBox2.Text);
            BindGridView();
            MessageBox.Show("Category Updated");

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
