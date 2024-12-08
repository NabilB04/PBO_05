namespace TaniAttire
{
    partial class PenjualanProduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenjualanProduk));
            buttonTambah = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            imageList1 = new ImageList(components);
            bindingSource1 = new BindingSource(components);
            bindingSource2 = new BindingSource(components);
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
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
            button6.Location = new Point(21, 613);
            button6.Name = "button6";
            button6.Padding = new Padding(30, 0, 0, 0);
            button6.Size = new Size(403, 56);
            button6.TabIndex = 31;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click_1;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(21, 171);
            button1.Name = "button1";
            button1.Size = new Size(403, 113);
            button1.TabIndex = 32;
            button1.UseVisualStyleBackColor = true;
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
            button2.Location = new Point(21, 290);
            button2.Name = "button2";
            button2.Size = new Size(403, 113);
            button2.TabIndex = 33;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
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
            button3.Location = new Point(21, 409);
            button3.Name = "button3";
            button3.Size = new Size(403, 113);
            button3.TabIndex = 34;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Location = new Point(430, 110);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(832, 479);
            flowLayoutPanel2.TabIndex = 35;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // PenjualanProduk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button6);
            DoubleBuffered = true;
            Name = "PenjualanProduk";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load_1;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonTambah;
        private FlowLayoutPanel flowLayoutPanel1;
        private ImageList imageList1;
        private BindingSource bindingSource1;
        private BindingSource bindingSource2;
        private Button button6;
        private Button button1;
        private Button button2;
        private Button button3;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}
