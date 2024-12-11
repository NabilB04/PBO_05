using System.Windows.Forms;

namespace TaniAttire.Views.Kasir.Card
{
    partial class CardDetailProduk
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            comboBoxUkuran = new ComboBox();
            textBoxJumlah = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(125, 219);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 1;
            label1.Text = "Label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(125, 257);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 2;
            label2.Text = "Label2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(304, 215);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // comboBoxUkuran
            // 
            comboBoxUkuran.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxUkuran.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUkuran.Location = new Point(11, 298);
            comboBoxUkuran.Margin = new Padding(3, 4, 3, 4);
            comboBoxUkuran.Name = "comboBoxUkuran";
            comboBoxUkuran.Size = new Size(279, 28);
            comboBoxUkuran.TabIndex = 4;
            comboBoxUkuran.SelectedIndexChanged += comboBoxUkuran_SelectedIndexChanged;
            // 
            // textBoxJumlah
            // 
            textBoxJumlah.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxJumlah.Location = new Point(11, 399);
            textBoxJumlah.Margin = new Padding(3, 4, 3, 4);
            textBoxJumlah.Name = "textBoxJumlah";
            textBoxJumlah.Size = new Size(279, 27);
            textBoxJumlah.TabIndex = 5;
            textBoxJumlah.TextChanged += textBoxJumlah_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(11, 274);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 6;
            label3.Text = "Ukuran";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(125, 348);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 7;
            label4.Text = "Label4";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(11, 375);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 8;
            label5.Text = "Jumlah";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CardDetailProduk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxUkuran);
            Controls.Add(textBoxJumlah);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CardDetailProduk";
            Size = new Size(304, 446);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label label1;
        public Label label2;
        public PictureBox pictureBox1;
        public ComboBox comboBoxUkuran;
        public TextBox textBoxJumlah;
        private Panel panelWrapper;
        public Label label3;
        public Label label4;
        public Label label5;
    }
}
