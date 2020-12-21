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
    public class KitapBusiness
    {

        public void x(TextBox a, TextBox b, TextBox c, TextBox d, TextBox e)
        {
            // a burda kitap no olucak ve diger verileri getirmemizi saglayip bu sayede textlerin bos olmasina gore ona ayar verebilicez
            /* kitapNo
             - kitapAd
             - kitapKonusu 
             - KitapYazari
             - SayfaSayisi


            1 kitapno
            2 ogrencino
             */

            var yollanicak = new ArrayList();
            kitapKayitDal kitap = new kitapKayitDal();
            
           
            if (!string.IsNullOrEmpty(a.Text))
            {
                yollanicak.Add(Int32.Parse(a.Text));
                KayitKitap alinan = kitap.GetKitapBilgileri(Convert.ToInt32(a.Text));
       
                if (!string.IsNullOrEmpty(b.Text))
                {
                    
                    yollanicak.Add(b.Text);
                    
                }
                else
                {
                    
                    yollanicak.Add(alinan.KitapAdi);
                }


                if (!string.IsNullOrEmpty(c.Text))
                {
                    
                    yollanicak.Add(c.Text);
                }
                else
                {
                   
                    yollanicak.Add(alinan.KitapKonusu);
                }


                if (!string.IsNullOrEmpty(d.Text))
                {
                    yollanicak.Add(d.Text);
                   // MessageBox.Show(yollanicak[3].ToString());
                }
                else
                {
                    yollanicak.Add(alinan.Yazari);
                }


                if (!string.IsNullOrEmpty(e.Text))
                {
                    yollanicak.Add(e.Text);
                }
                else
                {
                    yollanicak.Add(alinan.SayfaSayisi);
                }

                yollanicak.Add(alinan.Odunc);

                
                kitap.Guncelle(yollanicak);                 

            }
            else
            {
                MessageBox.Show("Kitap No`sunu giriniz");
            }





        }
        
        


    }
}
