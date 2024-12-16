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
using TaniAttire.Views.Auditor;
using static TaniAttire.Views.Kasir.PersewaanProduk;

namespace TaniAttire.Views.Kasir
{
    public partial class DataPelanggan : Form
    {
        private PelangganControllers _controller;

        public DataPelanggan()
        {
            InitializeComponent();
            _controller = new PelangganControllers();
            SetupDataGridView();
            LoadDataKaryawan();
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (!dataGridView1.Columns.Contains("Pilih"))
            {
                var PilihButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Aksi",
                    Text = "Pilih",
                    UseColumnTextForButtonValue = true,
                    Name = "Pilih"
                };
                dataGridView1.Columns.Add(PilihButtonColumn);
            }

        }

        private void LoadDataKaryawan()
        {
            try
            {
                PelangganControllers controller = new PelangganControllers();
                var pelangganList = controller.GetAllpelanggan();
                dataGridView1.DataSource = pelangganList;

                if (dataGridView1.Columns.Contains("Pilih"))
                {
                    dataGridView1.Columns["Pilih"].DisplayIndex = dataGridView1.Columns.Count - 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}");
            }
        }



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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Pilih"].Index)
            {
                try
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["Id_Pelanggan"].Value != null)
                    {
                        int idPelanggan = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Pelanggan"].Value);

                        // Simpan Id_Pelanggan ke sesi
                        PelangganSession.SelectedPelangganId = idPelanggan;

                        MessageBox.Show($"Pelanggan dengan ID {idPelanggan} berhasil dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (PelangganSession.SelectedPelangganId != null)
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
                    else
                    {
                        MessageBox.Show("Data pelanggan tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("tes");

        }




        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxSearch.Text = string.Empty;
                LoadDataKaryawan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat ulang data: {ex.Message}");
            }
        }
        public static class PelangganSession
        {
            public static int? SelectedPelangganId { get; set; }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBoxSearch.Text;
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    var pelangganList = _controller.SearchPelanggan(keyword);
                    dataGridView1.DataSource = pelangganList;

                    if (pelangganList.Count == 0)
                    {
                        MessageBox.Show("Data tidak ditemukan.");
                    }
                }
                else
                {
                    MessageBox.Show("Masukkan kata kunci untuk mencari.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat pencarian: {ex.Message}");
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Pilih"].Index)
            {
                try
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["Id_Pelanggan"].Value != null)
                    {
                        int idPelanggan = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Pelanggan"].Value);

                        PelangganSession.SelectedPelangganId = idPelanggan;

                        if (PelangganSession.SelectedPelangganId != null)
                        {
                            PersewaanDetail persewaanDetail = new PersewaanDetail(SessionData.SelectedProdukId.Value);
                            persewaanDetail.Show();
                            this.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Produk belum dipilih. Silakan pilih produk terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data pelanggan tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
    }

}
