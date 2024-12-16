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
using TaniAttire.App.Core;

namespace TaniAttire.Views.Kasir
{
    public partial class TrackPersewaanPengembalian : Form
    {
        private int _idTransaksi;
        private TransaksiSewaControllers _controller;

        public TrackPersewaanPengembalian(int idTransaksi)
        {
            InitializeComponent();
            _idTransaksi = idTransaksi;
            _controller = new TransaksiSewaControllers();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                DateTime tanggalPengembalian = dateTimePickerTanggal.Value;

                
                int idTransaksi = _idTransaksi; 

                _controller.UpdateStatusPengembalian(idTransaksi, tanggalPengembalian);

                
                MessageBox.Show("Tanggal pengembalian berhasil diperbarui dan status pengembalian diubah menjadi 'true'.",
                                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengupdate pengembalian: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TrackPersewaanPengembalian_Load(object sender, EventArgs e)
        {

        }
    }
}
