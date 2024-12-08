using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaniAttire.Views.Kasir
{
    public partial class TrackPersewaan : Form
    {
        public TrackPersewaan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PenjualanProduk penjualanProduk = new PenjualanProduk();
            penjualanProduk.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersewaanProduk persewaanProduk = new PersewaanProduk();
            persewaanProduk.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anda telah Logout");
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
