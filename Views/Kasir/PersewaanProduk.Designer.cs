
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
            button6 = new Button();
            buttonShiftKasir = new Button();
            buttonPersewaan = new Button();
            buttonTransaksi = new Button();
            SuspendLayout();
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(192, 0, 0);
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Zoom;
            button6.ForeColor = Color.White;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(98, 568);
            button6.Name = "button6";
            button6.Padding = new Padding(30, 0, 0, 0);
            button6.Size = new Size(206, 60);
            button6.TabIndex = 13;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // buttonShiftKasir
            // 
            buttonShiftKasir.BackColor = Color.LightGray;
            buttonShiftKasir.BackgroundImage = (Image)resources.GetObject("buttonShiftKasir.BackgroundImage");
            buttonShiftKasir.BackgroundImageLayout = ImageLayout.Zoom;
            buttonShiftKasir.ForeColor = Color.White;
            buttonShiftKasir.ImageAlign = ContentAlignment.MiddleLeft;
            buttonShiftKasir.Location = new Point(31, 308);
            buttonShiftKasir.Name = "buttonShiftKasir";
            buttonShiftKasir.Padding = new Padding(30, 0, 0, 0);
            buttonShiftKasir.Size = new Size(334, 60);
            buttonShiftKasir.TabIndex = 12;
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
            buttonPersewaan.Location = new Point(31, 242);
            buttonPersewaan.Name = "buttonPersewaan";
            buttonPersewaan.Padding = new Padding(30, 0, 0, 0);
            buttonPersewaan.Size = new Size(334, 60);
            buttonPersewaan.TabIndex = 11;
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
            buttonTransaksi.Location = new Point(31, 176);
            buttonTransaksi.Name = "buttonTransaksi";
            buttonTransaksi.Padding = new Padding(30, 0, 0, 0);
            buttonTransaksi.Size = new Size(334, 60);
            buttonTransaksi.TabIndex = 10;
            buttonTransaksi.UseVisualStyleBackColor = false;
            buttonTransaksi.Click += buttonTransaksi_Click;
            // 
            // PersewaanProduk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(button6);
            Controls.Add(buttonShiftKasir);
            Controls.Add(buttonPersewaan);
            Controls.Add(buttonTransaksi);
            DoubleBuffered = true;
            Name = "PersewaanProduk";
            Text = "PersewaanProduk";
            Load += PersewaanProduk_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button6;
        private Button buttonShiftKasir;
        private Button buttonPersewaan;
        private Button buttonTransaksi;
    }
}