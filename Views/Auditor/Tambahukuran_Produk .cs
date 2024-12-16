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
//            _selectedProduk = produk; // Simpan data produk yang dipilih
//            label7.Text = produk.Nama_Produk; // Menampilkan nama produk di label7
//            textBoxHargaJual.Text = produk.Harga_Jual.ToString(); // Menampilkan harga jual
//            textBoxHargaSewa.Text = produk.Harga_Sewa.ToString(); // Menampilkan harga sewa
//            textBoxDendaPerHari.Text = produk.Denda_Perhari.ToString(); // Menampilkan denda perhari
//            LoadUkuran();
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
//            if (string.IsNullOrEmpty(comboBoxUkuran.Text) ||
//         string.IsNullOrEmpty(textBoxStokJual.Text) ||
//         string.IsNullOrEmpty(textBoxStokSewa.Text))
//            {
//                MessageBox.Show("Harap lengkapi semua field.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            try
//            {
//                Simpan ke database
//               Detail_Stok newStok = new Detail_Stok
//               {
//                   Id_Detail_Produk = selectedProdukId,
//                   Stok_Jual = int.Parse(textBoxStokJual.Text),
//                   Stok_Sewa = int.Parse(textBoxStokSewa.Text),
//                   Harga_Jual = decimal.Parse(textBoxHargaJual.Text),
//                   Harga_Sewa = decimal.Parse(textBoxHargaSewa.Text),
//               };

//                _controller.AddDetailStok(newStok);
//                MessageBox.Show("Data berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void panel1_Paint(object sender, PaintEventArgs e)
//        {

//        }

//        private void Tambahukuran_Produk_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
