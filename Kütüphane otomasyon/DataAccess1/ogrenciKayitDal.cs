using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using Entity;
using System.Collections;

namespace DataAccess
{
    public class ogrenciKayitDal : IogrenciKayitDal
    {
        public void Ekle(TextBox a, TextBox b, TextBox c)
        {
            Baglanti.GetBaglanti.Open();

            if (!string.IsNullOrEmpty(a.Text) && !string.IsNullOrEmpty(b.Text) && !string.IsNullOrEmpty(c.Text))
            {
                OleDbCommand komut = new OleDbCommand("insert into Ogrenciler (Ad,Soyad,Numara) values('" + a.Text.ToString() + "','" + b.Text.ToString() + "','" + c.Text.ToString() + "')", Baglanti.GetBaglanti);
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
            using (OleDbConnection con = new OleDbConnection(Baglanti.GetBaglanti.ConnectionString))
            {
                string sqlquery = "Select * From Ogrenciler";
                OleDbCommand cmd = new OleDbCommand(sqlquery, Baglanti.GetBaglanti);
                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable scores = new DataTable();
                adapter.Fill(scores);
                a.DataSource = scores;
            }

        }

        public OgrenciKayit GetOgrenciBilgleri(int a)
        {

            string sql = $"Select [Ad]," + $"[Soyad]," + $"[Numara]," + $"[ID] From Ogrenciler where [ID] ={a}";
            //$ bu isaret sayesinde belirli isaretleri farkli turde kullanmani sag;iyor
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();

            OleDbCommand cmd = new OleDbCommand(sql, Baglanti.GetBaglanti);
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();   // bu komutu koymadiginda bu verileri goruntuleyemiyorsun..


            return new OgrenciKayit
            {
                OgrenciAdi = (string)reader["Ad"],
                OgrenciSoyad = (string)reader["Soyad"],
                Numara = (int)reader["Numara"],
                ID = (int)reader["ID"]

            };


        }
       
        public void Guncelle(ArrayList gelen)
        {
                Baglanti.GetBaglanti.Close();
                Baglanti.GetBaglanti.Open();
                string sql = $"UPDATE Ogrenciler set Ad= '{gelen[1]}' ,Soyad= '{gelen[2]}' ,Numara= {gelen[3]} where ID={ gelen[0]}";
            // sql sorgusunda eger deger string olucaksa tek tirmak icine almayi unutma yoksa eksik row hatasi verir 
                OleDbCommand cmd = new OleDbCommand(sql, Baglanti.GetBaglanti);
                cmd.ExecuteNonQuery();
                Baglanti.GetBaglanti.Close();

        }


        public void Sil(TextBox d)
        {
            Baglanti.GetBaglanti.Open();
            Baglanti.GetKomut.Connection = Baglanti.GetBaglanti;
            Baglanti.GetKomut.CommandText = "delete from Ogrenciler where ID =" + Convert.ToInt32(d.Text);
            Baglanti.GetKomut.ExecuteNonQuery();
            Baglanti.GetBaglanti.Close();

        }
    }
}
