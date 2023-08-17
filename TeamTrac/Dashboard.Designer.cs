namespace TeamTrac
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button6 = new Button();
            button7 = new Button();
            button5 = new Button();
            button8 = new Button();
            button4 = new Button();
            button9 = new Button();
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(35, 112, 248);
            button6.Location = new Point(763, 291);
            button6.Name = "button6";
            button6.Size = new Size(152, 47);
            button6.TabIndex = 22;
            button6.Text = "Support Tickets";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(35, 112, 248);
            button7.Location = new Point(282, 291);
            button7.Name = "button7";
            button7.Size = new Size(173, 47);
            button7.TabIndex = 23;
            button7.Text = "Product Category";
            button7.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(35, 112, 248);
            button5.Location = new Point(535, 291);
            button5.Name = "button5";
            button5.Size = new Size(152, 47);
            button5.TabIndex = 21;
            button5.Text = "Stock Request";
            button5.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(35, 112, 248);
            button8.Location = new Point(524, 161);
            button8.Name = "button8";
            button8.Size = new Size(173, 47);
            button8.TabIndex = 24;
            button8.Text = "OnBoard Delegates";
            button8.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(35, 112, 248);
            button4.Location = new Point(763, 161);
            button4.Name = "button4";
            button4.Size = new Size(152, 47);
            button4.TabIndex = 20;
            button4.Text = "Shops";
            button4.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(35, 112, 248);
            button9.Location = new Point(39, 161);
            button9.Name = "button9";
            button9.Size = new Size(152, 47);
            button9.TabIndex = 25;
            button9.Text = "Access Control";
            button9.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(35, 112, 248);
            button2.Location = new Point(292, 161);
            button2.Name = "button2";
            button2.Size = new Size(152, 47);
            button2.TabIndex = 19;
            button2.Text = "Add New Product";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(35, 112, 248);
            button1.Location = new Point(39, 291);
            button1.Name = "button1";
            button1.Size = new Size(152, 47);
            button1.TabIndex = 18;
            button1.Text = "Add Employee";
            button1.UseVisualStyleBackColor = false;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 28, 36);
            ClientSize = new Size(1189, 640);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button8);
            Controls.Add(button4);
            Controls.Add(button9);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button6;
        private Button button7;
        private Button button5;
        private Button button8;
        private Button button4;
        private Button button9;
        private Button button2;
        private Button button1;
    }
}