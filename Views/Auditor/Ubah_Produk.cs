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

namespace TaniAttire.Views.Auditor
{
    public partial class Ubah_Produk : Form
    {
        private readonly ProdukControllers _controller = new ProdukControllers();
        private readonly ukuranControllers _ukuranController = new ukuranControllers();
        private GetProduk _produk;
        private Detail_Stok _detailStok;
        private string _selectedImagePath;
        private string _currentImagePath;
        public List<Ukuran> UkuranList { get; set; }
        public Detail_Stok DetailStok { get; set; }
        public GetProduk Produk { get; set; }



        public Ubah_Produk(GetProduk produk, Detail_Stok detailStok)
        {
            InitializeComponent();
            _produk = produk;
            _detailStok = detailStok;

            LoadUkuran();
            LoadProdukToForm();
        }
        private void LoadUkuran()
        {
            var ukuranList = _ukuranController.GetAllukuran()
                                .Where(u => u.Status)
                                .Select(u => u.Nilai_Ukuran)
                                .ToList();
            comboBoxUkuran.DataSource = ukuranList;
        }
        private void LoadProdukToForm()
        {
            if (_produk != null)
            {
                textBoxNamaProduk.Text = _produk.Nama_Produk;
                textBoxDendaPerHari.Text = _produk.Denda_Perhari.ToString();

                if (!string.IsNullOrEmpty(_produk.Foto_Produk))
                {
                    _currentImagePath = Path.Combine(Application.StartupPath, "uploads", _produk.Foto_Produk);
                    pictureBoxGambar.ImageLocation = _currentImagePath;
                }

                if (_detailStok != null)
                {
                    textBoxStokJual.Text = _detailStok.Stok_Jual.ToString();
                    textBoxStokSewa.Text = _detailStok.Stok_Sewa.ToString();
                    textBoxHargaJual.Text = _detailStok.Harga_Jual.ToString();
                    textBoxHargaSewa.Text = _detailStok.Harga_Sewa.ToString();
                }

                comboBoxUkuran.SelectedItem = _produk.Nilai_Ukuran;
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input
                if (string.IsNullOrWhiteSpace(textBoxNamaProduk.Text) ||
                    comboBoxUkuran.SelectedItem == null ||
                    !int.TryParse(textBoxStokJual.Text, out int stokJual) ||
                    !int.TryParse(textBoxStokSewa.Text, out int stokSewa) ||
                    !decimal.TryParse(textBoxHargaJual.Text, out decimal hargaJual) ||
                    !decimal.TryParse(textBoxHargaSewa.Text, out decimal hargaSewa) ||
                    !decimal.TryParse(textBoxDendaPerHari.Text, out decimal dendaPerHari))
                {
                    MessageBox.Show("Mohon isi semua data dengan benar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Membuat objek Produk baru untuk memperbarui data
                Produk produkToUpdate = new Produk
                {
                    Id_Produk = _produk.Id_Produk,  // Menggunakan ID yang sama dari GetProduk
                    Nama_Produk = textBoxNamaProduk.Text,
                    Denda_Perhari = dendaPerHari,
                    Foto_Produk = _produk.Foto_Produk
                };

                // Update data detail stok
                _detailStok.Stok_Jual = stokJual;
                _detailStok.Stok_Sewa = stokSewa;
                _detailStok.Harga_Jual = hargaJual;
                _detailStok.Harga_Sewa = hargaSewa;

                // Mendapatkan ukuran yang dipilih
                string ukuranTerpilih = comboBoxUkuran.SelectedItem.ToString();
                int idUkuran = _ukuranController.GetAllukuran()
                                        .FirstOrDefault(u => u.Nilai_Ukuran == ukuranTerpilih)?.Id_Ukuran ?? 0;

                // Mengelola gambar
                string fotoProduk = produkToUpdate.Foto_Produk;

                if (!string.IsNullOrEmpty(_selectedImagePath))
                {
                    // Jika ada gambar baru, salin ke folder uploads
                    string uploadsFolder = Path.Combine(Application.StartupPath, "Resources");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    fotoProduk = $"{Guid.NewGuid()}_{Path.GetFileName(_selectedImagePath)}";
                    string destinationPath = Path.Combine(uploadsFolder, fotoProduk);
                    File.Copy(_selectedImagePath, destinationPath, true);

                    // Hapus gambar lama jika ada
                    if (!string.IsNullOrEmpty(_currentImagePath) && File.Exists(_currentImagePath))
                    {
                        File.Delete(_currentImagePath);
                    }
                }

                // Simpan perubahan ke database
                _controller.UpdateProduk(produkToUpdate, fotoProduk, idUkuran, _detailStok);

                MessageBox.Show("Produk berhasil diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mnj_Produk manajemenproduk = new Mnj_Produk();
            manajemenproduk.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = openFileDialog.FileName;
                    pictureBoxGambar.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxGambar.ImageLocation = _selectedImagePath;
                }
            }
        }

        private void pictureBoxGambar_Click(object sender, EventArgs e)
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
    }
}
