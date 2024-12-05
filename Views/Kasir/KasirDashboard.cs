using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaniAttire.Views.Kasir;

namespace TaniAttire
{
    public partial class KasirDashboard : Form
    {
        public KasirDashboard()
        {
            InitializeComponent();

        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {

        }

        private void buttonShiftKasir_Click(object sender, EventArgs e)
        {
            ShiftKasir shiftKasir = new ShiftKasir();
            shiftKasir.Show();
            Hide();
        }

        private void buttonPersewaan_Click(object sender, EventArgs e)
        {
            PersewaanProduk persewaanproduk = new PersewaanProduk();
            persewaanproduk.Show();
            Hide();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormJual formJual = new FormJual();
            formJual.Show();
            Hide();
        }
    }
}
