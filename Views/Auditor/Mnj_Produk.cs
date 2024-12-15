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
    public partial class Mnj_Produk : Form
    {
        private ProdukControllers _controller;
        public Mnj_Produk()
        {
            InitializeComponent();
            _controller = new ProdukControllers();
            SetupDataGridView();
        }
        private void SetupDataGridView()
        {
            if (!dataGridView1.Columns.Contains("Update"))
            {
                var updateButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Aksi",
                    Text = "Update",
                    UseColumnTextForButtonValue = true,
                    Name = "Update"
                };
                dataGridView1.Columns.Add(updateButtonColumn);
            }
            if (!dataGridView1.Columns.Contains("Delete"))
            {
                var deleteButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Aksi",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    Name = "Delete"
                };
                dataGridView1.Columns.Add(deleteButtonColumn);
            }

            if (!dataGridView1.Columns.Contains("Tambah Ukuran"))
            {
                var tambahukuranButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Aksi",
                    Text = "Tambah Ukuran",
                    UseColumnTextForButtonValue = true,
                    Name = "Tambah Ukuran"
                };
                dataGridView1.Columns.Add(tambahukuranButtonColumn);
            }
        }
        private void LoadDataProduk()
        {
            try
            {
                List<GetProduk> produkList = _controller.GetTotalProduk();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = produkList;
                dataGridView1.DataSource = bindingSource;

                if (dataGridView1.Columns.Contains("Update"))
                {
                    dataGridView1.Columns["Update"].DisplayIndex = dataGridView1.Columns.Count - 1;
                }

                if (dataGridView1.Columns.Contains("Delete"))
                {
                    dataGridView1.Columns["Delete"].DisplayIndex = dataGridView1.Columns.Count - 1;
                }

                if (dataGridView1.Columns.Contains("Tambah Ukuran"))
                {
                    dataGridView1.Columns["Tambah Ukuran"].DisplayIndex = dataGridView1.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Mnj_Produk_Load(object sender, EventArgs e)
        {
            LoadDataProduk();
        }

        private void buttonBeranda_Click(object sender, EventArgs e)
        {
            AuditorDashboard auditorDashboard = new AuditorDashboard();
            auditorDashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mnj_Karyawan manajemenkaryawan = new Mnj_Karyawan();
            manajemenkaryawan.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Tambah_Produk tambahproduk = new Tambah_Produk();
            tambahproduk.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan indeks baris dan kolom valid
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (columnName == "Update")
                {
                    var selectedProduk = (GetProduk)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                    if (selectedProduk != null)
                    {
                        // Ambil detail stok untuk produk yang dipilih
                        Detail_Stok detailStok = _controller.GetDetailStokByProdukId(selectedProduk.Id_Produk);

                        if (detailStok != null)
                        {
                            // Panggil form Ubah_Produk menggunakan constructor yang sudah benar
                            Ubah_Produk ubahProdukForm = new Ubah_Produk(selectedProduk, detailStok);
                            ubahProdukForm.ShowDialog();

                            // Refresh data setelah update
                            LoadDataProduk();
                        }
                        else
                        {
                            MessageBox.Show("Detail stok tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (columnName == "Delete")
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                    {
                        var selectedProduk = (GetProduk)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                        if (MessageBox.Show("Apakah Anda yakin ingin menghapus produk ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _controller.SoftDeleteProduk(selectedProduk.Id_Produk);
                            MessageBox.Show("Produk berhasil dihapus.");
                            LoadDataProduk();
                        }
                    }
                }

                else if (columnName == "Tambah Ukuran")
                {
                    // Ambil data produk dari baris yang dipilih
                    var selectedProduk = dataGridView1.Rows[e.RowIndex].DataBoundItem as GetProduk;
                    if (selectedProduk != null)
                    {
                        // Ambil detail stok berdasarkan ID produk
                        Detail_Stok detailStok = _controller.GetDetailStokByProdukId(selectedProduk.Id_Produk);

                        if (detailStok != null)
                        {
                            // Panggil form Tambahukuran_Produk menggunakan constructor yang sesuai
                            Tambahukuran_Produk tambahukuranProduk = new Tambahukuran_Produk(selectedProduk, detailStok);
                            tambahukuranProduk.ShowDialog();

                            // Refresh data setelah form ditutup
                            LoadDataProduk();
                        }
                        else
                        {
                            MessageBox.Show("Detail stok tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
