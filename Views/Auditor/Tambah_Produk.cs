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
        private produk1Controllers _controller;

        public Tambah_Produk()
        {
            InitializeComponent();
            _controller = new produk1Controllers();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input nama produk
                if (string.IsNullOrWhiteSpace(textBoxNamaProduk.Text))
                {
                    MessageBox.Show("Nama produk harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi gambar
                if (pictureBoxGambar.ImageLocation == null)
                {
                    MessageBox.Show("Pilih gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Salin gambar ke folder lokal (jika belum ada)
                string targetDir = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                string fileName = Path.GetFileName(pictureBoxGambar.ImageLocation);
                string targetPath = Path.Combine(targetDir, fileName);

                if (!File.Exists(targetPath))
                {
                    File.Copy(pictureBoxGambar.ImageLocation, targetPath);
                }

                // Simpan data produk
                Produk produk = new Produk
                {
                    Nama_Produk = textBoxNamaProduk.Text,
                    Status = true,
                    Foto_Produk = targetPath
                };

                _controller.AddProduk(produk);

                MessageBox.Show("Produk berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBoxGambar.Image = null;
                textBoxNamaProduk.Clear();
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

        }
    }
}
