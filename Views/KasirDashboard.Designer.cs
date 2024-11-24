namespace TaniAttire
{
    partial class KasirDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KasirDashboard));
            panelSidebar = new Panel();
            buttonLogOut = new Button();
            buttonLaporan = new Button();
            buttonTransaksi = new Button();
            buttonProduk = new Button();
            buttonBeranda = new Button();
            labelBeranda = new Label();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.LightGreen;
            panelSidebar.Controls.Add(buttonLogOut);
            panelSidebar.Controls.Add(buttonLaporan);
            panelSidebar.Controls.Add(buttonTransaksi);
            panelSidebar.Controls.Add(buttonProduk);
            panelSidebar.Controls.Add(buttonBeranda);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(229, 600);
            panelSidebar.TabIndex = 0;
            // 
            // buttonLogOut
            // 
            buttonLogOut.BackColor = Color.Red;
            buttonLogOut.ForeColor = Color.White;
            buttonLogOut.Image = (Image)resources.GetObject("buttonLogOut.Image");
            buttonLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLogOut.Location = new Point(14, 507);
            buttonLogOut.Margin = new Padding(3, 4, 3, 4);
            buttonLogOut.Name = "buttonLogOut";
            buttonLogOut.Padding = new Padding(34, 0, 0, 0);
            buttonLogOut.Size = new Size(201, 53);
            buttonLogOut.TabIndex = 4;
            buttonLogOut.Text = "   Log Out";
            buttonLogOut.UseVisualStyleBackColor = false;
            buttonLogOut.MouseEnter += button_MouseEnter;
            buttonLogOut.MouseLeave += button_MouseLeave;
            // 
            // buttonLaporan
            // 
            buttonLaporan.BackColor = Color.White;
            buttonLaporan.ForeColor = Color.Green;
            buttonLaporan.Image = (Image)resources.GetObject("buttonLaporan.Image");
            buttonLaporan.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLaporan.Location = new Point(14, 273);
            buttonLaporan.Margin = new Padding(3, 4, 3, 4);
            buttonLaporan.Name = "buttonLaporan";
            buttonLaporan.Padding = new Padding(34, 0, 0, 0);
            buttonLaporan.Size = new Size(201, 79);
            buttonLaporan.TabIndex = 3;
            buttonLaporan.Text = "    Laporan dan Forecasting";
            buttonLaporan.UseVisualStyleBackColor = false;
            buttonLaporan.Click += buttonLaporan_Click;
            buttonLaporan.MouseEnter += button_MouseEnter1;
            buttonLaporan.MouseLeave += button_MouseLeave1;
            // 
            // buttonTransaksi
            // 
            buttonTransaksi.BackColor = Color.White;
            buttonTransaksi.ForeColor = Color.Green;
            buttonTransaksi.Image = (Image)resources.GetObject("buttonTransaksi.Image");
            buttonTransaksi.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTransaksi.Location = new Point(14, 212);
            buttonTransaksi.Margin = new Padding(3, 4, 3, 4);
            buttonTransaksi.Name = "buttonTransaksi";
            buttonTransaksi.Padding = new Padding(34, 0, 0, 0);
            buttonTransaksi.Size = new Size(201, 53);
            buttonTransaksi.TabIndex = 2;
            buttonTransaksi.Text = "Transaksi";
            buttonTransaksi.UseVisualStyleBackColor = false;
            buttonTransaksi.MouseEnter += button_MouseEnter1;
            buttonTransaksi.MouseLeave += button_MouseLeave1;
            // 
            // buttonProduk
            // 
            buttonProduk.BackColor = Color.White;
            buttonProduk.ForeColor = Color.Green;
            buttonProduk.Image = (Image)resources.GetObject("buttonProduk.Image");
            buttonProduk.ImageAlign = ContentAlignment.MiddleLeft;
            buttonProduk.Location = new Point(14, 151);
            buttonProduk.Margin = new Padding(3, 4, 3, 4);
            buttonProduk.Name = "buttonProduk";
            buttonProduk.Padding = new Padding(34, 0, 0, 0);
            buttonProduk.Size = new Size(201, 53);
            buttonProduk.TabIndex = 1;
            buttonProduk.Text = "         Pengelolaan Produk";
            buttonProduk.UseVisualStyleBackColor = false;
            buttonProduk.Click += buttonProduk_Click;
            buttonProduk.MouseEnter += button_MouseEnter1;
            buttonProduk.MouseLeave += button_MouseLeave1;
            // 
            // buttonBeranda
            // 
            buttonBeranda.BackColor = Color.ForestGreen;
            buttonBeranda.ForeColor = Color.White;
            buttonBeranda.Image = (Image)resources.GetObject("buttonBeranda.Image");
            buttonBeranda.ImageAlign = ContentAlignment.MiddleLeft;
            buttonBeranda.Location = new Point(14, 89);
            buttonBeranda.Margin = new Padding(3, 4, 3, 4);
            buttonBeranda.Name = "buttonBeranda";
            buttonBeranda.Padding = new Padding(34, 0, 0, 0);
            buttonBeranda.Size = new Size(201, 53);
            buttonBeranda.TabIndex = 0;
            buttonBeranda.Text = "Beranda";
            buttonBeranda.UseVisualStyleBackColor = false;
            buttonBeranda.MouseEnter += button_MouseEnter1;
            buttonBeranda.MouseLeave += button_MouseLeave1;
            // 
            // labelBeranda
            // 
            labelBeranda.AutoSize = true;
            labelBeranda.Font = new Font("Arial", 24F, FontStyle.Bold);
            labelBeranda.ForeColor = Color.Green;
            labelBeranda.Location = new Point(343, 53);
            labelBeranda.Name = "labelBeranda";
            labelBeranda.Size = new Size(178, 46);
            labelBeranda.TabIndex = 1;
            labelBeranda.Text = "Beranda";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(labelBeranda);
            Controls.Add(panelSidebar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load_1;
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Button buttonLaporan;
        private System.Windows.Forms.Button buttonTransaksi;
        private System.Windows.Forms.Button buttonProduk;
        private System.Windows.Forms.Button buttonBeranda;
        private System.Windows.Forms.Label labelBeranda;
    }
}
