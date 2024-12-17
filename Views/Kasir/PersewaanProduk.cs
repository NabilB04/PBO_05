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
    public partial class PersewaanProduk : Form
    {
        private ProdukControllers _produkController;
        public PersewaanProduk()
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
        public static class SessionData
        {
            public static int? SelectedProdukId { get; set; }
            public static int? SelectedPelangganId { get; set; }
        }
        private void PersewaanProduk_Load(object sender, EventArgs e)
        {
            try
            {
                // Ambil data produk dari database
                List<GetProduk> produkList = _produkController.GetTotalProduk();

                // Iterasi setiap produk untuk ditampilkan
                foreach (var produk in produkList)
                {
                    // Buat instance dari CardProduk
                    CardSewa cardSewa = new CardSewa
                    {
                        Margin = new Padding(3),
                    };

                    // Set data produk ke dalam card
                    cardSewa.label1.Text = $"{produk.Nama_Produk:N0}";
                    cardSewa.label2.Text = $"Harga Sewa: Rp {produk.Harga_Sewa:N0}";
                    cardSewa.label3.Text = $"Denda perhari : Rp {produk.Denda_Perhari:N0}";

                    // Set gambar produk jika ada
                    if (!string.IsNullOrEmpty(produk.Foto_Produk))
                    {
                        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", produk.Foto_Produk);
                        if (File.Exists(imagePath))
                        {
                            cardSewa.pictureBox1.Image = Image.FromFile(imagePath);
                        }
                    }

                    // Menambahkan event klik pada card produk
                    cardSewa.pictureBox1.Click += (sender, e) =>
                    {
                        // Ketika card produk diklik, buka PenjualanDetailProduk
                        //PopupPelanggan popup = new PopupPelanggan();
                        //popup.Show();
                        //this.Hide();  // Menyembunyikan form saat membuka form baru
                        //PersewaanDetail sewadetail = new PersewaanDetail(produk.Id_Produk);
                        //sewadetail.Show();
                        //this.Hide();
                        // Simpan Id_Produk ke sesi
                        SessionData.SelectedProdukId = produk.Id_Produk;

                        // Buka form PopupPelanggan
                        PopupPelanggan popupPelanggan = new PopupPelanggan();
                        popupPelanggan.Show();
                        this.Hide();
                    };

                    //mbahkan card ke dalam FlowLayoutPanel
                    flowLayoutPanel2.Controls.Add(cardSewa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal tes produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
