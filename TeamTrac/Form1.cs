namespace TeamTrac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBox1.Checked;
            if (isChecked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnBoardDelegate RegisterDelegate = new OnBoardDelegate();
            RegisterDelegate.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;
            string Password = textBox2.Text;

            //Login as company

            if (!string.IsNullOrEmpty(UserName))
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    if (Global.Get.LoginAuth(UserName, Password))
                    {
                        MessageBox.Show("Login Successful");
                        //this.Hide();
                        //Dashboard dashboard = new Dashboard();
                        //dashboard.Show();
                    }
                    else if(Global.Get.LoginAuthEmployee(UserName, Password))
                    {
                        MessageBox.Show("Welcome to OnBoard " + UserName);
                        //this.Hide();
                        //Dashboard dashboard = new Dashboard();
                        //dashboard.Show();
                    }




                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }

                else
                {
                    MessageBox.Show("Please Enter Password");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Username");
            }

            //Login as Employee 
            
            //if (!string.IsNullOrEmpty(UserName))
            //{
            //    if (!string.IsNullOrEmpty(Password))
            //    {
            //        if (Global.Get.LoginAuthEmployee(UserName, Password))
            //        {
            //            MessageBox.Show("Welcome to OnBoard" + UserName);
            //            //this.Hide();
            //            //Dashboard dashboard = new Dashboard();
            //            //dashboard.Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Invalid Username or Password");
            //        }
            //    }

            //    else
            //    {
            //        MessageBox.Show("Please Enter Password");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please Enter Username");
            //}



        }

       

    }
}