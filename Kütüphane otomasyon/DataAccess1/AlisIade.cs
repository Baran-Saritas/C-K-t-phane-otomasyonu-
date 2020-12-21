using DataAccess;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess
{
    public class AlisIade
    {


        public void alisGuncelle(ArrayList a)
        {
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();
            string query = $"Update IadeAlis Set KitapNo ={a[0]},OgrenciNo={a[1]},KitapAdi='{a[2]}',AlanAdi='{a[3]}'," +
                $"AlanSoyadi='{a[4]}',AlisTarihi= '{ DateTime.Parse(a[5].ToString())}' ,VerisTarihi= '{ DateTime.Parse(a[6].ToString())}',Borc={a[7]},Durum='{a[8]}' " +
                $"where OgrenciNo={a[1]} and Durum ='Teslim Alındı'";
            OleDbCommand cmd = new OleDbCommand(query, Baglanti.GetBaglanti);
            MessageBox.Show("Gecikme Borcunuz :" + a[7]);

            cmd.ExecuteNonQuery();
            Baglanti.GetBaglanti.Close();

        }

        public void KitapGuncelle(ArrayList gelen)
        {
            
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();
            string query = $"Update KitapKayitlari Set KitapAdi='{gelen[1]}', KitapKonusu='{gelen[2]}', Yazari='{gelen[3]}', SayfaSayisi={gelen[4]}, Odunc='{gelen[5]}' where KitapNo = {gelen[0]}";
           
            OleDbCommand cmd = new OleDbCommand(query, Baglanti.GetBaglanti);

     
            cmd.ExecuteNonQuery();
            Baglanti.GetBaglanti.Close();
           

        }

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
        public AlimIslem GetAlimIadeTable(int a, int b)
        {
            string c = "Teslim Alındı";
            string sql = $"Select [KitapNo],"+"[ID]," + "[OgrenciNo]," + "[KitapAdi]," + "[AlanAdi]," + "[AlanSoyadi]," + "[AlisTarihi]," +
                "[VerisTarihi]," + "[Borc]," + $"[Durum] From IadeAlis where [OgrenciNo] ={a} and [KitapNo]={b} and [Durum]='{c}'";

            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();

            OleDbCommand cmd = new OleDbCommand(sql, Baglanti.GetBaglanti);
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();

            return new AlimIslem
            {
                ID=(int)reader["ID"],
                KitapNo = (int)reader["KitapNo"],
                OgrenciNo = (int)reader["OgrenciNo"],
                KitapAdi = (string)reader["KitapAdi"],
                AlanAdi = (string)reader["AlanAdi"],
                AlanSoyadi = (string)reader["AlanSoyadi"],
                AlisTarihi =(DateTime)reader["AlisTarihi"],
                VerisTarihi =(DateTime)reader["VerisTarihi"],
                Borc =(int)reader["Borc"],
                Durum = (string)reader["Durum"]

            };

        }


        public  OgrenciKayit GetOgrenciKayit(int b)
        {
            string sql = $"Select [Ad]," + $"[Soyad]," + $"[Numara]," + $"[ID] From Ogrenciler where [Numara] ={b}";

            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();

            OleDbCommand cmd = new OleDbCommand(sql, Baglanti.GetBaglanti);
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();   // bu komutu koymadiginda bu verileri goruntuleyemiyorsun..

            return new OgrenciKayit
            {
                OgrenciAdi = (string)reader["Ad"],
                OgrenciSoyad = (string)reader["Soyad"],
                Numara = (int)reader["Numara"]
            };
        }


        // Iade Alis Goruntule 
        public void Goruntule(DataGridView a,int b)
        {
            using (OleDbConnection con = new OleDbConnection(Baglanti.GetBaglanti.ConnectionString))
            {
                string sqlquery = $"Select * From IadeAlis where [OgrenciNo] ={b}";
                OleDbCommand cmd = new OleDbCommand(sqlquery, Baglanti.GetBaglanti);
                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable scores = new DataTable();
                adapter.Fill(scores);
                a.DataSource = scores;
            }
        }


        public void Ekle(ArrayList gelen)
        {
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();
            OleDbCommand komut = new OleDbCommand($"INSERT into IadeAlis (KitapNo,OgrenciNo,KitapAdi,AlanAdi,AlanSoyadi,AlisTarihi,VerisTarihi,Borc,Durum) " +
                $"values('" + gelen[0] + "','" + gelen[1] + "','" + gelen[2] + "','" + gelen[3] + "','" + gelen[4] + "','" + gelen[5] + "','" + gelen[6] + "','" + gelen[7] + "','" + gelen[8] + "')", Baglanti.GetBaglanti);
            komut.ExecuteNonQuery();
            Baglanti.GetBaglanti.Close();

        }




    }
}
