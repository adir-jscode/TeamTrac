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
            panel1 = new Panel();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Font = new Font("Cambria", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 664);
            panel1.TabIndex = 0;
            // 
            // button9
            // 
            button9.Location = new Point(24, 133);
            button9.Name = "button9";
            button9.Size = new Size(152, 47);
            button9.TabIndex = 9;
            button9.Text = "Access Control";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(12, 186);
            button8.Name = "button8";
            button8.Size = new Size(173, 47);
            button8.TabIndex = 8;
            button8.Text = "OnBoard Delegates";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(12, 239);
            button7.Name = "button7";
            button7.Size = new Size(173, 47);
            button7.TabIndex = 7;
            button7.Text = "Product Category";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(25, 582);
            button6.Name = "button6";
            button6.Size = new Size(152, 47);
            button6.TabIndex = 6;
            button6.Text = "Support Tickets";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(25, 512);
            button5.Name = "button5";
            button5.Size = new Size(152, 47);
            button5.TabIndex = 5;
            button5.Text = "Stock Request";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(24, 439);
            button4.Name = "button4";
            button4.Size = new Size(152, 47);
            button4.TabIndex = 4;
            button4.Text = "Shops";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(24, 374);
            button3.Name = "button3";
            button3.Size = new Size(152, 47);
            button3.TabIndex = 3;
            button3.Text = "Sales";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(24, 307);
            button2.Name = "button2";
            button2.Size = new Size(152, 47);
            button2.TabIndex = 2;
            button2.Text = "Products";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(25, 80);
            button1.Name = "button1";
            button1.Size = new Size(152, 47);
            button1.TabIndex = 1;
            button1.Text = "Add Employee";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 31);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(88, 22);
            label1.TabIndex = 0;
            label1.Text = "TeamTrac";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Top;
            panel2.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.Location = new Point(200, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(986, 75);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Location = new Point(6, 106);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(980, 546);
            panel3.TabIndex = 2;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1186, 664);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Cambria", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Dashboard";
            Text = "Dashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Button button1;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
    }
}