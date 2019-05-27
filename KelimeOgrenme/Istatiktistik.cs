using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelimeOgrenme
{
    public partial class Istatiktistik : Form
    {
        public Istatiktistik()
        {
            InitializeComponent();
        }

        private void BtnIslem_Click(object sender, EventArgs e)
        {
            lst_Istatistik.Items.Clear();
            int ayindex=0;
            string yil="";

            ayindex = cmbxAy.SelectedIndex + 1;
            yil = cmbxYil.Text;

            List<string> kelimeVerileri = new List<string>();

            KelimeDatabase kelimeDatabase = new KelimeDatabase();

            if (ayindex > 0)
            {
                kelimeVerileri = kelimeDatabase.Istatiktistik(ayindex, yil);
            }

            else if(ayindex == 0)
            {
                kelimeVerileri = kelimeDatabase.Istatiktistik(yil);

            }

            else { MessageBox.Show("Hatalı değer girdiniz.");}

            for (int i = 0; i < kelimeVerileri.Count; i++)
            {
                lst_Istatistik.Items.Add(kelimeVerileri[i]);
            }

            lblKelimeSayisi.Text = kelimeVerileri.Count.ToString();


        }

        private void Label3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
