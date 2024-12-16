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
using TaniAttire.Views.Auditor;
using static TaniAttire.Login;
using static TaniAttire.Views.Kasir.DataPelanggan;

namespace TaniAttire.Views.Kasir.Card
{
    public partial class CardSewadetail : UserControl
    {
        private TransaksiSewaControllers transaksiController;
        public List<Detail_Produk> ProdukList { get; set; } = new List<Detail_Produk>();
        public CardSewadetail()
        {
            InitializeComponent();
            transaksiController = new TransaksiSewaControllers();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxUkuran_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxJumlah_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PenjualanProduk penjualanproduk = new PenjualanProduk();
            penjualanproduk.Show();

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input dari pengguna
                if (comboBoxUkuran.SelectedItem == null)
                {
                    MessageBox.Show("Harap lengkapi tanggal kembali dan ukuran produk.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime tanggal_kembali = dateTimePicker1.Value;
                string ukuran = comboBoxUkuran.SelectedItem.ToString();

                // Ambil ID Detail Stok dari produk list
                int idDetailStok = GetSelectedDetailStok(ukuran);
                MessageBox.Show(idDetailStok.ToString());

                if (idDetailStok == 0)
                {
                    MessageBox.Show("Detail stok tidak ditemukan untuk ukuran yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int id_pelanggan = PelangganSession.SelectedPelangganId ?? 0;
                if (id_pelanggan == 0)
                {
                    MessageBox.Show("Pengguna tidak valid. Silakan login kembali.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int idUsers = SessionData.LoggedInUserId; // Pastikan SessionData diakses dengan benar
                if (idUsers == 0)
                {
                    MessageBox.Show("Pengguna tidak valid. Silakan login kembali.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Buat objek TransaksiJualDetail
                var transaksiSewaDetail = new TransaksiSewaDetail
                {
                    Id_Detail_Transaksi = idDetailStok,
                    Tanggal_Kembali = tanggal_kembali,
                    Tanggal_Transaksi = DateTime.Now,
                    Id_Users = idUsers,
                    Id_Pelanggan = id_pelanggan
                };

                // Panggil fungsi AddTransaksiJual dari controller
                transaksiController.AddTransaksiSewa(transaksiSewaDetail);
                MessageBox.Show("Transaksi berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();

                //Navigasi kembali ke form Jual
               var persewaanproduk = new PersewaanProduk();
                persewaanproduk.Show();

                Form parentForm = this.FindForm();
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedDetailStok(string ukuran)
        {
            // Cari ID Detail_Stok berdasarkan ukuran
            var produk = ProdukList.FirstOrDefault(p => p.Nilai_Ukuran == ukuran);
            return produk?.Id_Detail_Stok ?? 0;
        }

        private void ResetForm()
        {

            comboBoxUkuran.SelectedIndex = -1;
        }
    }
}
