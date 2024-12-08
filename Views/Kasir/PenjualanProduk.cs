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
    public partial class PenjualanProduk : Form
    {
        public PenjualanProduk()
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

        //private void buttonShiftKasir_Click(object sender, EventArgs e)
        //{
        //    ShiftKasir shiftKasir = new ShiftKasir();
        //    shiftKasir.Show();
        //    Hide();
        //}

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

        private void button2_Click(object sender, EventArgs e)
        {
            PersewaanProduk persewaanProduk = new PersewaanProduk();
            persewaanProduk.Show();
            Hide();
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
    }
}
