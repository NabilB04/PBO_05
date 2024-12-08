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
    public partial class Mnj_Karyawan : Form
    {
        private usersControllers _controller;
        public Mnj_Karyawan()
        {
            InitializeComponent();
            _controller = new usersControllers();
            SetupDataGridView();
            LoadDataKaryawan();
        }
        private void SetupDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
        }
        private void LoadDataKaryawan()
        {
            try
            {
                usersControllers controller = new usersControllers();
                var usersList = controller.GetAllusers();
                dataGridView1.DataSource = usersList;

                if (dataGridView1.Columns.Contains("Update"))
                {
                    dataGridView1.Columns["Update"].DisplayIndex = dataGridView1.Columns.Count - 1;
                }

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                try
                {
                    int Id_Users = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Users"].Value);
                    usersControllers.DeleteKaryawan(Id_Users);
                    MessageBox.Show("Data berhasil dihapus.");

                    LoadDataKaryawan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat menghapus data: {ex.Message}");
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["Update"].Index)
            {
                try
                {
                    int Id_Users = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Users"].Value);
                    Ubah_Karyawan ubahKaryawan = new Ubah_Karyawan(Id_Users);
                    ubahKaryawan.Show();
                    this.Close();
                    LoadDataKaryawan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat membuka form update");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Tambah_Karyawan tambah_Karyawan = new Tambah_Karyawan();
            tambah_Karyawan.Show();

            tambah_Karyawan.OnDataUpdated += (s, args) =>
            {
                LoadDataKaryawan();
            };

        }

        private void Mnj_Karyawan_Load(object sender, EventArgs e)
        {

        }
    }
}
