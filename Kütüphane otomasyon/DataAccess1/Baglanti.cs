using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace DataAccess
{
    public static  class Baglanti
    {

            public static string path = "C:\\Users\\baran\\Desktop\\Database3.accdb;";

            private static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
           
            private static OleDbCommand komut = new OleDbCommand();

        public static OleDbConnection GetBaglanti => baglanti;
        public static OleDbCommand GetKomut => komut;
        



    }
}
