using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataAccess
{
    interface IogrenciKayitDal
    {
        void Guncelle(ArrayList gelen);
        void Sil(TextBox d);
        void Goruntule(DataGridView a);
        void Ekle(TextBox a, TextBox b, TextBox c);
    }
}
