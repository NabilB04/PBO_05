
namespace TaniAttire.Views.Auditor
{
    partial class Tambah_Karyawan
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
            textboxNama = new TextBox();
            labelNama = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textboxUsername = new TextBox();
            textboxPassword = new TextBox();
            textboxNotelp = new TextBox();
            buttonTambah = new Button();
            SuspendLayout();
            // 
            // textboxNama
            // 
            textboxNama.Location = new Point(168, 50);
            textboxNama.Name = "textboxNama";
            textboxNama.Size = new Size(326, 23);
            textboxNama.TabIndex = 0;
            textboxNama.TextChanged += textBox1_TextChanged;
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.Location = new Point(58, 50);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(39, 15);
            labelNama.TabIndex = 1;
            labelNama.Text = "Nama";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 99);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 146);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 192);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 4;
            label3.Text = "No Telepon";
            // 
            // textboxUsername
            // 
            textboxUsername.Location = new Point(168, 96);
            textboxUsername.Name = "textboxUsername";
            textboxUsername.Size = new Size(326, 23);
            textboxUsername.TabIndex = 5;
            // 
            // textboxPassword
            // 
            textboxPassword.Location = new Point(168, 143);
            textboxPassword.Name = "textboxPassword";
            textboxPassword.Size = new Size(326, 23);
            textboxPassword.TabIndex = 6;
            // 
            // textboxNotelp
            // 
            textboxNotelp.Location = new Point(168, 189);
            textboxNotelp.Name = "textboxNotelp";
            textboxNotelp.Size = new Size(326, 23);
            textboxNotelp.TabIndex = 7;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.Lime;
            buttonTambah.Location = new Point(419, 267);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(75, 23);
            buttonTambah.TabIndex = 8;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            buttonTambah.Click += buttonTambah_Click;
            // 
            // Tambah_Karyawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(584, 361);
            Controls.Add(buttonTambah);
            Controls.Add(textboxNotelp);
            Controls.Add(textboxPassword);
            Controls.Add(textboxUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelNama);
            Controls.Add(textboxNama);
            DoubleBuffered = true;
            Name = "Tambah_Karyawan";
            Text = "TambahKaryawan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textboxNama;
        private Label labelNama;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textboxUsername;
        private TextBox textboxPassword;
        private TextBox textboxNotelp;
        private Button buttonTambah;
    }
}