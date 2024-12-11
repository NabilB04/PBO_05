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

namespace TaniAttire.Views.Kasir
{
    public partial class PenjualanDetailProduk : Form
    {
        private ProdukControllers _produkController;
        public PenjualanDetailProduk()
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
                    cardProduk.label1.Text = produk.Nama_Produk;
                    cardProduk.label2.Text = $"Rp {produk.Harga_Jual:N0}";

                    // Set gambar produk jika ada
                    if (!string.IsNullOrEmpty(produk.Foto_Produk))
                    {
                        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", produk.Foto_Produk);
                        if (File.Exists(imagePath))
                        {
                            cardProduk.pictureBox1.Image = Image.FromFile(imagePath);
                        }
                    }

                    // Tambahkan card ke dalam FlowLayoutPanel
                    flowLayoutPanel2.Controls.Add(cardProduk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
