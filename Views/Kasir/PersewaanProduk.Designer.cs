﻿
namespace TaniAttire.Views.Kasir
{
    partial class PersewaanProduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersewaanProduk));
            buttonTambah = new Button();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.DarkGreen;
            buttonTambah.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTambah.ForeColor = SystemColors.Control;
            buttonTambah.Location = new Point(1068, 111);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(184, 43);
            buttonTambah.TabIndex = 15;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            buttonTambah.Click += buttonTambah_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.LightGreen;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(450, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(802, 495);
            dataGridView1.TabIndex = 14;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ButtonHighlight;
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(12, 413);
            button3.Name = "button3";
            button3.Size = new Size(403, 113);
            button3.TabIndex = 38;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(12, 294);
            button2.Name = "button2";
            button2.Size = new Size(403, 113);
            button2.TabIndex = 37;
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 175);
            button1.Name = "button1";
            button1.Size = new Size(403, 113);
            button1.TabIndex = 36;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.Control;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button6.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.White;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(12, 617);
            button6.Name = "button6";
            button6.Padding = new Padding(30, 0, 0, 0);
            button6.Size = new Size(403, 56);
            button6.TabIndex = 35;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click_1;
            // 
            // PersewaanProduk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button6);
            Controls.Add(buttonTambah);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            Name = "PersewaanProduk";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PersewaanProduk";
            Load += PersewaanProduk_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonTambah;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button6;
    }
}