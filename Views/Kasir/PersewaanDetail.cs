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
    public partial class PersewaanDetail : Form
    {
        private int idProduk;
        private ProdukControllers _produkController;
        public PersewaanDetail(int Id_Produk)
        {
            InitializeComponent();
            this.idProduk = Id_Produk;
            _produkController = new ProdukControllers();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }

        private void PersewaanDetail_Load(object sender, EventArgs e)
        {
            try
            {
                List<Detail_Produk> produkList = _produkController.GetDetailProdukByProdukId(idProduk);

                // Grupkan produk berdasarkan Id_Produk untuk menghindari duplikasi kartu
                var groupedProducts = produkList
                    .GroupBy(p => p.Id_Produk)
                    .Select(group => new
                    {
                        Produk = group.First(),
                        UkuranList = group.Select(g => g.Nilai_Ukuran).ToList()
                    });

                foreach (var groupedProduct in groupedProducts)
                {
                    CardSewadetail cardSewa = new CardSewadetail
                    {
                        Margin = new Padding(3),
                        ProdukList = produkList // Semua produk, untuk mencari stok nanti
                    };

                    // Tambahkan ukuran ke comboBox
                    foreach (var ukuran in groupedProduct.UkuranList)
                    {
                        cardSewa.comboBoxUkuran.Items.Add(ukuran);
                    }

                    // Atur ukuran default
                    if (cardSewa.comboBoxUkuran.Items.Count > 0)
                    {
                        cardSewa.comboBoxUkuran.SelectedIndex = 0;

                        // Dapatkan stok default
                        string defaultUkuran = cardSewa.comboBoxUkuran.SelectedItem.ToString();
                        var stokDefault = produkList
                            .Where(p => p.Nilai_Ukuran == defaultUkuran)
                            .Select(p => p.Stok_Sewa)
                            .FirstOrDefault();

                        cardSewa.label4.Text = $"Stok Sewa: {stokDefault}";
                        cardSewa.dateTimePicker1.Value = DateTime.Now.AddDays(1); 
                    }

                    // Tambahkan event handler untuk comboBoxUkuran
                    cardSewa.comboBoxUkuran.SelectedIndexChanged += (s, ev) =>
                    {
                        if (cardSewa.comboBoxUkuran.SelectedItem != null)
                        {
                            string selectedUkuran = cardSewa.comboBoxUkuran.SelectedItem.ToString();

                            // Cari stok berdasarkan ukuran yang dipilih
                            var stok = produkList
                                .Where(p => p.Nilai_Ukuran == selectedUkuran)
                                .Select(p => p.Stok_Sewa)
                                .FirstOrDefault();

                            // Update label
                            cardSewa.label4.Text = $"Stok Sewa: {stok}";
                        }
                        else
                        {
                            // Handle kondisi jika tidak ada item yang dipilih
                            cardSewa.label4.Text = "Silakan pilih ukuran.";
                        }
                    };

                    // Tambahkan kartu ke flowLayoutPanel
                    flowLayoutPanel2.Controls.Add(cardSewa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat produk: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
