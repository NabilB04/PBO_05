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
    public partial class Tambah_Karyawan : Form
    {
        public Tambah_Karyawan()
        {
            InitializeComponent();
        }

        public event EventHandler OnDataUpdated;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            // Mengambil data dari TextBox
            string nama = textboxNama.Text.Trim();
            string username = textboxUsername.Text.Trim();
            string password = textboxPassword.Text.Trim();
            string nomor_telepon = textboxNotelp.Text.Trim();

            // Validasi input
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(nomor_telepon))
            {
                MessageBox.Show("Semua field harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Membuat objek Users
            Users newUser = new Users
            {
                Username = username,
                Password = password,
                Nama = nama,
                No_Telpon = nomor_telepon
            };

            // Menambahkan pengguna ke database menggunakan usersControllers
            try
            {
                usersControllers controller = new usersControllers();
                controller.AddUsers(newUser);

                MessageBox.Show("Pengguna berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnDataUpdated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

    }
}
