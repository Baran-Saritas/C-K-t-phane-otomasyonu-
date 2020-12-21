using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlimIslem  // KITAP ALINDIGINDA KAYDEDILICEK TABLODAKI 1 SATIRDAKI VERILER
    {                      
        public int ID { get; set; }
        public int KitapNo { get; set; }
        public int OgrenciNo { get; set; }
        public string KitapAdi { get; set; }
        public string AlanAdi { get; set; }
        public string AlanSoyadi { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime VerisTarihi { get; set; }
        public int Borc { get; set; }
        public string Durum { get; set; }


    }
}
