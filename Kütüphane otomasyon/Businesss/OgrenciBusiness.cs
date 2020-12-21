using DataAccess;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Businesss
{
    public class OgrenciBusiness
    {

        public void z(TextBox a, TextBox b, TextBox c, TextBox d)
        {
            /*
                Ad
                Soyad
                Numara
                ID
            */

            var yollanicak = new ArrayList();
            ogrenciKayitDal ogrenci = new ogrenciKayitDal();

            if (!string.IsNullOrEmpty(d.Text))
            {

                yollanicak.Add(d.Text);
                OgrenciKayit alinan = ogrenci.GetOgrenciBilgleri(Convert.ToInt32(d.Text));

                if (!string.IsNullOrEmpty(a.Text))
                {

                    yollanicak.Add(a.Text);
                }
                else
                {

                    yollanicak.Add(alinan.OgrenciAdi);
                }

                if (!string.IsNullOrEmpty(b.Text))
                {

                    yollanicak.Add(b.Text);
                }
                else
                {

                    yollanicak.Add(alinan.OgrenciSoyad);
                }

                if (!string.IsNullOrEmpty(c.Text))
                {

                    yollanicak.Add(c.Text);
                }
                else
                {

                    yollanicak.Add(alinan.Numara);
                }

                ogrenci.Guncelle(yollanicak);

            }
            else
            {
                MessageBox.Show("Kitap No`sunu giriniz");          

            }


        }
    }
}