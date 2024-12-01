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
        public int Userid;
        private usersControllers _controller;

        public int UserId { get; private set; }

        public Ubah_Karyawan(int user_id)
        {
            InitializeComponent();
            _controller = new usersControllers();
            UserId = user_id;
            LoadKaryawanData(UserId);
        }
        private void LoadKaryawanData(int userID)
        {
            Users user = _controller.GetUserById(userID);
            if (user != null)
            {
                textBox1.Text = user.Username;
                textBox2.Text = user.Password;
                textBox3.Text = user.Role;
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

                _controller.UpdateKaryawan(UserId,username, password, nama, no_telpon);
                MessageBox.Show("Data karyawan berhasil di update");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data inputan salah, periksa kembali");
            }
        }
    }
}
