using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KelimeOgrenme
{
    public class KelimeDatabase
    {
        public string Mesaj { get; set; }
        public KelimeDatabase()
        {
            this.Mesaj = "";
        }

        SqlConnection baglanti = new SqlConnection("Data Source=NESSS\\SQLEXPRESS;Initial Catalog=Kelimeler;Integrated Security=True");
        public bool KelimeKontrol(string sorulanKelime,string girilenCevap)
        {
            bool sorgu = false;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from tbl_Kelime where Soru=@Soru", baglanti);
            komut.Parameters.AddWithValue("@Soru", sorulanKelime);

            SqlDataReader rdr = komut.ExecuteReader();

            while (rdr.Read())
            {
                Kelime.dogruCevap = rdr["Cevap"].ToString();
                Kelime.Soru = rdr["Soru"].ToString();
                Kelime.Tur = rdr["Tur"].ToString();
                Kelime.Cumle = rdr["Cumle"].ToString();

                if (girilenCevap == rdr["Cevap"].ToString())
                {
                    sorgu = true;

                }
                else if (girilenCevap != rdr["Cevap"].ToString())
                {
                    sorgu = false;

                }

            }


            baglanti.Close();
            return sorgu;

        }
        public void AsamaNoArttir(string Cevap)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Update tbl_Kelime Set asamaNo +=1 where Cevap=@Cevap", baglanti);
            cmd.Parameters.AddWithValue("@Cevap", Cevap);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
        public void AsamaNoAzalt(string Cevap)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Update tbl_Kelime Set asamaNo =1 where Cevap=@Cevap", baglanti);
            cmd.Parameters.AddWithValue("@Cevap", Cevap);
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
        public void TarihGuncelle(string Cevap)
        {
            int asamaNo = 0;
            string tarih = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select asamaNo,Tarih,Cevap from tbl_Kelime where Cevap=@Cevap", baglanti);
            komut.Parameters.AddWithValue("@Cevap", Cevap);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                asamaNo = int.Parse(oku["asamaNo"].ToString());
            }
            if (asamaNo == 0)
            {
                tarih = DateTime.Now.AddDays(1).ToShortDateString();
            }
            else if (asamaNo == 1)
            {
                tarih = DateTime.Now.AddDays(6).ToShortDateString();
            }
            else if (asamaNo == 2)
            {
                tarih = DateTime.Now.AddDays(23).ToShortDateString();
            }
            else if (asamaNo == 3)
            {
                tarih = DateTime.Now.AddDays(150).ToShortDateString();
            }
            else if (asamaNo >= 4)
            {
                this.Mesaj = "Tebrikler Bu soruyu öğrendiniz";
            }

            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Update tbl_Kelime Set Tarih=@Tarih where Cevap=@Cevap", baglanti);
            komut2.Parameters.AddWithValue("@Cevap", Cevap);
            komut2.Parameters.AddWithValue("@Tarih", tarih);
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }
        public void SoruGetir()
        {

            string tarih = "";

            tarih = DateTime.Now.ToShortDateString();
            baglanti.Open();


            SqlCommand komut = new SqlCommand("Select Tarih,Soru,Cevap from tbl_Kelime Order By NewID()", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                if (tarih == oku["Tarih"].ToString())
                {

                    Kelime.Soru = oku["Soru"].ToString();
                    Kelime.dogruCevap = oku["Cevap"].ToString();
                }

            }
            baglanti.Close();

        }

        public void KelimeEkle(string _kelime, string Anlam, string Tur, string Cumle)
        {
            string tarih = "";
            int SonKayitID = 0;
            tarih = DateTime.Now.ToShortDateString();
            int asamaNo = 0;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from tbl_Kelime", baglanti);

            SonKayitID = Convert.ToInt32(cmd.ExecuteScalar());
            SonKayitID++;
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_Kelime (Id,Soru,Cevap,Tur,Cumle,asamaNo,Tarih) values (@Id,@Soru,@Cevap,@Tur,@Cumle,@asamaNo,@Tarih)", baglanti);
            komut.Parameters.AddWithValue("@Id", SonKayitID);
            komut.Parameters.AddWithValue("@Soru", _kelime);
            komut.Parameters.AddWithValue("@Cevap", Anlam);
            komut.Parameters.AddWithValue("@Tur", Tur);
            komut.Parameters.AddWithValue("@Cumle", Cumle);
            komut.Parameters.AddWithValue("@asamaNo", asamaNo);
            komut.Parameters.AddWithValue("@Tarih", tarih);
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public void KelimeSil(string Kelime)
        {
            baglanti.Open();
           
            SqlCommand komut = new SqlCommand("Delete from tbl_Kelime where Soru=@Soru", baglanti);
            komut.Parameters.AddWithValue("@Soru", Kelime);
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public void KelimeGuncelle(string _kelime, string Anlam, string Tur, string Cumle)
        {
            baglanti.Open();
            string sql = "Update tbl_Kelime Set Cevap=@Cevap,Tur=@Tur,Cumle=@Cumle where Soru=@Soru";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@Soru", _kelime);
            komut.Parameters.AddWithValue("@Tur", Tur);
            komut.Parameters.AddWithValue("@Cumle", Cumle);
            komut.Parameters.AddWithValue("@Cevap", Anlam);
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public List<string> Istatiktistik(int ay,string yil)
        {
            List<string> aylikKelimeler = new List<string>();

            string aylikVeriler;

            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from tbl_Kelime where asamaNo=4 ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                DateTime tarih = Convert.ToDateTime(oku["Tarih"].ToString());

                if(tarih.Month == ay && tarih.Year == int.Parse(yil))
                {
                    aylikVeriler = "";
                
                    aylikVeriler += oku["Soru"].ToString()+" ";
                  

                    aylikKelimeler.Add(aylikVeriler);
                }
                
            }

            return aylikKelimeler;

        }

        public List<string> Istatiktistik(string yil)
        {
            List<string> yillikKelimeler = new List<string>();

            string yillikVeriler;


            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from tbl_Kelime where asamaNo=4 ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                DateTime tarih = Convert.ToDateTime(oku["Tarih"].ToString());

                if (tarih.Year == int.Parse(yil))
                {
                    yillikVeriler = "";
                   
                    yillikVeriler += oku["Soru"].ToString() + " ";
                    
                    yillikKelimeler.Add(yillikVeriler);
                }

            }

            return yillikKelimeler;

        }
        public bool KelimeAra(string _kelime)
        {
            bool sorgu = false;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from tbl_Kelime where Soru like '%" + _kelime + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                if (_kelime == oku["Soru"].ToString())
                {
                    sorgu = true;
                }
                else
                {
                    sorgu = false;
                }
            }
            baglanti.Close();
            return sorgu;
        }
    }



}

