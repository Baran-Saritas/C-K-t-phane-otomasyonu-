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
    public class AlisIadeBusiness
    {
        // burda yapilicak sey text ekranindan gelicek verileri buraya aticaz ve arraylist olusturup ekleye yollicaz
        // alinan verileri cekip arrayliste veritabanindaki sirasiyla aticaz ve simdilik yaplicaklar bukadar 
        public void x(ArrayList alinan)
        {

            var yollanicak = new ArrayList();
            var kitabayollanicak = new ArrayList();
            AlisIade alis = new AlisIade();
            DateTime bugun = DateTime.Now;

            // burasi yollanilicak verileri halledicek ve alis iade tablosuna kaydedicek 

            OgrenciKayit ogrenci =alis.GetOgrenciKayit(Convert.ToInt32(alinan[0]));
            KayitKitap kitap =alis.GetKitapBilgileri(Convert.ToInt32( alinan[1]));

            yollanicak.Add(kitap.KitapNo);
            yollanicak.Add(ogrenci.Numara);
            yollanicak.Add(kitap.KitapAdi);
            yollanicak.Add(ogrenci.OgrenciAdi);
            yollanicak.Add(ogrenci.OgrenciSoyad);
            yollanicak.Add(alinan[2]);
            yollanicak.Add(alinan[3]);


                
            /*
            if ( (DateTime.Parse(alinan[3].ToString()).Day - bugun.Day) <= 0)
            {
                int a = DateTime.Parse(alinan[3].ToString()).Day - bugun.Day;
                int borc = -1 * a;
                yollanicak.Add(borc);
            }
            else
            {
                yollanicak.Add(0);
            }
            */



            yollanicak.Add(0);
            yollanicak.Add("Teslim Alındı");
            


            if(kitap.Odunc == "Alınmadı")
            {
                alis.Ekle(yollanicak);

                //kitap kolununu guncelleme 
                kitabayollanicak.Add(kitap.KitapNo);
                kitabayollanicak.Add(kitap.KitapAdi);
                kitabayollanicak.Add(kitap.KitapKonusu);
                kitabayollanicak.Add(kitap.Yazari);
                kitabayollanicak.Add(kitap.SayfaSayisi);
                kitabayollanicak.Add("Teslim Alındı");

                alis.KitapGuncelle(kitabayollanicak);

            }
            else
            {
                MessageBox.Show("Seçtiğiniz kitap alınmış ");
            }

        }






        public void ver(int a,int b)
        {
            var yollanicak = new ArrayList();
            AlisIade alis = new AlisIade();
            var kitabayollanicak = new ArrayList();
            DateTime bugun = DateTime.Now;

           
            AlimIslem gelenveri = alis.GetAlimIadeTable(a, b);
            KayitKitap kitap = alis.GetKitapBilgileri(Convert.ToInt32(gelenveri.KitapNo));

            yollanicak.Add(gelenveri.KitapNo);
            yollanicak.Add(gelenveri.OgrenciNo);
            yollanicak.Add(gelenveri.KitapAdi);
            yollanicak.Add(gelenveri.AlanAdi);
            yollanicak.Add(gelenveri.AlanSoyadi);
            yollanicak.Add(gelenveri.AlisTarihi);
            yollanicak.Add(gelenveri.VerisTarihi);
            if ((DateTime.Parse(gelenveri.VerisTarihi.ToString()).Day - bugun.Day) <= 0)
            {
                int c = DateTime.Parse(gelenveri.VerisTarihi.ToString()).Day - bugun.Day;
                int borc = -1 * c;
               
                yollanicak.Add(borc);
            }
            else
            {
                yollanicak.Add(0);
            }

            yollanicak.Add("Teslim Edildi");





            if (kitap.Odunc == "Teslim Alındı")
            {
  
                alis.alisGuncelle(yollanicak);   // BURAYA GUNCELLE KOYUCAKSIN 

                //kitap kolununu guncelleme 
                kitabayollanicak.Add(kitap.KitapNo);
                kitabayollanicak.Add(kitap.KitapAdi);
                kitabayollanicak.Add(kitap.KitapKonusu);
                kitabayollanicak.Add(kitap.Yazari);
                kitabayollanicak.Add(kitap.SayfaSayisi);
                kitabayollanicak.Add("Alınmadı");

                alis.KitapGuncelle(kitabayollanicak);

            }
            else
            {
                MessageBox.Show("Iade etmek istediğiniz kitap zaten alınmamış");
            }


        } 




    }
}
