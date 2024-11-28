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

namespace TaniAttire.Views.Auditor
{
    public partial class Form_Ukuran : Form
    {
        private ukuranControllers _controller;
        public Form_Ukuran()
        {
            InitializeComponent();
            _controller = new ukuranControllers();
            SetupDataGridView();
            LoadDataUkuran();
        }
        private void SetupDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
        private void LoadDataUkuran()
        {
            try
            {
                ukuranControllers controller = new ukuranControllers();
                var ukuranList = controller.GetAllukuran();
                dataGridView1.DataSource = ukuranList;

                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                if (dataGridView1.Columns.Contains("Delete"))
                {
                    dataGridView1.Columns["Delete"].DisplayIndex = dataGridView1.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mnj_Karyawan manajemenkaryawan = new Mnj_Karyawan();
            manajemenkaryawan.Show();
            this.Hide();
        }

        private void buttonBeranda_Click(object sender, EventArgs e)
        {
            AuditorDashboard auditorDashboard = new AuditorDashboard();
            auditorDashboard.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mnj_Produk manajemenproduk = new Mnj_Produk();
            manajemenproduk.Show();
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
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                try
                {
                    int Id_Ukuran = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Ukuran"].Value);
                    ukuranControllers.DeleteUkuran(Id_Ukuran);
                    MessageBox.Show("Data berhasil dihapus.");

                    LoadDataUkuran();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat menghapus data: {ex.Message}");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Form_Ukuran_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}

