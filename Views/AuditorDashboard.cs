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

namespace TaniAttire
{
    public partial class AuditorDashboard : Form
    {
        private ukuranControllers _controller;

        public AuditorDashboard()
        {
            InitializeComponent();
            _controller = new ukuranControllers();
            LoadDataUkuran();
            SetupDataGridView();

        }

        private void SetupDataGridView()
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

        private void LoadDataUkuran()
        {
            try
            {
                ukuranControllers controller = new ukuranControllers();
                var ukuranList = controller.GetAllukuran(); // Data hanya dengan Status = true
                dataGridView1.DataSource = ukuranList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}");
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Home clicked!");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings clicked!");
        }
        private void Dashboard_Load_1(object sender, EventArgs e)
        {
        }

        private void buttonLaporan_Click(object sender, EventArgs e)
        {

        }

        private void buttonProduk_Click(object sender, EventArgs e)
        {

        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            // Mengubah warna saat hover
            Button button = sender as Button;
            button.BackColor = Color.Red;  // Ganti dengan warna yang diinginkan saat hover
            button.ForeColor = Color.White;  // Ganti dengan warna teks saat hover
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            // Mengubah warna kembali saat mouse keluar
            Button button = sender as Button;
            button.BackColor = Color.White;  // Ganti dengan warna aslinya
            button.ForeColor = Color.Red;  // Ganti dengan warna teks aslinya
        }
        private void button_MouseEnter1(object sender, EventArgs e)
        {
            // Mengubah warna saat hover
            Button button = sender as Button;
            button.BackColor = Color.Green;  // Ganti dengan warna yang diinginkan saat hover
            button.ForeColor = Color.White;  // Ganti dengan warna teks saat hover
        }

        private void button_MouseLeave1(object sender, EventArgs e)
        {
            // Mengubah warna kembali saat mouse keluar
            Button button = sender as Button;
            button.BackColor = Color.White;  // Ganti dengan warna aslinya
            button.ForeColor = Color.Green;  // Ganti dengan warna teks aslinya
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
        private void buttonBeranda_Click(object sender, EventArgs e)
        {

        }
    }
}