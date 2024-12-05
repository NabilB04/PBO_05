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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KasirDashboard));
            buttonShiftKasir = new Button();
            buttonPersewaan = new Button();
            buttonTransaksi = new Button();
            button6 = new Button();
            buttonTambah = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            imageList1 = new ImageList(components);
            bindingSource1 = new BindingSource(components);
            bindingSource2 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            SuspendLayout();
            // 
            // buttonShiftKasir
            // 
            buttonShiftKasir.BackColor = Color.LightGray;
            buttonShiftKasir.BackgroundImage = (Image)resources.GetObject("buttonShiftKasir.BackgroundImage");
            buttonShiftKasir.BackgroundImageLayout = ImageLayout.Zoom;
            buttonShiftKasir.ForeColor = Color.White;
            buttonShiftKasir.ImageAlign = ContentAlignment.MiddleLeft;
            buttonShiftKasir.Location = new Point(35, 411);
            buttonShiftKasir.Margin = new Padding(3, 4, 3, 4);
            buttonShiftKasir.Name = "buttonShiftKasir";
            buttonShiftKasir.Padding = new Padding(34, 0, 0, 0);
            buttonShiftKasir.Size = new Size(382, 80);
            buttonShiftKasir.TabIndex = 7;
            buttonShiftKasir.UseVisualStyleBackColor = false;
            buttonShiftKasir.Click += buttonShiftKasir_Click;
            // 
            // buttonPersewaan
            // 
            buttonPersewaan.BackColor = Color.LightGray;
            buttonPersewaan.BackgroundImage = (Image)resources.GetObject("buttonPersewaan.BackgroundImage");
            buttonPersewaan.BackgroundImageLayout = ImageLayout.Zoom;
            buttonPersewaan.ForeColor = Color.White;
            buttonPersewaan.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPersewaan.Location = new Point(35, 323);
            buttonPersewaan.Margin = new Padding(3, 4, 3, 4);
            buttonPersewaan.Name = "buttonPersewaan";
            buttonPersewaan.Padding = new Padding(34, 0, 0, 0);
            buttonPersewaan.Size = new Size(382, 80);
            buttonPersewaan.TabIndex = 6;
            buttonPersewaan.UseVisualStyleBackColor = false;
            buttonPersewaan.Click += buttonPersewaan_Click;
            // 
            // buttonTransaksi
            // 
            buttonTransaksi.BackColor = Color.ForestGreen;
            buttonTransaksi.BackgroundImage = (Image)resources.GetObject("buttonTransaksi.BackgroundImage");
            buttonTransaksi.BackgroundImageLayout = ImageLayout.Zoom;
            buttonTransaksi.ForeColor = Color.White;
            buttonTransaksi.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTransaksi.Location = new Point(35, 235);
            buttonTransaksi.Margin = new Padding(3, 4, 3, 4);
            buttonTransaksi.Name = "buttonTransaksi";
            buttonTransaksi.Padding = new Padding(34, 0, 0, 0);
            buttonTransaksi.Size = new Size(382, 80);
            buttonTransaksi.TabIndex = 5;
            buttonTransaksi.UseVisualStyleBackColor = false;
            buttonTransaksi.Click += buttonTransaksi_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(192, 0, 0);
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Zoom;
            button6.ForeColor = Color.White;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(112, 757);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Padding = new Padding(34, 0, 0, 0);
            button6.Size = new Size(235, 80);
            button6.TabIndex = 9;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.DarkGreen;
            buttonTambah.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTambah.ForeColor = SystemColors.Control;
            buttonTambah.Location = new Point(1068, 111);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(184, 43);
            buttonTambah.TabIndex = 11;
            buttonTambah.Text = "Tambah";
            buttonTambah.UseVisualStyleBackColor = false;
            buttonTambah.Click += buttonTambah_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(441, 160);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(811, 494);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // KasirDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
<<<<<<< HEAD
            ClientSize = new Size(1264, 681);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(buttonTambah);
=======
            ClientSize = new Size(1445, 908);
>>>>>>> 60194a81460d9b91b6088819effea94beb25fc25
            Controls.Add(button6);
            Controls.Add(buttonShiftKasir);
            Controls.Add(buttonPersewaan);
            Controls.Add(buttonTransaksi);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "KasirDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load_1;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonShiftKasir;
        private Button buttonPersewaan;
        private Button buttonTransaksi;
        private Button button6;
        private Button buttonTambah;
        private FlowLayoutPanel flowLayoutPanel1;
        private ImageList imageList1;
        private BindingSource bindingSource1;
        private BindingSource bindingSource2;
    }
}
