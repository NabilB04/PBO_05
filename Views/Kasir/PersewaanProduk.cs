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
    public partial class PersewaanProduk : Form
    {
        public PersewaanProduk()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }

        private void PersewaanProduk_Load(object sender, EventArgs e)
        {

        }

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            PenjualanProduk kasirDashboard = new PenjualanProduk();
            kasirDashboard.Show();
            Hide();
        }

        private void buttonPersewaan_Click(object sender, EventArgs e)
        {

        }

        //private void buttonShiftKasir_Click(object sender, EventArgs e)
        //{
        //    ShiftKasir shiftKasir = new ShiftKasir();
        //    shiftKasir.Show();
        //    Hide();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            PenjualanProduk penjualanProduk = new PenjualanProduk();
            penjualanProduk.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TrackPersewaan trackPersewaan = new TrackPersewaan();
            trackPersewaan.Show();
            Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Anda telah Logout");
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {

        }
    }
}
