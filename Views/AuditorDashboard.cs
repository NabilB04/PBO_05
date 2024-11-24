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
        private usersControllers _controller;

        public AuditorDashboard()
        {
            InitializeComponent();
            _controller = new usersControllers();
        }

        private void LoadDataKaryawan()
        {
            try
            {
                // Ambil data dari controller
                List<Users> usersList = _controller.GetAllusers();

                // Periksa apakah data kosong
                if (usersList == null || usersList.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk ditampilkan.");
                }
                else
                {
                    // Tampilkan data pada DataGridView
                    dataGridView1.DataSource = null; // Reset data
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = usersList;
                }
            DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Update",
                    HeaderText = "Update",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
            dataGridView1.Columns.Add(updateButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(deleteButtonColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error dalam LoadDataMahasiswa: {ex.Message}\n{ex.StackTrace}");
            }
        }
        
        // Event handler untuk tombol Home
        private void btnHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Home clicked!");
            // Anda bisa menambahkan logika lain untuk membuka halaman atau view tertentu.
        }

        // Event handler untuk tombol Settings
        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings clicked!");
            // Tambahkan logika untuk membuka pengaturan atau halaman terkait.
        }
        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            LoadDataKaryawan();
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
                    int id_users = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_users"].Value);
                    usersControllers.DeleteKaryawan(id_users); // Gunakan metode DeleteKaryawan
                    MessageBox.Show("Data berhasil dihapus.");
                    LoadDataKaryawan(); // Refresh data setelah penghapusan
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

