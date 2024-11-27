using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaniAttire
{
    public partial class KasirDashboard : Form
    {
        public KasirDashboard()
        {
            InitializeComponent();

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
        private void Dashboard_Load(object sender, EventArgs e)
        {

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
    }
}
