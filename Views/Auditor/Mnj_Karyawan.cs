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
            // Tambahkan kolom Update jika belum ada
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

            // Tambahkan kolom Delete jika belum ada
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

                // Pastikan posisi kolom Update dan Delete
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

                    LoadDataKaryawan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan saat menghapus data: {ex.Message}");
                }
            }
        }
    }
}
