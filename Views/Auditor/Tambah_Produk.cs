using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TaniAttire.App.Controllers;
using TaniAttire.App.Models;

namespace TaniAttire.Views.Auditor
{
    public partial class Tambah_Produk : Form
    {
        private ProdukControllers _controller;
        private ukuranControllers _ukuranController;

        public Tambah_Produk()
        {
            InitializeComponent();
            _controller = new ProdukControllers();
            _ukuranController = new ukuranControllers();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNamaProduk.Text))
                {
                    MessageBox.Show("Nama produk harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (pictureBoxGambar.ImageLocation == null)
                {
                    MessageBox.Show("Pilih gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedUkuran = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedUkuran))
                {
                    MessageBox.Show("Pilih ukuran produk.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox2.Text, out int stokSewa) || !int.TryParse(textBox3.Text, out int stokJual) ||
                    !decimal.TryParse(textBox4.Text, out decimal hargaSewa) || !decimal.TryParse(textBox5.Text, out decimal hargaJual) ||
                    !decimal.TryParse(textBox1.Text, out decimal dendaPerHari))
                {
                    MessageBox.Show("Masukkan nilai yang valid untuk stok, harga, dan denda.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tentukan folder Resources dengan path absolut
                string targetDir = @"E:\pbo\PBO_05\PBO_05\Resources";

                // Periksa apakah folder Resources ada, jika belum buat folder
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                // Ambil nama file gambar
                string fileName = Path.GetFileName(pictureBoxGambar.ImageLocation);
                string targetPath = Path.Combine(targetDir, fileName);

                // Salin gambar ke folder Resources jika belum ada
                if (!File.Exists(targetPath))
                {
                    File.Copy(pictureBoxGambar.ImageLocation, targetPath);
                }

                // Ambil ID ukuran dari database
                int idUkuran = _ukuranController.GetAllukuran()
                    .FirstOrDefault(u => u.Nilai_Ukuran == selectedUkuran)?.Id_Ukuran ?? 0;

                if (idUkuran == 0)
                {
                    MessageBox.Show("Ukuran tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Buat objek produk dan detail stok
                Produk produk = new Produk
                {
                    Nama_Produk = textBoxNamaProduk.Text,
                    Foto_Produk = targetPath, // Path gambar di Resources
                    Denda_Perhari = dendaPerHari
                };

                Detail_Stok detailStok = new Detail_Stok
                {
                    Stok_Sewa = stokSewa,
                    Stok_Jual = stokJual,
                    Harga_Sewa = hargaSewa,
                    Harga_Jual = hargaJual
                };

                // Simpan produk dan detail stok
                _controller.AddProduk(produk, pictureBoxGambar.ImageLocation, idUkuran, detailStok);

                MessageBox.Show("Produk berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form setelah berhasil
                pictureBoxGambar.Image = null;
                textBoxNamaProduk.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.SelectedIndex = -1;

                // Tampilkan form manajemen produk
                Mnj_Produk manajemenproduk = new Mnj_Produk();
                manajemenproduk.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxGambar.ImageLocation = openFileDialog.FileName;
                    pictureBoxGambar.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mnj_Karyawan manajemenkaryawan = new Mnj_Karyawan();
            manajemenkaryawan.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mnj_Produk manajemenproduk = new Mnj_Produk();
            manajemenproduk.Show();
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

        private void Tambah_Produk_Load(object sender, EventArgs e)
        {
            LoadUkuranComboBox();
        }

        private void LoadUkuranComboBox()
        {
            try
            {
                
                List<string> nilaiUkuranList = _ukuranController.GetNilaiUkuran();

               
                comboBox1.DataSource = nilaiUkuranList;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data ukuran: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBeranda_Click(object sender, EventArgs e)
        {
            AuditorDashboard auditorDashboard = new AuditorDashboard();
            auditorDashboard.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Ukuran form_Ukuran = new Form_Ukuran();
            form_Ukuran.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Penjualan penjualan = new Penjualan();
            penjualan.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Persewaan persewaan = new Persewaan();
            persewaan.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
