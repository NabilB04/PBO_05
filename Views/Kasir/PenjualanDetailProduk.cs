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
using TaniAttire.Views.Kasir.Card;

namespace TaniAttire.Views.Kasir
{
    public partial class PenjualanDetailProduk : Form
    {
        private int idProduk;
        private ProdukControllers _produkController;
        public PenjualanDetailProduk(int Id_Produk)
        {
            InitializeComponent();
            this.idProduk = Id_Produk;
            _produkController = new ProdukControllers();
        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            try
            {
                List<Detail_Produk> produkList = _produkController.GetDetailProdukByProdukId(idProduk);

                // Iterasi setiap produk untuk ditampilkan
                foreach (var produk in produkList)
                {
                    // Buat instance dari CardProduk
                    CardDetailProduk CardDetailProduk = new CardDetailProduk
                    {
                        Margin = new Padding(3),
                    };

                    // Set data produk ke dalam card
                    CardDetailProduk.label1.Text = produk.Nama_Produk;
                    CardDetailProduk.label2.Text = $"Rp {produk.Nilai_Ukuran:N0}";

                    // Set gambar produk jika ada
                    //if (!string.IsNullOrEmpty(produk.Foto_Produk))
                    //{
                    //    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", produk.Foto_Produk);
                    //    if (File.Exists(imagePath))
                    //    {
                    //        CardDetailProduk.pictureBox1.Image = Image.FromFile(imagePath);
                    //    }
                    //}

                    // Tambahkan card ke dalam FlowLayoutPanel
                    flowLayoutPanel2.Controls.Add(CardDetailProduk);
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
