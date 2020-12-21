using Businesss;
using DataAccess;
using Entity;
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
    public partial class KitapAra : Form
    {
        public KitapAra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapAramaBusiness s = new KitapAramaBusiness();
            bool sonuc =  s.Kontrol(textBox1);
            if (sonuc == true)
            {
                MessageBox.Show("Aratmış olduğunuz kitap kütüphanemizde mevcuttur");
              
            }
            else
            {
                MessageBox.Show("Sistemde kitabınız bulunamadı");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KitapArama s = new KitapArama();
            s.Goruntule(dataGridView1);
            
        }
    }
}
