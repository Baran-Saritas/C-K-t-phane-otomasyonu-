using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Businesss
{
    public class KitapAramaBusiness
    {

        KitapArama x = new KitapArama();
        public bool Kontrol(TextBox a)
        {
            bool gelen;

            try
            {
                gelen = x.Bul(a.Text);

                if (gelen == true)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Numara eksik yada boş bırakmayın");
                return false;
            }


        }

    }
}
