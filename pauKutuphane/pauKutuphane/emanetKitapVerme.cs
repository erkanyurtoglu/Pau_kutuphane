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
    public partial class emanetKitapVerme : Form
    {
        public emanetKitapVerme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True");
        DataSet daset = new DataSet();

        private void btn_anasayfaDon_Click(object sender, EventArgs e)
        {
            adminAnaSayfa adminAnaSayfa = new adminAnaSayfa();
            adminAnaSayfa.Show();
            this.Hide();
            adminAnaSayfa.FormClosed += (s, args) => this.Close();
        }

        private void emanetKitapVerme_Load(object sender, EventArgs e)
        {
            sepetListele();
            kitapsayisi();
        }

        private void kitapsayisi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT SUM(kitapSayisi) FROM TBLSEPET", baglanti);
            kayitliKitapSayi.Text = komut.ExecuteScalar().ToString();
            baglanti.Close();
        }


        private void sepetListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM TBLSEPET", baglanti);
            adtr.Fill(daset, "TBLSEPET");
            dataGridView1.DataSource = daset.Tables["TBLSEPET"];
            baglanti.Close();
        }

        private void btn_sepeteEkle_Click(object sender, EventArgs e)
        {
            // grp_UyeBilgi ve grp_kitapBilgi içindeki TextBox'ları kontrol et
            bool hasUyeBilgi = grp_UyeBilgi.Controls.OfType<TextBox>().Any(txt => !string.IsNullOrWhiteSpace(txt.Text));
            bool hasKitapBilgi = grp_kitapBilgi.Controls.OfType<TextBox>().Any(txt => !string.IsNullOrWhiteSpace(txt.Text));

            // Eğer grp_UyeBilgi veya grp_kitapBilgi içindeki TextBox'lardan herhangi biri boşsa uyarı göster
            if (!hasUyeBilgi || !hasKitapBilgi)
            {
                MessageBox.Show("Üye bilgileri veya kitap bilgileri eksik. Her iki grup bilgi de doldurulmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            // TC kimlik numarasının geçerliliğini kontrol et
            if (string.IsNullOrWhiteSpace(txt_tcAra.Text) || !IsTcKimlikNoValid(txt_tcAra.Text))
            {
                MessageBox.Show("Geçerli bir T.C. kimlik numarası girilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            // Demirbaş numarasının geçerliliğini kontrol et
            if (string.IsNullOrWhiteSpace(txt_demirbas.Text))
            {
                MessageBox.Show("Geçerli bir barkod numarası girilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            // Kitap sayısını her zaman 1 yap
            int kitapSayisi = 1;

            using (SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO TBLSEPET (kitapAdi, yazarAdi, yayineviAdi, sayfaSayisi, kitapSayisi, " +
                    "barkodNo, teslimTarihi, iadeTarihi) VALUES (@kitapAdi, @yazarAdi, @yayineviAdi, @sayfaSayisi, @kitapSayisi, " +
                    "@barkodNo, @teslimTarihi, @iadeTarihi)", baglanti);
                komut.Parameters.AddWithValue("@kitapAdi", txt_eser.Text);
                komut.Parameters.AddWithValue("@yazarAdi", txt_yazar.Text);
                komut.Parameters.AddWithValue("@yayineviAdi", txt_yayinlayan.Text);
                komut.Parameters.AddWithValue("@sayfaSayisi", txt_fizikselNiteleme.Text);
                komut.Parameters.AddWithValue("@kitapSayisi", kitapSayisi); // Sabit 1 değerini kullan
                komut.Parameters.AddWithValue("@barkodNo", txt_demirbas.Text);
                komut.Parameters.AddWithValue("@teslimTarihi", dtp_teslimTarihi.Value.ToString("yyyy-MM-dd"));
                komut.Parameters.AddWithValue("@iadeTarihi", dtp_iadeTarihi.Value.ToString("yyyy-MM-dd"));
                komut.ExecuteNonQuery();
                baglanti.Close();
            }

            MessageBox.Show("Sepete Ekleme Başarılı", "Ekleme İşlemi");

            // Sepet listeleme ve sıfırlama işlemleri
            daset.Tables["TBLSEPET"].Clear();
            sepetListele();
            kayitliKitapSayi.Text = "";
            kitapsayisi();

            // grp_kitapBilgi içindeki TextBox'ları temizle
            foreach (Control item in grp_kitapBilgi.Controls)
            {
                if (item is TextBox && item != txt_kitapSayisi)
                {
                    item.Text = "";
                }
            }
        }


        private bool IsTcKimlikNoValid(string tcKimlikNo)
        {
       
            if (tcKimlikNo.Length != 11 || !tcKimlikNo.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        private void txt_tcAra_TextChanged(object sender, EventArgs e)
        {
            if (txt_tcAra.Text.Length == 11)
            {
                using (SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True"))
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM TBLUYELER WHERE uyeTcKimlik = @uyeTcKimlik", baglanti);
                    komut.Parameters.Add("@uyeTcKimlik", SqlDbType.NVarChar).Value = txt_tcAra.Text;

                    SqlDataReader read = komut.ExecuteReader();
                    if (read.Read())
                    {
                        txt_adSoyad.Text = read["uyeAdSoyad"].ToString();
                        txt_telefon.Text = read["uyeTelefon"].ToString();
                        txt_email.Text = read["uyeEmail"].ToString();
                    }
                    else
                    {
                        ClearTextBoxes();
                        MessageBox.Show("Girilen TC kimlik numarasıyla eşleşen bir üye bulunamadı.", "Üye Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (txt_tcAra.Text.Length == 0)
            {
                ClearTextBoxes();
            }
        }

        private void ClearTextBoxes()
        {
            foreach (Control control in grp_UyeBilgi.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
        }

        private void txt_demirbas_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_demirbas.Text))
            {
                foreach (Control item in grp_kitapBilgi.Controls)
                {
                    if (item is TextBox && item != txt_demirbas)
                    {
                        item.Text = "";
                    }
                }
                return;
            }

            using (SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM TBLKITAPLAR WHERE barkodNo = @barkodNo", baglanti);
                komut.Parameters.AddWithValue("@barkodNo", txt_demirbas.Text);
                SqlDataReader read = komut.ExecuteReader();

                if (read.Read())
                {
                    txt_eser.Text = read["kitapAdi"].ToString();
                    txt_yazar.Text = read["yazar"].ToString();
                    txt_yayinlayan.Text = read["yayinlayan"].ToString();
                    txt_fizikselNiteleme.Text = read["fizikselNiteleme"].ToString();
                }
                else
                {
                    foreach (Control item in grp_kitapBilgi.Controls)
                    {
                        if (item is TextBox && item != txt_demirbas)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            // Eğer dataGridView'da seçili satır yoksa uyarı ver
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Silinecek bir ürün seçilmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            // Seçili satır varsa, silme işlemini gerçekleştir
            SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True");
            baglanti.Open();

            SqlCommand komut = new SqlCommand("DELETE FROM TBLSEPET WHERE barkodNo LIKE @barkodNo", baglanti);
            komut.Parameters.AddWithValue("@barkodNo", dataGridView1.CurrentRow.Cells["barkodNo"].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Silme işlemi yapıldı", "Silme İşlemi");

            daset.Tables["TBLSEPET"].Clear();
            sepetListele();
            kayitliKitapSayi.Text = "";
            kitapsayisi();
        }

        private void btn_teslimEt_Click(object sender, EventArgs e)
        {
            if (kayitliKitapSayi.Text != "")
            {
                if (int.Parse(kayitliKitapSayi.Text) <= 3)
                {
                    if (txt_tcAra.Text != "" && txt_adSoyad.Text != "" && txt_telefon.Text != "" && txt_email.Text != "")
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            baglanti.Open();
                            SqlCommand komut = new SqlCommand("INSERT INTO TBLEMANETKITAP (tcNumarasi, adSoyad, telefon, email, kitapAdi, yazarAdi, yayineviAdi, sayfaSayisi, kitapSayisi, " +
                                "barkodNo, teslimTarihi, iadeTarihi) VALUES (@tcNumarasi, @adSoyad, @telefon, @email, @kitapAdi, @yazarAdi, @yayineviAdi, @sayfaSayisi, @kitapSayisi, " +
                                "@barkodNo, @teslimTarihi, @iadeTarihi)", baglanti);

                            komut.Parameters.AddWithValue("@tcNumarasi", txt_tcAra.Text);
                            komut.Parameters.AddWithValue("@adSoyad", txt_adSoyad.Text);
                            komut.Parameters.AddWithValue("@telefon", txt_telefon.Text);
                            komut.Parameters.AddWithValue("@email", txt_email.Text);
                            komut.Parameters.AddWithValue("@kitapAdi", dataGridView1.Rows[i].Cells["kitapAdi"].Value.ToString());
                            komut.Parameters.AddWithValue("@yazarAdi", dataGridView1.Rows[i].Cells["yazarAdi"].Value.ToString());
                            komut.Parameters.AddWithValue("@yayineviAdi", dataGridView1.Rows[i].Cells["yayineviAdi"].Value.ToString());
                            komut.Parameters.AddWithValue("@sayfaSayisi", dataGridView1.Rows[i].Cells["sayfaSayisi"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapSayisi", 1); // Kitap sayısını her zaman 1 yap
                            komut.Parameters.AddWithValue("@barkodNo", dataGridView1.Rows[i].Cells["barkodNo"].Value.ToString());
                            komut.Parameters.AddWithValue("@teslimTarihi", dataGridView1.Rows[i].Cells["teslimTarihi"].Value.ToString());
                            komut.Parameters.AddWithValue("@iadeTarihi", dataGridView1.Rows[i].Cells["iadeTarihi"].Value.ToString());
                            komut.ExecuteNonQuery();

                            SqlCommand komut2 = new SqlCommand("UPDATE TBLUYELER SET okunanKitap = okunanKitap + 1 WHERE uyeTcKimlik = @uyeTcKimlik", baglanti);
                            komut2.Parameters.AddWithValue("@uyeTcKimlik", txt_tcAra.Text);
                            komut2.ExecuteNonQuery();

                            SqlCommand komut3 = new SqlCommand("UPDATE TBLKITAPLAR SET kopya = kopya - 1 WHERE barkodNo = @barkodNo", baglanti);
                            komut3.Parameters.AddWithValue("@barkodNo", dataGridView1.Rows[i].Cells["barkodNo"].Value.ToString());
                            komut3.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("DELETE FROM TBLSEPET", baglanti);
                        komut4.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kitaplar teslim edildi.");
                        daset.Tables["TBLSEPET"].Clear();
                        sepetListele();
                        txt_tcAra.Text = "";
                        kayitliKitapSayi.Text = "";
                        kitapsayisi();
                    }
                    else
                    {
                        MessageBox.Show("Üye bilgilerinin doldurulması zorunludur.", "Uyarı");
                    }
                }
                else
                {
                    MessageBox.Show("Bir kişiye en fazla 3 kitap verilebilir.", "Uyarı");
                }
            }
            else
            {
                MessageBox.Show("Sepete eklenmiş kitap bulunmamaktadır.", "Uyarı");
            }
        }
    }
}
