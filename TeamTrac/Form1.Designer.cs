namespace TeamTrac
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label5 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Cambria", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(423, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(365, 426);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(186, 224);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(113, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(143, 271);
            button1.Name = "button1";
            button1.Size = new Size(109, 49);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(112, 174);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(187, 32);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(112, 118);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(187, 32);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 174);
            label3.Name = "label3";
            label3.Size = new Size(100, 25);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 121);
            label2.Name = "label2";
            label2.Size = new Size(103, 25);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(125, 29);
            label1.Name = "label1";
            label1.Size = new Size(82, 32);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(25, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(392, 295);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Font = new Font("Cambria", 18F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.Location = new Point(72, 41);
            panel2.Name = "panel2";
            panel2.Size = new Size(319, 85);
            panel2.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cambria", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(128, 56);
            label5.Name = "label5";
            label5.Size = new Size(55, 12);
            label5.TabIndex = 1;
            label5.Text = "TeamTrac";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 14);
            label4.Name = "label4";
            label4.Size = new Size(308, 28);
            label4.TabIndex = 0;
            label4.Text = "Colaboration Without Hassle";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel2;
        private Label label5;
        private Label label4;
        private CheckBox checkBox1;
        private Button button1;
    }
}