namespace TaniAttire
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.TopRight;
            label1.Location = new Point(63, 32);
            label1.Name = "label1";
            label1.Size = new Size(191, 29);
            label1.TabIndex = 0;
            label1.Text = "Selamat Datang";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGreen;
            button2.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(48, 245);
            button2.Name = "button2";
            button2.Size = new Size(219, 37);
            button2.TabIndex = 2;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = false;
            button2.Click += buttonLogin_Click;
            // 
            // textBox1
            // 
            textBox1.ForeColor = SystemColors.WindowFrame;
            textBox1.Location = new Point(48, 116);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(219, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "Ketik username disini";
            // 
            // textBox2
            // 
            textBox2.ForeColor = SystemColors.WindowFrame;
            textBox2.Location = new Point(48, 176);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(219, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "Ketik password disini";
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(304, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 330);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Constantia", 12F);
            label3.Location = new Point(48, 94);
            label3.Name = "label3";
            label3.Size = new Size(80, 19);
            label3.TabIndex = 6;
            label3.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Constantia", 12F);
            label2.Location = new Point(48, 154);
            label2.Name = "label2";
            label2.Size = new Size(74, 19);
            label2.TabIndex = 5;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(680, 450);
            Controls.Add(panel1);
            Name = "Login";
            Opacity = 0.5D;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Panel panel1;
        private Label label3;
        private Label label2;
    }
}
