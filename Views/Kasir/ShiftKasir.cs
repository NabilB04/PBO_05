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
    public partial class ShiftKasir : Form
    {
        public ShiftKasir()
        {
            InitializeComponent();
        }

        private void buttonPersewaan_Click(object sender, EventArgs e)
        {
            PersewaanProduk persewaanProduk = new PersewaanProduk();
            persewaanProduk.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            KasirDashboard kasirDashboard = new KasirDashboard();
            kasirDashboard.Show();
            Hide();
        }
    }
}
