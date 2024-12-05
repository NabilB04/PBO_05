
namespace TaniAttire.Views.Kasir
{
    partial class FormJual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJual));
            dataGridView1 = new DataGridView();
            button6 = new Button();
            buttonPersewaan = new Button();
            buttonTransaksi = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(928, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(324, 638);
            dataGridView1.TabIndex = 16;
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
            button6.TabIndex = 15;
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
            buttonPersewaan.TabIndex = 13;
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
            buttonTransaksi.TabIndex = 12;
            buttonTransaksi.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(362, 31);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(560, 638);
            flowLayoutPanel1.TabIndex = 17;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // FormJual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(dataGridView1);
            Controls.Add(button6);
            Controls.Add(buttonPersewaan);
            Controls.Add(buttonTransaksi);
            Name = "FormJual";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormJual";
            Load += FormJual_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion
        private DataGridView dataGridView1;
        private Button button6;
        private Button buttonPersewaan;
        private Button buttonTransaksi;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}