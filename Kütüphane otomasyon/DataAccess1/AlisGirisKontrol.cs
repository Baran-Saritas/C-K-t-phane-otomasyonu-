using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess
{
    public class AlisGirisKontrol
    {

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
                Baglanti.GetBaglanti.Close();
            }

        }
        public bool Bul(int num)
        {
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();
            Baglanti.GetKomut.CommandText = "Select * From Ogrenciler";
            Baglanti.GetKomut.Connection = Baglanti.GetBaglanti;
            OleDbDataReader oku = Baglanti.GetKomut.ExecuteReader();
            bool a =false;
            while (oku.Read())
            {

                if((oku["Numara"].ToString()) == num.ToString())
                {
                    a = true;
                }

            }
            return a;
        }

    }


}
