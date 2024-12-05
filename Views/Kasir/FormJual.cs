using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaniAttire.Views.Auditor.Card;

namespace TaniAttire.Views.Kasir
{
    public partial class FormJual : Form
    {
        public FormJual()
        {
            InitializeComponent();
        }

        private void FormJual_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                CardProduk cardProduk = new CardProduk();
                cardProduk.Margin = new Padding(3);
                flowLayoutPanel1.Controls.Add(cardProduk);
            }
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
