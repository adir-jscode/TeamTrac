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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCategory category = new AddCategory();
            category.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            OnBoardDelegate onBoard = new OnBoardDelegate();
            onBoard.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEmployee employee = new ManageEmployee();
            employee.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Hide();
            panel4.BringToFront();
            panel4.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel5.BringToFront();
            panel5.Show();
        }
    }
}
