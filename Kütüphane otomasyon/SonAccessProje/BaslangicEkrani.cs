using Businesss;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SonAccessProje
{
    public partial class BaslangicEkrani : Form
    {
        public BaslangicEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OgrenciKayit form = new OgrenciKayit();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KitapKayit form = new KitapKayit();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             
            AlisGirisKontrolx form = new AlisGirisKontrolx();
            form.ShowDialog();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            my_graph a = new my_graph();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KitapAra a = new KitapAra();
            a.Show();
        }
    }
}
