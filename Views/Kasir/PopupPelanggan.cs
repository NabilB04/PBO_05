using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaniAttire.App.Controllers;
using TaniAttire.App.Models;
using TaniAttire.Views.Auditor.Card;
using TaniAttire.Views.Kasir.Card;

namespace TaniAttire.Views.Kasir
{
    public partial class PopupPelanggan : Form
    {
        private ProdukControllers _produkController;
        public PopupPelanggan()
        {
            InitializeComponent();
            _produkController = new ProdukControllers();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }

        private void PopupPelanggan_Load(object sender, EventArgs e)
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
            var result = MessageBox.Show(
                 "Apakah Anda yakin ingin logout?",
                 "Konfirmasi Logout",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question
             );

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataPelanggan datapelanggan = new DataPelanggan();
            datapelanggan.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormTbhPelanggan formtbhpelanggan = new FormTbhPelanggan();
            formtbhpelanggan.Show();
            Hide();
        }
    }
}
