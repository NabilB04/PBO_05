namespace TaniAttire.Views.Kasir
{
    partial class TrackPersewaanPengembalian
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
            dateTimePickerTanggal = new DateTimePicker();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // dateTimePickerTanggal
            // 
            dateTimePickerTanggal.Location = new Point(340, 175);
            dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            dateTimePickerTanggal.Size = new Size(250, 27);
            dateTimePickerTanggal.TabIndex = 0;
            dateTimePickerTanggal.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(340, 152);
            label1.Name = "label1";
            label1.Size = new Size(159, 20);
            label1.TabIndex = 1;
            label1.Text = "Tanggal Pengembalian";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(414, 232);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Konfirmasi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TrackPersewaanPengembalian
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 482);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dateTimePickerTanggal);
            Name = "TrackPersewaanPengembalian";
            Text = "TrackPersewaanPengembalian";
            Load += TrackPersewaanPengembalian_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerTanggal;
        private Label label1;
        private Button button1;
    }
}