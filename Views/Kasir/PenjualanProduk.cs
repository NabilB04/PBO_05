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
using TaniAttire.Views.Kasir;

namespace TaniAttire
{
    public partial class PenjualanProduk : Form
    {
        private ProdukControllers _produkController;

        public PenjualanProduk()
        {
            InitializeComponent();
            _produkController = new ProdukControllers();
        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Ambil data produk dari database
                List<GetProduk> produkList = _produkController.GetTotalProduk();

                // Iterasi setiap produk untuk ditampilkan
                foreach (var produk in produkList)
                {
                    // Buat instance dari CardProduk
                    CardProduk cardProduk = new CardProduk
                    {
                        Margin = new Padding(3),
                    };

                    // Set data produk ke dalam card
                    cardProduk.label1.Text = $"Nama produk : Rp {produk.Nama_Produk:N0}";
                    cardProduk.label2.Text = $"Harga produk : Rp {produk.Harga_Jual:N0}";

                    // Set gambar produk jika ada
                    if (!string.IsNullOrEmpty(produk.Foto_Produk))
                    {
                        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", produk.Foto_Produk);
                        if (File.Exists(imagePath))
                        {
                            cardProduk.pictureBox1.Image = Image.FromFile(imagePath);
                        }
                    }

                    // Menambahkan event klik pada card produk
                    cardProduk.pictureBox1.Click += (sender, e) =>
                    {
                        // Ketika card produk diklik, buka PenjualanDetailProduk
                        PenjualanDetailProduk detailProdukForm = new PenjualanDetailProduk(produk.Id_Produk);
                        detailProdukForm.Show();
                        this.Hide();  // Menyembunyikan form saat membuka form baru
                    };

                    // Tambahkan card ke dalam FlowLayoutPanel
                    flowLayoutPanel2.Controls.Add(cardProduk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal tes produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormJual formJual = new FormJual();
            formJual.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersewaanProduk persewaanProduk = new PersewaanProduk();
            persewaanProduk.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TrackPersewaan trackPersewaan = new TrackPersewaan();
            trackPersewaan.Show();
            Close();
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

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
