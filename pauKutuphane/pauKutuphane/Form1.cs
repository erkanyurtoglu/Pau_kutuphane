using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pauKutuphane
{
    public partial class girisEkranFrm : Form
    {
        public girisEkranFrm()
        {
            InitializeComponent();
        }

        private void btn_personelGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txt_pKullaniciAd.Text;
            string sifre = txt_pSifre.Text;

            SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True");

            try
            {
                baglanti.Open();
                string query = "SELECT COUNT(*) FROM TBLPERSONEL WHERE kullaniciAdi = @kullaniciAdi AND sifre = @sifre";
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);

                int userCount = (int)komut.ExecuteScalar();

                if (userCount > 0)
                {
                    adminAnaSayfa adminSayfa = new adminAnaSayfa();
                    adminSayfa.Show();
                    this.Hide();
                    adminSayfa.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btn_kullaniciGiris_Click(object sender, EventArgs e)
        {
            string email = txt_kKullaniciAd.Text;
            string tc = txt_kSifre.Text;

            SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=icisleriKutuphanesi;Integrated Security=True");

            try
            {
                baglanti.Open();
                string query = "SELECT COUNT(*) FROM TBLUYELER WHERE uyeEmail = @uyeEmail AND uyeTcKimlik = @uyeTcKimlik";
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@uyeEmail", email);
                komut.Parameters.AddWithValue("@uyeTcKimlik", tc);

                int userCount = (int)komut.ExecuteScalar();

                if (userCount > 0)
                {
                    UyeAnaEkranFrm uyeanasayfa = new UyeAnaEkranFrm(tc);
                    uyeanasayfa.Show();
                    this.Hide();
                    uyeanasayfa.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Email veya TC yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
