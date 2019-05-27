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
    public partial class KelimeIslem : Form
    {
        public KelimeIslem()
        {
            InitializeComponent();
        }

      
        KelimeDatabase kelimeDatabase = new KelimeDatabase();
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eklemek istediğiniz kelimeye ait bilgileri giriniz.");
            pnlKelime.Visible = true;
            

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            KelimeSil kelimeSil = new KelimeSil();
            kelimeSil.ShowDialog();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            KelimeGuncelle kelimeGuncelle = new KelimeGuncelle();
            kelimeGuncelle.ShowDialog();
        }

        private void BtnIslem_Click(object sender, EventArgs e)
        {
            kelimeDatabase.KelimeEkle(txtKelime.Text, txtAnlam.Text, txtTur.Text, txtCumle.Text);
            MessageBox.Show("Kelime ekleme işlemi tamamlandı");
            txtKelime.Text = "";
            txtTur.Text = "";
            txtCumle.Text = "";
            txtTur.Text = "";
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAnaEkran_Click(object sender, EventArgs e)
        {
            KelimeOgrenmeAnaEkran anaEkran = new KelimeOgrenmeAnaEkran();
            this.Close();
            anaEkran.Show();
        }
    }
}
