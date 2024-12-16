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

                // Grupkan produk berdasarkan Id_Produk
                var groupedProducts = produkList
                    .GroupBy(p => p.Id_Produk)
                    .Select(group => new
                    {
                        Produk = group.First(), // Ambil satu produk sebagai representasi
                        UkuranList = group.Select(p => p.Nilai_Ukuran).ToList()
                    });

                foreach (var groupedProduct in groupedProducts)
                {
                    CardDetailProduk cardDetailProduk = new CardDetailProduk
                    {
                        Margin = new Padding(3),
                        ProdukList = produkList // Simpan semua daftar detail produk untuk pencarian stok
                    };

                    // Tambahkan semua ukuran terkait ke comboBox
                    foreach (var ukuran in groupedProduct.UkuranList)
                    {
                        cardDetailProduk.comboBoxUkuran.Items.Add(ukuran);
                    }

                    // Atur ukuran default jika ada
                    if (cardDetailProduk.comboBoxUkuran.Items.Count > 0)
                    {
                        cardDetailProduk.comboBoxUkuran.SelectedIndex = 0;

                        string defaultUkuran = cardDetailProduk.comboBoxUkuran.SelectedItem.ToString();
                        var stokDefault = produkList
                            .Where(p => p.Nilai_Ukuran == defaultUkuran)
                            .Select(p => p.Stok_Jual)
                            .FirstOrDefault();

                        cardDetailProduk.label4.Text = $"Stok: {stokDefault}";
                    }

                    // Tambahkan event handler untuk perubahan ukuran
                    cardDetailProduk.comboBoxUkuran.SelectedIndexChanged += (s, ev) =>
                    {
                        if (cardDetailProduk.comboBoxUkuran.SelectedItem != null)
                        {
                            string selectedUkuran = cardDetailProduk.comboBoxUkuran.SelectedItem.ToString();

                            // Cari stok berdasarkan ukuran yang dipilih
                            var stok = produkList
                                .Where(p => p.Nilai_Ukuran == selectedUkuran)
                                .Select(p => p.Stok_Jual)
                                .FirstOrDefault();

                            // Update label
                            cardDetailProduk.label4.Text = $"Stok Jual: {stok}";
                        }
                        else
                        {
                            // Handle kondisi jika tidak ada item yang dipilih
                            cardDetailProduk.label4.Text = "Silakan pilih ukuran.";
                        }
                    };

                    // Tambahkan kartu ke flowLayoutPanel
                    flowLayoutPanel2.Controls.Add(cardDetailProduk);
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

        private void button6_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
