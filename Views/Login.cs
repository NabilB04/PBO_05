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
    public partial class Login : Form
    {
        private usersControllers _controller;
        public Login()
        {
            InitializeComponent();
            _controller = new usersControllers();
        }

        public static class SessionData
        {
            public static int LoggedInUserId { get; set; }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            try
            {

                usersControllers userController = new usersControllers();


                Users loggedInUser = userController.GetusersByusernameAndpassword(username, password);

                if (loggedInUser != null)
                {

                    SessionData.LoggedInUserId = loggedInUser.Id_Users;
                    if (loggedInUser != null)
                    {

                        if (loggedInUser.Role == "1")
                        {
                            MessageBox.Show("Login berhasil! Anda masuk sebagai Auditor.", "Login Sukses");

                            AuditorDashboard auditordashboard = new AuditorDashboard();
                            auditordashboard.Show();
                            this.Hide();
                        }
                        else if (loggedInUser.Role == "2")
                        {
                            MessageBox.Show("Login berhasil! Anda masuk sebagai Kasir.", "Login Sukses");

                            PenjualanProduk kasirdashboard = new PenjualanProduk();
                            kasirdashboard.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Role tidak valid!", "Kesalahan");
                    }
                }
                else
                {
                    MessageBox.Show("Username atau password salah.", "Login Gagal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '●';
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Tampilkan password
                textBox2.PasswordChar = '\0'; 
            }
            else
            {
                // Sembunyikan password dengan bulatan (●)
                textBox2.PasswordChar = '●'; 
            }
        }
    }
}
