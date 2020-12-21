using Businesss;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace SonAccessProje
{
    public partial class my_graph : Form
    {
        public my_graph()
        {

            InitializeComponent();
            //plotgraph();
            plotgraph();
        }
        
        private void plotgraph()
        {
            Baglanti.GetBaglanti.Close();
            Baglanti.GetBaglanti.Open();
            Baglanti.GetKomut.CommandText = "Select * From KitapKayitlari";
            Baglanti.GetKomut.Connection = Baglanti.GetBaglanti;
            OleDbDataReader oku = Baglanti.GetKomut.ExecuteReader();
            int alinan = 0;
            int kalan = 0;
            while (oku.Read())
            {

                if ((oku["Odunc"].ToString()) == "Teslim Alındı")
                {
                    alinan += 1;
                }
                else if ((oku["Odunc"].ToString()) == "Alınmadı")
                {
                    kalan += 1;
                }

            }
        
            ZedGraphControl zedControl = new ZedGraphControl();
            GraphPane pane = new GraphPane();

            int[] kveriler = new int[2];
           

            pane.XAxis.IsVisible = false;
            pane.YAxis.IsVisible = false;
            string[] x0 = new string[] { "Kütüphanedi kitap sayısı", "Alınan kitap sayısı" };
            double[] y0 = new double[] { kalan, alinan };
            Color[] c0 = new Color[] { Color.DarkBlue, Color.Red };
            pane.Fill = new Fill(Color.White, Color.White, 45.0f);
            pane.Chart.Fill.Type = FillType.None;
            pane.Legend.Position = LegendPos.Float;
            pane.Legend.Location = new Location(0.30f, 0.05f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            pane.Legend.FontSpec.Size = 10f;
            pane.Legend.IsHStack = false;
            for (int i = 0; i < 2; i++)
            {
                
                PieItem segment1 = pane.AddPieSlice(y0[i], c0[i], 0.1, x0[i]);

                segment1.LabelType = PieLabelType.Name_Value_Percent;
            }
            //pane.AddPieSlices(y0, x0);
            zedControl.GraphPane = pane;
            zedControl.Height = this.Height;
            zedControl.Width = this.Width;
            zedControl.IsEnableWheelZoom = false;
            this.Controls.Add(zedControl);
        }
        private void my_graph_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
