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
using static TaniAttire.Views.Kasir.DataPelanggan;
using static TaniAttire.Views.Kasir.PersewaanProduk;

namespace TaniAttire.Views.Kasir
{
    public partial class FormTbhPelanggan : Form
    {
        public FormTbhPelanggan()
        {
            InitializeComponent();
        }
        public event EventHandler OnDataUpdated;
        private void button4_Click(object sender, EventArgs e)
        {
            PenjualanProduk penjualanProduk = new PenjualanProduk();
            penjualanProduk.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersewaanProduk persewaanProduk = new PersewaanProduk();
            persewaanProduk.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TrackPersewaan trackPersewaan = new TrackPersewaan();
            trackPersewaan.Show();
            this.Hide();
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

        private void button8_Click(object sender, EventArgs e)
        {
            PersewaanProduk persewaanProduk = new PersewaanProduk();
            persewaanProduk.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text.Trim();
            string nomor_telepon = textBox2.Text.Trim();
            string alamat = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(nomor_telepon) || string.IsNullOrWhiteSpace(alamat))
            {
                MessageBox.Show("Semua field harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Pelanggan newPelanggan = new Pelanggan
            {
                Nama_Pelanggan = nama,
                No_Telpon = nomor_telepon,
                Alamat = alamat,
            };

            try
            {
                PelangganControllers controller = new PelangganControllers();
                int newPelangganId = controller.Addpelanggan(newPelanggan);

                // Simpan Id_Pelanggan ke sesi
                PelangganSession.SelectedPelangganId = newPelangganId;

                MessageBox.Show("Pelanggan berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (SessionData.SelectedProdukId.HasValue)
                {
                    // Arahkan ke PersewaanDetail
                    PersewaanDetail persewaanDetail = new PersewaanDetail(SessionData.SelectedProdukId.Value);
                    persewaanDetail.Show();
                    this.Close(); // Tutup form PopupPelanggan
                }
                else
                {
                    MessageBox.Show("Produk belum dipilih. Silakan pilih produk terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
