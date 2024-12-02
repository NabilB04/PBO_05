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
    public partial class Ubah_Karyawan : Form
    {
        public int Id_Users;
        private usersControllers _controller;

        public Ubah_Karyawan(int Id_Users)
        {
            InitializeComponent();
            _controller = new usersControllers();
            this.Id_Users = Id_Users;
            LoadKaryawanData(Id_Users);
        }
        private void LoadKaryawanData(int Id_Users)
        {
            Users user = _controller.GetUserById(Id_Users);
            if (user != null)
            {
                textBox1.Text = user.Username;
                textBox2.Text = user.Password;
                textBox4.Text = user.Nama;
                textBox5.Text = user.No_Telpon;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ubah_Karyawan_Load(object sender, EventArgs e)
        {

        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string nama = textBox4.Text;
                string no_telpon = textBox5.Text;

                _controller.UpdateKaryawan(Id_Users, username, password, nama, no_telpon);
                MessageBox.Show(Id_Users.ToString());
                Mnj_Karyawan manajemenkaryawan = new Mnj_Karyawan();    
                manajemenkaryawan.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data inputan salah, periksa kembali{ex.Message}");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Mnj_Karyawan manajemenkaryawan = new Mnj_Karyawan();   
            manajemenkaryawan.Show();
            this.Hide();
        }
    }
}
