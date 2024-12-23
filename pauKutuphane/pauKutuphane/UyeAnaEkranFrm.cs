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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace pauKutuphane
{
    public partial class UyeAnaEkranFrm : Form
    {
        private string _uyeTcKimlik;
        private string _uyeAdSoyad;
        private string _uyeTelefon;
        private string _uyeEmail;

        public UyeAnaEkranFrm(string uyeTcKimlik)
        {
            InitializeComponent();
            _uyeTcKimlik = uyeTcKimlik;
        }

        SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True");
        DataSet daset = new DataSet();

        private void UyeAnaEkranFrm_Load(object sender, EventArgs e)
        {
            UyebilgileriniGetir();
            KitapListele();
            sepetlistele();
            kitapsayisi();
        }

        private void UyebilgileriniGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLUYELER where uyeTcKimlik = @uyeTcKimlik", baglanti);
            komut.Parameters.AddWithValue("@uyeTcKimlik", _uyeTcKimlik);
            SqlDataReader read = komut.ExecuteReader();

            if (read.Read())
            {
                _uyeAdSoyad = read["uyeAdSoyad"].ToString();
                _uyeTelefon = read["uyeTelefon"].ToString();
                _uyeEmail = read["uyeEmail"].ToString();
            }
            baglanti.Close();
        }

        private void kitapsayisi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(kitapSayisi) from TBLREZERVESEPET", baglanti);
            lblSepettekiKitap.Text = komut.ExecuteScalar().ToString();
            baglanti.Close();
        }

        private void KitapListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLKITAPLAR", baglanti);
            adtr.Fill(daset, "TBLKITAPLAR");
            dataGridKitaplar.DataSource = daset.Tables["TBLKITAPLAR"];
            baglanti.Close();
        }

        private void sepetlistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLREZERVESEPET", baglanti);
            adtr.Fill(daset, "TBLREZERVESEPET");
            dgridSepet.DataSource = daset.Tables["TBLREZERVESEPET"];
            baglanti.Close();
        }

        private void btnSepetEkle_Click(object sender, EventArgs e)
        {
            // Gerekli alanların dolu olup olmadığını kontrol edin
            if (string.IsNullOrWhiteSpace(txtdemirbas.Text) ||
                string.IsNullOrWhiteSpace(txteser.Text) ||
                string.IsNullOrWhiteSpace(txtyazar.Text) ||
                string.IsNullOrWhiteSpace(txtyayinlayan.Text) ||
                string.IsNullOrWhiteSpace(txtfizikselNiteleme.Text) ||
                string.IsNullOrWhiteSpace(txtBoxKitapSayi.Text))
            {
                MessageBox.Show("Lütfen geçerli alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLREZERVESEPET(kitapAdi, yazarAdi, yayineviAdi, sayfaSayisi, kitapSayisi, " +
                "barkodNo, teslimTarihi, iadeTarihi) values(@kitapAdi, @yazarAdi, @yayineviAdi, @sayfaSayisi, @kitapSayisi, " +
                "@barkodNo, @teslimTarihi, @iadeTarihi)", baglanti);
            komut.Parameters.AddWithValue("@kitapAdi", txteser.Text);
            komut.Parameters.AddWithValue("@yazarAdi", txtyazar.Text);
            komut.Parameters.AddWithValue("@yayineviAdi", txtyayinlayan.Text);
            komut.Parameters.AddWithValue("@sayfaSayisi", txtfizikselNiteleme.Text);
            komut.Parameters.AddWithValue("@kitapSayisi", int.Parse(txtBoxKitapSayi.Text));
            komut.Parameters.AddWithValue("@barkodNo", txtdemirbas.Text);
            komut.Parameters.AddWithValue("@teslimTarihi", dtpTeslimTarih.Value);
            komut.Parameters.AddWithValue("@iadeTarihi", dtpİadeTarih.Value);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sepete Ekleme Başarılı", "Ekleme İşlemi");
            daset.Tables["TBLREZERVESEPET"].Clear();
            sepetlistele();
            lbl_sepettekiKitapSayi.Text = "";
            kitapsayisi();

            foreach (Control item in this.Controls)
            {
                if (item is TextBox && item != txtBoxKitapSayi)
                {
                    item.Text = "";
                }
            }
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            if (lbl_sepettekiKitapSayi.Text != "")
            {
                if (int.Parse(lbl_sepettekiKitapSayi.Text) <= 3)
                {
                    for (int i = 0; i < dgridSepet.Rows.Count - 1; i++)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("insert into TBLREZERVEKITAP(tcNumarasi, adSoyad, telefon, email, kitapAdi, yazarAdi, yayineviAdi, sayfaSayisi, kitapSayisi, " +
                            "barkodNo, teslimTarihi, iadeTarihi) values(@tcNumarasi, @adSoyad, @telefon, @email, @kitapAdi, @yazarAdi, @yayineviAdi, @sayfaSayisi, @kitapSayisi, " +
                            "@barkodNo, @teslimTarihi, @iadeTarihi)", baglanti);

                        komut.Parameters.AddWithValue("@tcNumarasi", _uyeTcKimlik);
                        komut.Parameters.AddWithValue("@adSoyad", _uyeAdSoyad);
                        komut.Parameters.AddWithValue("@telefon", _uyeTelefon);
                        komut.Parameters.AddWithValue("@email", _uyeEmail);
                        komut.Parameters.AddWithValue("@kitapAdi", dgridSepet.Rows[i].Cells["kitapAdi"].Value.ToString());
                        komut.Parameters.AddWithValue("@yazarAdi", dgridSepet.Rows[i].Cells["yazarAdi"].Value.ToString());
                        komut.Parameters.AddWithValue("@yayineviAdi", dgridSepet.Rows[i].Cells["yayineviAdi"].Value.ToString());
                        komut.Parameters.AddWithValue("@sayfaSayisi", dgridSepet.Rows[i].Cells["sayfaSayisi"].Value.ToString());
                        komut.Parameters.AddWithValue("@kitapSayisi", int.Parse(dgridSepet.Rows[i].Cells["kitapSayisi"].Value.ToString()));
                        komut.Parameters.AddWithValue("@barkodNo", dgridSepet.Rows[i].Cells["barkodNo"].Value.ToString());
                        komut.Parameters.AddWithValue("@teslimTarihi", DateTime.Parse(dgridSepet.Rows[i].Cells["teslimTarihi"].Value.ToString()));
                        komut.Parameters.AddWithValue("@iadeTarihi", DateTime.Parse(dgridSepet.Rows[i].Cells["iadeTarihi"].Value.ToString()));
                        komut.ExecuteNonQuery();

                        SqlCommand komut2 = new SqlCommand("update TBLUYELER set okunanKitap = okunanKitap + @kitapSayisi where uyeTcKimlik = @uyeTcKimlik", baglanti);
                        komut2.Parameters.AddWithValue("@kitapSayisi", int.Parse(dgridSepet.Rows[i].Cells["kitapSayisi"].Value.ToString()));
                        komut2.Parameters.AddWithValue("@uyeTcKimlik", _uyeTcKimlik);
                        komut2.ExecuteNonQuery();

                        SqlCommand komut3 = new SqlCommand("update TBLKITAPLAR set kopya = kopya - @kitapSayisi where barkodNo = @barkodNo", baglanti);
                        komut3.Parameters.AddWithValue("@kitapSayisi", int.Parse(dgridSepet.Rows[i].Cells["kitapSayisi"].Value.ToString()));
                        komut3.Parameters.AddWithValue("@barkodNo", dgridSepet.Rows[i].Cells["barkodNo"].Value.ToString());
                        komut3.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    baglanti.Open();
                    SqlCommand komut4 = new SqlCommand("delete from TBLREZERVESEPET", baglanti);
                    komut4.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kitap rezervasyonu yapıldı.");
                    daset.Tables["TBLREZERVESEPET"].Clear();
                    sepetlistele();
                    lbl_sepettekiKitapSayi.Text = "";
                    kitapsayisi();
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

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            // Sepette herhangi bir ürün olup olmadığını kontrol edin
            if (dgridSepet.Rows.Count == 0)
            {
                MessageBox.Show("Lütfen sepete ürün ekleyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Eğer bir satır seçilmemişse uyarı verin
            if (dgridSepet.CurrentRow == null)
            {
                MessageBox.Show("Sepette ürün bulunmamaktadır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from TBLREZERVESEPET where barkodNo like @barkodNo", baglanti);
            komut.Parameters.AddWithValue("@barkodNo", dgridSepet.CurrentRow.Cells["barkodNo"].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi yapıldı", "Silme işlemi");
            daset.Tables["TBLREZERVESEPET"].Clear();
            sepetlistele();
            lbl_sepettekiKitapSayi.Text = "";
            kitapsayisi();
        }

        private void txtBoxBarkodNo_TextChanged(object sender, EventArgs e)
        {
            // Barkod numarası boş değilse
            if (!string.IsNullOrEmpty(txtdemirbas.Text))
            {
                // Veritabanına bağlanıyoruz
                baglanti.Open();

                // Barkod numarasına göre kitap bilgilerini sorguluyoruz
                SqlCommand komut = new SqlCommand("SELECT * FROM kitaplar WHERE demirbas = @demirbas", baglanti);
                komut.Parameters.AddWithValue("@demirbas", txtdemirbas.Text);
                SqlDataReader read = komut.ExecuteReader();

                // Kitap bilgilerini okuyoruz
                if (read.Read())
                {
                    txteser.Text = read["eser"].ToString();
                    txtyazar.Text = read["yazar"].ToString();
                    txtyayinlayan.Text = read["yayinlayan"].ToString();
                    txtfizikselNiteleme.Text = read["fizikselNiteleme"].ToString();
                    txtBoxKitapSayi.Text = "1"; // Varsayılan kitap sayısı 1 olarak ayarlanır
                }
                else
                {
                    // Kitap bulunamazsa, ilgili textBox'ları temizle
                    txteser.Text = "";
                    txtyazar.Text = "";
                    txtyayinlayan.Text = "";
                    txtfizikselNiteleme.Text = "";
                    txtBoxKitapSayi.Text = "1";
                }

                // Veritabanı bağlantısını kapatıyoruz
                baglanti.Close();
            }
            else
            {
                // Barkod numarası boşsa, ilgili textBox'ları temizle
                txteser.Text = "";
                txtyazar.Text = "";
                txtyayinlayan.Text = "";
                txtfizikselNiteleme.Text = "";
                txtBoxKitapSayi.Text = "1";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitaplar where eser like '%" + textBox1.Text + "%'", baglanti);
            adtr.Fill(daset, "kitaplar");
            baglanti.Close();
            if (textBox1.Text == "")
            {
                daset.Tables["kitaplar"].Clear();
                KitapListele();
            }
        }

        private void txtboxYazarAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitaplar where yazar like '%" + txtboxYazarAra.Text + "%'", baglanti);
            adtr.Fill(daset, "kitaplar");
            baglanti.Close();
            if (txtboxYazarAra.Text == "")
            {
                daset.Tables["kitaplar"].Clear();
                KitapListele();
            }
        }
    }
}
