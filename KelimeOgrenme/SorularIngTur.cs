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
    public partial class SorularIngTur : Form
    {
        public SorularIngTur()
        {
            InitializeComponent();
        }
        KelimeDatabase kelimeDataBase = new KelimeDatabase();

        int sorusayisi = 0;
        private void SorularIngTur_Load(object sender, EventArgs e)
        {
            pnlCevplar.Visible = false;
            btnSonrakiSoru.Enabled = false;
            SoruGetir();
        }

        int dogrusayisi = 0, yanlissayisi = 0, puan = 0;

     

        private void BtnAnaEkran_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Ana Ekrana Dönmek istediğinize emin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (cikis == DialogResult.Yes)
            {
                KelimeOgrenmeAnaEkran anaEkran = new KelimeOgrenmeAnaEkran();
                this.Hide();
                anaEkran.Show();

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

        private void BtnSonrakiSoru_Click(object sender, EventArgs e)
        {
            pnlCevplar.Visible = false;
            txtCevap.Text = "";
            lblSoruYazdir.Text = "";
            lblSoruId.Text = "";
            lblTur.Text = "";
            lblCumle.Text = "";
            lblSoru.Text = "";

            SoruGetir();
        }

        private void BtnKontrol_Click(object sender, EventArgs e)
        {
            if (txtCevap.Text ==string.Empty)
            {
                MessageBox.Show("Hatalı kelime girdiniz.Lutfen tekrar deneyiniz.");
            }
            else
            {
                bool kontrol = kelimeDataBase.KelimeKontrol(lblSoru.Text,txtCevap.Text);
                if (kontrol)
                {
                    dogrusayisi++;
                    puan += 10;
                    lblDogruSayisi.Text = dogrusayisi.ToString();
                    lblPuan.Text = puan.ToString();
                    kelimeDataBase.AsamaNoArttir(lblCevapYazdir.Text);
                    
                }
                else if(!kontrol)
                {
                    yanlissayisi++;
                    lblYanlisSayisi.Text = yanlissayisi.ToString();
                    kelimeDataBase.AsamaNoAzalt(lblCevapYazdir.Text);
                    
                }
                lblTur.Text = Kelime.Tur;
                lblSoruYazdir.Text = Kelime.Soru;
                lblCevapYazdir.Text = Kelime.dogruCevap;
                lblCumle.Text = Kelime.Cumle;
                pnlCevplar.Visible = true;
                kelimeDataBase.TarihGuncelle(lblCevapYazdir.Text);
                if (kelimeDataBase.Mesaj != "")
                {
                    MessageBox.Show(kelimeDataBase.Mesaj);

                }

                
            }
            btnSonrakiSoru.Enabled = true;
            
        }

        private void SoruGetir()
        {
     
            kelimeDataBase.SoruGetir();
          

            if (lblCevapYazdir.Text == Kelime.dogruCevap)
            {
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Bugunki kelimeleri çözdünüz.Ana Ekrana dönmek ister misiniz?","Bilgilendirme",MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cikis == DialogResult.Yes)
                {
                    KelimeOgrenmeAnaEkran anaEkran = new KelimeOgrenmeAnaEkran();
                    this.Hide();
                    anaEkran.Show();

                }

            }
            sorusayisi++;
            lblSoruId.Text = sorusayisi.ToString();
            lblSoru.Text = Kelime.Soru;
            lblCevapYazdir.Text = Kelime.dogruCevap;
            btnSonrakiSoru.Enabled = false;

        }


    }
}
