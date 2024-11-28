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
    public partial class Tambah_Ukuran : Form
    {
        private ukuranControllers _controller;
        public Tambah_Ukuran()
        {
            InitializeComponent();
            _controller = new ukuranControllers();
        }

        private void Tambah_Ukuran_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(comboBoxKategori.Text) || string.IsNullOrEmpty(textBoxNilaiUkuran.Text))
                {
                    MessageBox.Show("Kategori dan Nilai Ukuran harus diisi.");
                    return;
                }

                Ukuran ukuranBaru = new Ukuran
                {
                    Kategori = comboBoxKategori.Text,
                    Nilai_Ukuran = textBoxNilaiUkuran.Text,
                    Status = true
                };

                _controller.AddUkuran(ukuranBaru);

                MessageBox.Show("Ukuran berhasil ditambahkan.");
                Form_Ukuran formukuran = new Form_Ukuran();
                formukuran.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form_Ukuran formukuran = new Form_Ukuran();
            formukuran.Show();
            this.Hide();
        }
    }
}
