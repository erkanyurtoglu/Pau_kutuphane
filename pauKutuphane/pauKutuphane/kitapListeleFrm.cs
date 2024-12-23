using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pauKutuphane
{
    public partial class kitapListeleFrm : Form
    {
        public kitapListeleFrm()
        {
            InitializeComponent();
        }

        private SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True");
        private DataSet daset = new DataSet();
        private string connectionString = "Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True";


        private void kitapListeleFrm_Load_1(object sender, EventArgs e)
        {
            kitapListele();
        }

        private void kitapListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM TBLKITAPLAR", baglanti);
            daset.Tables.Clear(); // Önceki verileri temizle
            adtr.Fill(daset, "TBLKITAPLAR");
            kitapListeleEkran.DataSource = daset.Tables["TBLKITAPLAR"];
            baglanti.Close();
        }


        private void btn_anasayfaDon_Click(object sender, EventArgs e)
        {
            adminAnaSayfa adminAnaSayfa = new adminAnaSayfa();
            adminAnaSayfa.Show();
            this.Hide();
            adminAnaSayfa.FormClosed += (s, args) => this.Close();
        }

        private void btn_kitapGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_barkodNo.Text))
            {
                MessageBox.Show("Lütfen barkod numarasını giriniz.", "Eksik Alan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Buton tıklama işlemini iptal et
            }

            string barkodNo = txt_barkodNo.Text;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("SELECT kitapAdi FROM TBLKITAPLAR WHERE barkodNo = @barkodNo", baglanti);
                komut.Parameters.AddWithValue("@barkodNo", barkodNo);

                SqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {
                    read.Close(); // Okuma işlemi tamamlandıktan sonra kapat

                    SqlCommand updateCommand = new SqlCommand("UPDATE TBLKITAPLAR SET kitapAdi = @kitapAdi, yazar = @yazar, yayinlayan = @yayinlayan, " +
                        "yayinYeri = @yayinYeri, isbn = @isbn, yerNumarasi = @yerNumarasi WHERE barkodNo = @barkodNo", baglanti);

                    updateCommand.Parameters.AddWithValue("@kitapAdi", txt_Eser.Text);
                    updateCommand.Parameters.AddWithValue("@yazar", txt_Yazar.Text);
                    updateCommand.Parameters.AddWithValue("@yayinlayan", txt_Yayinlayan.Text);
                    updateCommand.Parameters.AddWithValue("@yayinYeri", txt_YayinYeri.Text);
                    updateCommand.Parameters.AddWithValue("@isbn", txt_isbnNo.Text);
                    updateCommand.Parameters.AddWithValue("@yerNumarasi", txt_yerNumarasi.Text);
                    updateCommand.Parameters.AddWithValue("@barkodNo", barkodNo);

                    updateCommand.ExecuteNonQuery();

                    daset.Tables["TBLKITAPLAR"].Clear();
                    kitapListele();

                    MessageBox.Show("Güncelleme İşlemi Başarılı");
                    ClearTextBoxes();
                    ClearRichTextBoxes();
                    ClearComboBoxes();
                }
                else
                {
                    MessageBox.Show("Belirtilen barkod numarasıyla kitap bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBoxes();
                }
            }
        }

        private void btn_kitapSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_barkodNo.Text))
            {
                MessageBox.Show("Lütfen barkod numarasını giriniz.", "Eksik Alan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Buton tıklama işlemini iptal et
            }

            string barkodNo = txt_barkodNo.Text;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("SELECT kitapAdi FROM TBLKITAPLAR WHERE barkodNo = @barkodNo", baglanti);
                komut.Parameters.AddWithValue("@barkodNo", barkodNo);

                SqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {
                    string kitapAdi = read["kitapAdi"].ToString();
                    read.Close();

                    DialogResult dialogResult = MessageBox.Show($"{kitapAdi} isimli kitabı silmek istediğinizden emin misiniz?", "Kitap Silme", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string password = Microsoft.VisualBasic.Interaction.InputBox("Şifrenizi girin:", "Şifre Doğrulama", "");

                        if (password == "1234")
                        {
                            SqlCommand deleteCommand = new SqlCommand("DELETE FROM TBLKITAPLAR WHERE barkodNo = @barkodNo", baglanti);
                            deleteCommand.Parameters.AddWithValue("@barkodNo", barkodNo);
                            deleteCommand.ExecuteNonQuery();

                            MessageBox.Show("Silme İşlemi Başarılı");

                            daset.Tables["TBLKITAPLAR"].Clear();
                            kitapListele();
                            ClearTextBoxes();
                            ClearRichTextBoxes();
                            ClearComboBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Yanlış şifre. Silme işlemi iptal edildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearTextBoxes();
                            ClearRichTextBoxes();
                            ClearComboBoxes();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Belirtilen barkod numarasıyla kitap bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBoxes();
                }
            }
        }

        private void txt_barkodAra_TextChanged(object sender, EventArgs e)
        {
            DataView dv = daset.Tables["TBLKITAPLAR"].DefaultView;
            dv.RowFilter = string.Format("barkodNo LIKE '%{0}%'", txt_barkodAra.Text);
            kitapListeleEkran.DataSource = dv;
        }

        private void txt_barkodNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_barkodNo.Text))
            {
                foreach (Control item in Controls)
                {
                    if (item is TextBox && item != txt_barkodNo)
                    {
                        item.Text = "";
                    }
                }
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM TBLKITAPLAR WHERE barkodNo = @barkodNo", baglanti);
                komut.Parameters.AddWithValue("@barkodNo", txt_barkodNo.Text);
                SqlDataReader read = komut.ExecuteReader();

                if (read.Read())
                {
                    txt_Eser.Text = read["kitapAdi"].ToString();
                    txt_Yazar.Text = read["yazar"].ToString();
                    txt_Yayinlayan.Text = read["yayinlayan"].ToString();
                    txt_YayinYeri.Text = read["yayinYeri"].ToString();
                    txt_isbnNo.Text = read["isbn"].ToString();
                    txt_yerNumarasi.Text = read["yerNumarasi"].ToString();
                }
                else
                {
                    foreach (Control item in Controls)
                    {
                        if (item is TextBox && item != txt_barkodNo)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }

        private void ClearTextBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
        }

        private void ClearRichTextBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is RichTextBox)
                {
                    ((RichTextBox)control).Clear();
                }
            }
        }

        private void ClearComboBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
            }
        }


    }
}
