namespace TeamTrac
{
    public partial class Form1 : Form
    {

        public static string UserName;
        public static string Password;
        public static string ID;
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
            bool exists = Global.Get.UserExist(textBox1.Text);
            if (string.IsNullOrEmpty(textBox1.Text) || !exists)
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.error;
                errorProvider1.SetError(this.textBox1, "Enter Valid Username");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.check;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox2, "Enter Password");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnBoardDelegate RegisterDelegate = new OnBoardDelegate();
            RegisterDelegate.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserName = textBox1.Text;
            Password = textBox2.Text;

            //Login as company

            if (!string.IsNullOrEmpty(UserName))
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    if (Global.Get.LoginAuth(UserName, Password))
                    {
                        MessageBox.Show("Login Successful");
                        ///guna2MessageDialog1.Show("Login");
                        ID = Global.Get.GetID(UserName);
                        this.Hide();
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                    }
                    else if (Global.Get.LoginAuthEmployee(UserName, Password))
                    {
                        MessageBox.Show("Welcome to OnBoard " + UserName);
                        this.Hide();
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                    }

                    else if (Global.Get.LoginAuthDelegate(UserName, Password))
                    {
                        MessageBox.Show("Welcome to our Enviroment " + UserName);
                        ID = Global.Get.GetDelID(UserName);
                        this.Hide();
                        DelegateDashboard dashboardDel = new DelegateDashboard();
                        dashboardDel.Show();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterCompany registerCompany = new RegisterCompany();
            registerCompany.Show();
        }
    }
}