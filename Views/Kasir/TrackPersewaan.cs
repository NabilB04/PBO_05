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

namespace TaniAttire.Views.Kasir
{
    public partial class TrackPersewaan : Form
    {
        private TransaksiSewaControllers _controller;
        public TrackPersewaan()
        {
            InitializeComponent();
            _controller = new TransaksiSewaControllers();
        }

        private void button1_Click(object sender, EventArgs e)
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ubah" && e.RowIndex >= 0)
            {
                int idTransaksi = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Detail_Transaksi"].Value);

                TrackPersewaanPengembalian pengembalianForm = new TrackPersewaanPengembalian(idTransaksi);
                pengembalianForm.ShowDialog();

                LoadData();
            }

        }

        private void TrackPersewaan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                List<TransaksiSewaDetail> listTransaksi = _controller.GetAllTransaksiSewa()
                    .FindAll(t => t.Status_Pengembalian == false); 

                dataGridView1.DataSource = listTransaksi;

                // Menambahkan tombol "Ubah" di grid jika belum ada
                if (dataGridView1.Columns["Ubah"] == null)
                {
                    DataGridViewButtonColumn btnUbah = new DataGridViewButtonColumn
                    {
                        Name = "Ubah",
                        Text = "Ubah",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(btnUbah);
                }

                // Menyembunyikan kolom yang tidak diperlukan
                dataGridView1.Columns["Id_Detail_Transaksi"].Visible = false;
                dataGridView1.Columns["Status_Pengembalian"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
