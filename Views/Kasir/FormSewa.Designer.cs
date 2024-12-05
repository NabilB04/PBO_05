namespace TaniAttire.Views.Kasir
{
    partial class FormSewa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSewa));
            buttonTambah = new Button();
            dataGridView1 = new DataGridView();
            button6 = new Button();
            buttonPersewaan = new Button();
            buttonTransaksi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.DarkGreen;
            buttonTambah.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTambah.ForeColor = SystemColors.Control;
            buttonTambah.Location = new Point(1059, 68);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(184, 43);
            buttonTambah.TabIndex = 21;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(441, 117);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(802, 495);
            dataGridView1.TabIndex = 20;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(192, 0, 0);
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Zoom;
            button6.ForeColor = Color.White;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(89, 525);
            button6.Name = "button6";
            button6.Padding = new Padding(30, 0, 0, 0);
            button6.Size = new Size(206, 60);
            button6.TabIndex = 19;
            button6.UseVisualStyleBackColor = false;
            // 
            // buttonPersewaan
            // 
            buttonPersewaan.BackColor = Color.LightGray;
            buttonPersewaan.BackgroundImage = (Image)resources.GetObject("buttonPersewaan.BackgroundImage");
            buttonPersewaan.BackgroundImageLayout = ImageLayout.Zoom;
            buttonPersewaan.ForeColor = Color.White;
            buttonPersewaan.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPersewaan.Location = new Point(22, 199);
            buttonPersewaan.Name = "buttonPersewaan";
            buttonPersewaan.Padding = new Padding(30, 0, 0, 0);
            buttonPersewaan.Size = new Size(334, 60);
            buttonPersewaan.TabIndex = 17;
            buttonPersewaan.UseVisualStyleBackColor = false;
            // 
            // buttonTransaksi
            // 
            buttonTransaksi.BackColor = Color.ForestGreen;
            buttonTransaksi.BackgroundImage = (Image)resources.GetObject("buttonTransaksi.BackgroundImage");
            buttonTransaksi.BackgroundImageLayout = ImageLayout.Zoom;
            buttonTransaksi.ForeColor = Color.White;
            buttonTransaksi.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTransaksi.Location = new Point(22, 133);
            buttonTransaksi.Name = "buttonTransaksi";
            buttonTransaksi.Padding = new Padding(30, 0, 0, 0);
            buttonTransaksi.Size = new Size(334, 60);
            buttonTransaksi.TabIndex = 16;
            buttonTransaksi.UseVisualStyleBackColor = false;
            // 
            // FormSewa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(buttonTambah);
            Controls.Add(dataGridView1);
            Controls.Add(button6);
            Controls.Add(buttonPersewaan);
            Controls.Add(buttonTransaksi);
            Name = "FormSewa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSewa";
            Load += FormSewa_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonTambah;
        private DataGridView dataGridView1;
        private Button button6;
        private Button buttonPersewaan;
        private Button buttonTransaksi;
    }
}