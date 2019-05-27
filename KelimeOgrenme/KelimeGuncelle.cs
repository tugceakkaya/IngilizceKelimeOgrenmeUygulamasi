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
    public partial class KelimeGuncelle : Form
    {
        public KelimeGuncelle()
        {
            InitializeComponent();
        }
        KelimeDatabase kelimeDatabase = new KelimeDatabase();

        private void BtnIslem_Click(object sender, EventArgs e)
        {
            if(txtAnlam.Text==string.Empty || txtTur.Text==string.Empty || txtCumle.Text==string.Empty)
            {
                MessageBox.Show("Eksik değer girdiniz.Lutfen tekrar deneyiniz");
            }
            else
            {
                
                kelimeDatabase.KelimeGuncelle(txtKelime.Text, txtAnlam.Text, txtTur.Text, txtCumle.Text);
                MessageBox.Show("Kelime başarıyla güncellendi");
            }
            txtKelime.Text = "";
            txtTur.Text = "";
            txtCumle.Text = "";
            txtTur.Text = "";
            
        }

        private void KelimeGuncelle_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            bool sorgu = kelimeDatabase.KelimeAra(txtKelime.Text);
            if (txtKelime.Text == "")
            {
                MessageBox.Show("Kelime Bulunamadı. Lutfen geçerli bir kelime giriniz.");
            }
            else
            {
                if (sorgu)
                {
                    MessageBox.Show(txtKelime.Text + " kelimesinin yeni degerlerini giriniz.");
                }
                else if(!sorgu){
                    MessageBox.Show("Aranan Kelime bulunamadi.Lutfen gecerli bir kelime girin.");
                }
                
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void TxtCumle_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }
    }
}
