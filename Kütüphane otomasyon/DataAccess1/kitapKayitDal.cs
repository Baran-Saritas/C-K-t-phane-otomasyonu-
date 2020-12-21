using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using Entity;
using System.Data.SqlClient;
using System.Collections;

namespace DataAccess
{
    public class kitapKayitDal : IkitapKayitDal
    {
        KayitKitap kayit = new KayitKitap();
        public kitapKayitDal(KayitKitap kayit)
        {
            this.kayit = kayit;
        }
        public kitapKayitDal()
        {

        }
        public void Ekle( TextBox b , TextBox c,TextBox d ,TextBox e)
        {
            Baglanti.GetBaglanti.Open();
            
            if (  !string.IsNullOrEmpty(b.Text) && !string.IsNullOrEmpty(c.Text) && !string.IsNullOrEmpty(d.Text) && !string.IsNullOrEmpty(e.Text))
            {
                OleDbCommand komut = new OleDbCommand("insert into KitapKayitlari (KitapAdi,KitapKonusu,Yazari,SayfaSayisi,Odunc) values(" +
                    "'" + b.Text.ToString() +
                    "','" + c.Text.ToString() + 
                    "','" + d.Text.ToString() +
                    "','" + e.Text.ToString() + 
                    "','"+"Alinmadi"+
                    "')", Baglanti.GetBaglanti);                                   
                komut.ExecuteNonQuery();
                Baglanti.GetBaglanti.Close();
                
            }
            else
            {
                MessageBox.Show("Gerekli yerleri doldurun");
            }
            Baglanti.GetBaglanti.Close();

        }
        public void Goruntule(DataGridView a)
        {
            using(OleDbConnection con = new OleDbConnection(Baglanti.GetBaglanti.ConnectionString))
            {
                string sqlquery = "Select * From KitapKayitlari";
                OleDbCommand cmd = new OleDbCommand(sqlquery, Baglanti.GetBaglanti);
                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable scores = new DataTable();
                adapter.Fill(scores);
                a.DataSource = scores;
                Baglanti.GetBaglanti.Close();
            }
    
        }
        /*
        public void Goruntule(ListView a)
        {

            Baglanti.GetBaglanti.Open();
            Baglanti.GetKomut.CommandText = "Select * From Ogrenciler";
            Baglanti.GetKomut.Connection = Baglanti.GetBaglanti;
           
            OleDbDataReader oku = Baglanti.GetKomut.ExecuteReader();
            
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

  
                //if ((oku["Ad"].ToString()) == "Baran")
               
                ekle.Text = oku["ID"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Numara"].ToString());

                a.Items.Add(ekle);
               
            }
            Baglanti.GetBaglanti.Close();

        }
        */
        public KayitKitap GetKitapBilgileri(int a)
        {        
            string sql = $"Select [KitapAdi]," +
                $"[KitapKonusu],[Yazari],[SayfaSayisi],[Odunc]," +
                $"[KitapNo] From KitapKayitlari where [KitapNo] ={a}";

            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();

            OleDbCommand cmd = new OleDbCommand(sql, Baglanti.GetBaglanti);

                OleDbDataReader reader = cmd.ExecuteReader();
                reader.Read();

            /* MessageBox.Show(reader["KitapAdi"].ToString());
              (kayit.KitapAdi, kayit.KitapNo 
                ,kayit.Yazari,kayit.SayfaSayisi,kayit.KitapKonusu)
                = ((string)reader["KitapAdi"],(int)reader["KitapNo"],
                (string)reader["Yazari"],(int)reader["SayfaSayisi"],(string)reader["KitapKonusu"]);
             */
           
                  return new KayitKitap
                {
                    KitapAdi = (string)reader["KitapAdi"],
                    KitapNo = (int)reader["KitapNo"],
                    Yazari = (string)reader["Yazari"],
                    SayfaSayisi = (int)reader["SayfaSayisi"],
                    KitapKonusu = (string)reader["KitapKonusu"],
                    Odunc = (string)reader["Odunc"]
                };
           
            
        }
        public void Guncelle(ArrayList gelen)
        {
            //using (OleDbConnection con = new OleDbConnection(Baglanti.GetBaglanti.ConnectionString))
            // {
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();
            string query = $"Update KitapKayitlari Set KitapAdi='{gelen[1]}'" +
                $", KitapKonusu='{gelen[2]}', Yazari='{gelen[3]}'," +
                $" SayfaSayisi={gelen[4]}, Odunc='{gelen[5]}' where KitapNo = {gelen[0]}";
           // string sql = "UPDATE KitapKayitlari SET KitapAdi= ?, KitapKonusu= ?, Yazari= ?, SayfaSayisi= ?, Odunc= ? WHERE KitapNo= ?";
            OleDbCommand cmd = new OleDbCommand(query, Baglanti.GetBaglanti);

            /*cmd.Parameters.AddWithValue("@KitapNo", gelen[0]);
            cmd.Parameters.AddWithValue("@KitapAdi", gelen[1]);
            cmd.Parameters.AddWithValue("@KitapKonusu", gelen[2]);
            cmd.Parameters.AddWithValue("@Yazari", gelen[3]);
            cmd.Parameters.AddWithValue("@SayfaSayisi", gelen[4]);
            cmd.Parameters.AddWithValue("@Odunc", gelen[5]);
            */
            cmd.ExecuteNonQuery();
            Baglanti.GetBaglanti.Close();
           // }

        }
        public void Sil(TextBox d)
        {
            Baglanti.GetBaglanti.Open();
            Baglanti.GetKomut.Connection = Baglanti.GetBaglanti;
            Baglanti.GetKomut.CommandText = "delete from KitapKayitlari where KitapNo =" + Convert.ToInt32(d.Text) ;
            Baglanti.GetKomut.ExecuteNonQuery();
            Baglanti.GetBaglanti.Close();
            
        }
    }
}
