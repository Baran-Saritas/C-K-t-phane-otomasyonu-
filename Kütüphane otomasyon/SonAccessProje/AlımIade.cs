using Businesss;
using DataAccess;
using SonAccessProje;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SonAccessProje
{
    public partial class AlımIade : Form
    {
        private int numara;
        public AlımIade(int numara)
        {
            InitializeComponent();
            this.numara = numara;
            


        }

        private void button1_Click(object sender, EventArgs e)
        {

            AlisIadeBusiness d = new AlisIadeBusiness();
            var take = new ArrayList();
            DateTime time;
            DateTime time2;
            DateTime bugun = DateTime.Now;
            
            time = dateTimePicker1.Value;
            time2 = dateTimePicker2.Value;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                take.Add(textBox1.Text);
                take.Add(textBox2.Text);
                take.Add(time);
                take.Add(time2);
                d.x(take);

                AlisIade alis = new AlisIade();
                alis.Goruntule(dataGridView1, numara);
                kitapKayitDal kayit = new kitapKayitDal();
                kayit.Goruntule(dataGridView2);
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları boş bırakmayın");
            }
            //MessageBox.Show((time.Day-time2.Day).ToString()); kontrolunu boyle yapicam misal iade 
            //ettigi tarih ile date time ile suanki zamani karsilastiricam - cikarsa cikan degerle 1 i carpip ekrana borc 
            // olarak yansitilacak bu sayede 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            AlisIade alis = new AlisIade();
            alis.Goruntule(dataGridView1,numara);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           //AlisGirisKontrolx zz = new AlisGirisKontrolx();
            
            kitapKayitDal kayit = new kitapKayitDal();
            kayit.Goruntule(dataGridView2);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            DateTime bugun = DateTime.Now;

            for(int i =0; i< dataGridView1.Rows.Count - 1; i++)
            {

                if(dataGridView1.Rows[i].Cells["Durum"].Value.ToString() == "Teslim Alındı")
                {

                    if ((   DateTime.Parse(dataGridView1.Rows[i].Cells["VerisTarihi"].Value.ToString()).Day - bugun.Day) <= 2 &&
                        ( DateTime.Parse(dataGridView1.Rows[i].Cells["VerisTarihi"].Value.ToString()).Day - bugun.Day) >=0 ) 
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if(( DateTime.Parse(dataGridView1.Rows[i].Cells["VerisTarihi"].Value.ToString()).Day - bugun.Day) < 0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                else if (dataGridView1.Rows[i].Cells["Durum"].Value.ToString() == "Teslim Edildi")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }



            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

            AlisIadeBusiness x = new AlisIadeBusiness();
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {

                x.ver(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                AlisIade alis = new AlisIade();
                alis.Goruntule(dataGridView1, numara);
                kitapKayitDal kayit = new kitapKayitDal();
                kayit.Goruntule(dataGridView2);

            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları boş bırakmayın");
            }

        }
    }
}
