namespace TaniAttire.Views.Kasir
{
    partial class PenjualanDetailProduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenjualanDetailProduk));
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button6 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            SuspendLayout();
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
            button3.Location = new Point(12, 533);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(461, 151);
            button3.TabIndex = 38;
            button3.UseVisualStyleBackColor = false;
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
            button2.Location = new Point(12, 375);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(461, 151);
            button2.TabIndex = 37;
            button2.UseVisualStyleBackColor = false;
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
            button1.Location = new Point(12, 216);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(461, 151);
            button1.TabIndex = 36;
            button1.UseVisualStyleBackColor = true;
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
            button6.Location = new Point(12, 805);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Padding = new Padding(34, 0, 0, 0);
            button6.Size = new Size(461, 75);
            button6.TabIndex = 35;
            button6.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Location = new Point(491, 149);
            flowLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(951, 639);
            flowLayoutPanel2.TabIndex = 39;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // PenjualanDetailProduk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1445, 908);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button6);
            Cursor = Cursors.IBeam;
            Load += Dashboard_Load_1;
            Name = "PenjualanDetailProduk";
            Text = "PenjualanDetailProduk";
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private Button button6;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}