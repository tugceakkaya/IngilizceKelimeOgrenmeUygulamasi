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
    public partial class KelimeSil : Form
    {
        public KelimeSil()
        {
            InitializeComponent();
        }
        KelimeDatabase kelimeDatabase = new KelimeDatabase();
        private void BtnSil_Click(object sender, EventArgs e)
        {
            bool sorgu = kelimeDatabase.KelimeAra(txtKelime.Text);
            if (txtKelime.Text == string.Empty)
            {
                MessageBox.Show("Hatalı kelime girdiniz.Lutfen tekrar deneyiniz.");
            }
            else
            {
                if (sorgu)
                {
                    kelimeDatabase.KelimeSil(txtKelime.Text);
                    MessageBox.Show("Kelime silme işlemi tamamlandı");
                }
                else if (!sorgu)
                {
                    MessageBox.Show("Aranan Kelime bulunamadi.Lutfen gecerli bir kelime girin.");
                }
                
            }

            txtKelime.Text = "";
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
