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
    public partial class KelimeOgrenmeAnaEkran : Form
    {
        public KelimeOgrenmeAnaEkran()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBasla_Click(object sender, EventArgs e)
        {
            SorularIngTur sorularIngTur = new SorularIngTur();
            
            sorularIngTur.ShowDialog();
        }

        private void KelimeOgrenmeAnaEkran_Load(object sender, EventArgs e)
        {
          
            
        }
   
      
        


        private void BtnKelimeIslemleri_Click(object sender, EventArgs e)
        {
            KelimeIslem kelimeIslem = new KelimeIslem();
            this.Hide();
            kelimeIslem.ShowDialog();
        }

        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
            Istatiktistik istatiktistik = new Istatiktistik();
            istatiktistik.ShowDialog();
        }

       

      
    }
       
    }

