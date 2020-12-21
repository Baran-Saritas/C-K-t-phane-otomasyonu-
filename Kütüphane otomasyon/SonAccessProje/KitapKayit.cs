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
    public partial class KitapKayit : Form
    {
        
        public KitapKayit()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ID bölümünü Mevcut Kayıtlardan seçerek doldurunuz..");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kitapKayitDal kayit = new kitapKayitDal();
            kayit.Goruntule(dataGridView1);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox5.Text = row.Cells["KitapNo"].Value.ToString();
                textBox8.Text = row.Cells["KitapAdi"].Value.ToString();
                textBox11.Text = row.Cells["KitapKonusu"].Value.ToString();
                textBox7.Text = row.Cells["Yazari"].Value.ToString();
                textBox6.Text = row.Cells["SayfaSayisi"].Value.ToString();
            }
          

        }
        private void button5_Click(object sender, EventArgs e)
        {
            //kitapKayitDal kayit = new kitapKayitDal();
            // kayit.Guncelle(textBox8 ,textBox11 ,textBox7,textBox6,textBox5);
            KitapBusiness kayit = new KitapBusiness();
            kayit.x(textBox5, textBox8, textBox11, textBox7, textBox6);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            kitapKayitDal kayit = new kitapKayitDal();
            kayit.Ekle(textBox2,textBox3,textBox9,textBox10);
            kayit.Goruntule(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kitapKayitDal kayit = new kitapKayitDal();
            kayit.Sil(textBox4);
            kayit.Goruntule(dataGridView1);
        }


    }
}
