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
using System.Data.OleDb;
using Businesss;

namespace SonAccessProje
{
    public partial class OgrenciKayit : Form
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ogrenciKayitDal kayit = new ogrenciKayitDal();
            kayit.Goruntule(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogrenciKayitDal kayit = new ogrenciKayitDal();
            kayit.Ekle(textBox1, textBox2, textBox3);
            
            kayit.Goruntule(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenciKayitDal kayit = new ogrenciKayitDal();
            kayit.Sil(textBox4);
            
            kayit.Goruntule(dataGridView1);
        }







        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
    

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox7.Text = row.Cells["Ad"].Value.ToString();
                textBox8.Text = row.Cells["Soyad"].Value.ToString();
                textBox9.Text = row.Cells["Numara"].Value.ToString();
                textBox6.Text = row.Cells["ID"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 7 8 9 6
            OgrenciBusiness ogrenci = new OgrenciBusiness();
            ogrenci.z(textBox7,textBox8,textBox9,textBox6);


          
        }
    }
}
