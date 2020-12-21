using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataAccess
{
    interface IkitapKayitDal
    {
        void Guncelle(ArrayList gelen);
        void Sil(TextBox d);
        void Goruntule(DataGridView a);
        void Ekle(TextBox b, TextBox c, TextBox d, TextBox e);
    }
}
