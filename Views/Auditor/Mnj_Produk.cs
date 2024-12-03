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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
        }
        private void LoadDataProduk()
        {
            try
            {
                List<GetProduk> produkList = _controller.GetTotalProduk();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = produkList;
                dataGridView1.DataSource = bindingSource;

                if (dataGridView1.Columns.Contains("Delete"))
                {
                    dataGridView1.Columns["Delete"].DisplayIndex = dataGridView1.Columns.Count - 1;
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
            MessageBox.Show("Anda telah Logout");
            Login login = new Login();
            login.Show();
            this.Hide();
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

        }
    }
}
