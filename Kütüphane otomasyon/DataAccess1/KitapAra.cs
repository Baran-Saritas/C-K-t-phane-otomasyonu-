using DataAccess;
using Entity;
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
    public  class KitapArama
    {
        public bool Bul(string gelen)
        {
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();
            Baglanti.GetKomut.CommandText = "Select * From KitapKayitlari";
            Baglanti.GetKomut.Connection = Baglanti.GetBaglanti;
            OleDbDataReader oku = Baglanti.GetKomut.ExecuteReader();
            bool a = false;
            while (oku.Read())
            {

                if ((oku["KitapAdi"].ToString()) == Convert.ToString(gelen))
                {

                   
                    a = true;
                }

             
            }
            return a;
        }
        public void Goruntule(DataGridView a)
        {
            using (OleDbConnection con = new OleDbConnection(Baglanti.GetBaglanti.ConnectionString))
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
    }
}
