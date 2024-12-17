//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using TaniAttire.App.Controllers;
//using TaniAttire.App.Models;

//namespace TaniAttire.Views.Auditor
//{
//    public partial class Tambahukuran_Produk : Form
//    {
//        private ProdukControllers _produkController = new ProdukControllers();
//        private ukuranControllers _ukuranController = new ukuranControllers();
//        private GetProduk _selectedProduk;
//        private int selectedProdukId;


//        public Tambahukuran_Produk(GetProduk produk, Detail_Stok detailStok)
//        {
//            InitializeComponent();
//            _selectedProduk = produk; // Simpan produk yang dipilih
//            label7.Text = produk.Nama_Produk; // Tampilkan nama produk di label7
//            selectedProdukId = produk.Id_Produk; // Simpan ID produk yang dipilih
//            LoadUkuran(); // Load ukuran yang tersedia
//        }
//        private void LoadUkuran()
//        {
//            var ukuranList = _ukuranController.GetAllukuran()
//             .Where(u => u.Status)
//             .Select(u => u.Nilai_Ukuran)
//             .ToList();
//            comboBoxUkuran.DataSource = ukuranList;
//        }
//        private void LoadProdukToForm(GetProduk produk)
//        {
//            selectedProdukId = produk.Id_Produk;
//            labelNamaProduk.Text = produk.Nama_Produk;
//            textBoxHargaJual.Text = produk.Harga_Jual.ToString();
//            textBoxHargaSewa.Text = produk.Harga_Sewa.ToString();
//            textBoxDendaPerHari.Text = produk.Denda_Perhari.ToString();
//        }

//        private void label8_Click(object sender, EventArgs e)
//        {

//        }


//        private void button9_Click(object sender, EventArgs e)
//        {
//            Mnj_Produk manajemenproduk = new Mnj_Produk();
//            manajemenproduk.Show();
//            this.Close();
//        }
//        private void pictureBoxGambar_Click(object sender, EventArgs e)
//        {

//        }

//        private void label7_Click(object sender, EventArgs e)
//        {

//        }

//        private void comboBoxUkuran_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }

//        private void textBoxStokJual_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void textBoxStokSewa_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void button8_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(comboBoxUkuran.Text) ||
//         string.IsNullOrWhiteSpace(textBoxStokJual.Text) ||
//         string.IsNullOrWhiteSpace(textBoxStokSewa.Text))
//            {
//                MessageBox.Show("Harap lengkapi semua field.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            try
//            {
//                // Ambil Id_Ukuran berdasarkan nilai ukuran yang dipilih
//                var ukuran = _ukuranController.GetUkuranByName(comboBoxUkuran.Text);

//                if (ukuran == null)
//                {
//                    MessageBox.Show("Ukuran tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                // Buat record Detail_Stok
//                var newStok = new Detail_Stok
//                {
//                    Id_Detail_Produk = GetDetailProdukId(_selectedProduk.Id_Produk, ukuran.Id_Ukuran),
//                    Stok_Jual = int.Parse(textBoxStokJual.Text),
//                    Stok_Sewa = int.Parse(textBoxStokSewa.Text)
//                };

//                // Simpan ke database
//                _produkController.AddDetailStok(newStok);
//                MessageBox.Show("Stok berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                // Reset form
//                ResetForm();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }

//        private void panel1_Paint(object sender, PaintEventArgs e)
//        {

//        }

//        private void Tambahukuran_Produk_Load(object sender, EventArgs e)
//        {

//        }

//        private void button2_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}
