﻿namespace TeamTrac
{
    partial class SupportTickets
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupportTickets));
            panel1 = new Panel();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            label1 = new Label();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(guna2Button2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(guna2DataGridView1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(77, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1072, 607);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // guna2Button2
            // 
            guna2Button2.CustomizableEdges = customizableEdges1;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.Purple;
            guna2Button2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(866, 538);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button2.Size = new Size(180, 45);
            guna2Button2.TabIndex = 13;
            guna2Button2.Text = "Solved";
            guna2Button2.Click += guna2Button2_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(762, 552);
            label2.Name = "label2";
            label2.Size = new Size(59, 22);
            label2.TabIndex = 12;
            label2.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(414, 28);
            label1.Name = "label1";
            label1.Size = new Size(196, 32);
            label1.TabIndex = 10;
            label1.Text = "Support Tickets";
            // 
            // guna2DataGridView1
            // 
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.BackgroundColor = Color.FromArgb(22, 28, 36);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 25;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(444, 96);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowTemplate.Height = 25;
            guna2DataGridView1.Size = new Size(602, 412);
            guna2DataGridView1.TabIndex = 1;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.FromArgb(22, 28, 36);
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(22, 28, 36);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 25;
            guna2DataGridView1.ThemeStyle.ReadOnly = true;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(22, 28, 36);
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 25;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.CellMouseClick += guna2DataGridView1_CellMouseClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 96);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(395, 353);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // SupportTickets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 28, 36);
            ClientSize = new Size(1189, 640);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SupportTickets";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SupportTickets";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}