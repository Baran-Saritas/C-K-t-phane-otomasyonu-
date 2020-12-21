using Businesss;
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
    public partial class AlisGirisKontrolx : Form
    {
        public AlisGirisKontrolx()
        {
            InitializeComponent();   // bu func calismadan formdaki hicbirseyi goruntuleyemezsin
        }

        private void AlisGirisKontrol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlisGirisKontrolBusiness s = new AlisGirisKontrolBusiness();
            bool sonuc = s.Kontrol(textBox1);

            if(sonuc ==  true)
            {
                MessageBox.Show("Bilgileriniz doğrulandı gereklı sayfaya yönlendiriliyorsunuz");
                AlımIade alımIade = new AlımIade(Convert.ToInt32( textBox1.Text));
                alımIade.Show();
            }
            else
            {
                MessageBox.Show("Sistemde kaydınız bulunamadı");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlisGirisKontrolBusiness s = new AlisGirisKontrolBusiness();
            s.y(dataGridView1);
        }
    }
}
