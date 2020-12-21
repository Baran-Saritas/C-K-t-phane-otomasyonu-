using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class KayitKitap
    {
                          // KITAP EKLENDIGINDE KAYDEDILICEK TABLODAKI 1 SATIRDAKI VERILER
                          
        public int KitapNo { get; set; }
        public string KitapAdi { get; set; }
        public string KitapKonusu { get; set; }
        public string Yazari { get; set; }
        public int SayfaSayisi { get; set; }
        public string Odunc { get; set; }

    }
}
