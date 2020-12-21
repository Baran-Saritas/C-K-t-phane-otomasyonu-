using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.OleDb;

namespace Businesss
{
    public class graphBusiness
    {

        public Array VerileriGetir()
        {
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();
            Baglanti.GetKomut.CommandText = "Select * From KitapKayitlari";
            Baglanti.GetKomut.Connection = Baglanti.GetBaglanti;
            OleDbDataReader oku = Baglanti.GetKomut.ExecuteReader();
            int alinan=0;
            int kalan = 0;     
            while (oku.Read())
            {

                if ((oku["Odunc"].ToString()) == "Teslim Alındı")
                {
                    alinan += 1;
                }
                else if ((oku["Odunc"].ToString()) == "Alınmadı")
                {
                    kalan += 1;
                }

            }
            int [] gidicek = new int[2];
            gidicek[0] = alinan;
            gidicek[1] = kalan;
            return gidicek;
        } 
        

    }
}
