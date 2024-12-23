using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pauKutuphane
{
    public partial class kitapEkleFrm : Form
    {
        public kitapEkleFrm()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True";

        private void btn_anasayfaDon_Click(object sender, EventArgs e)
        {
            adminAnaSayfa adminAnaSayfa = new adminAnaSayfa();
            adminAnaSayfa.Show();
            this.Hide();
            adminAnaSayfa.FormClosed += (s, args) => this.Close();
        }

        private void btn_kitapEkle_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Demirbaş numarasının var olup olmadığını kontrol et
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM TBLKITAPLAR WHERE barkodNo = @barkodNo", connection);
                    checkCommand.Parameters.AddWithValue("@barkodNo", txt_barkod.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bu barkod numarası zaten mevcut. Lütfen farklı bir barkod numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kullanıcıya kitabı eklemek isteyip istemediğini sor
                    DialogResult result = MessageBox.Show($"Adı '{txt_eser.Text}' ve yazarı '{txt_yazar.Text}' olan kitabı eklemek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return; // Kullanıcı "Hayır" seçeneğine tıklarsa işlem iptal edilir
                    }

                    // Kitap ekleme işlemi
                    SqlCommand insertCommand = new SqlCommand(
                        "INSERT INTO TBLKITAPLAR (kitapAdi, yazar, sorumlular, barkodNo, isbn, yayinYeri, yayinlayan, matbaa, fizikselNiteleme, kitapTuru, yerNumarasi, kayitTarih, yayinTarih, kopya, cilt, dilBir, diliki, durum, aramaGrubu, saglama, kitabıKayitEden, notlar) " +
                        "VALUES (@kitapAdi, @yazar, @sorumlular, @barkodNo, @isbn, @yayinYeri, @yayinlayan, @matbaa, @fizikselNiteleme, @kitapTuru, @yerNumarasi, @kayitTarih, @yayinTarih, @kopya, @cilt, @dilBir, @diliki, @durum, @aramaGrubu, @saglama, @kitabıKayitEden, @notlar)",
                        connection);


                    insertCommand.Parameters.AddWithValue("@kitapAdi", txt_eser.Text);
                    insertCommand.Parameters.AddWithValue("@yazar", txt_yazar.Text);
                    insertCommand.Parameters.AddWithValue("@sorumlular", txt_sorumlular.Text);
                    insertCommand.Parameters.AddWithValue("@barkodNo", txt_barkod.Text);
                    insertCommand.Parameters.AddWithValue("@isbn", txt_isbn.Text);
                    insertCommand.Parameters.AddWithValue("@yayinYeri", txt_yayinYeri.Text);
                    insertCommand.Parameters.AddWithValue("@yayinlayan", txt_yayinlayan.Text);
                    insertCommand.Parameters.AddWithValue("@matbaa", txt_matbaa.Text);
                    insertCommand.Parameters.AddWithValue("@fizikselNiteleme", txt_fizikselNiteleme.Text);
                    insertCommand.Parameters.AddWithValue("@kitapTuru", cb_kitapTur.Text);
                    insertCommand.Parameters.AddWithValue("@yerNumarasi", txt_yerNumarasi.Text);
                    insertCommand.Parameters.AddWithValue("@kayitTarih", DateTime.Now.ToString("yyyy-MM-dd"));
                    insertCommand.Parameters.AddWithValue("@yayinTarih", dtp_yayinTarih.Value);
                    insertCommand.Parameters.AddWithValue("@kopya", int.Parse(txt_kopya.Text));

                    // Cilt sayısını nullable int olarak ekle
                    int? ciltSayisi = null;
                    if (!string.IsNullOrWhiteSpace(txt_cilt.Text))
                    {
                        if (int.TryParse(txt_cilt.Text, out int parsedCilt))
                        {
                            ciltSayisi = parsedCilt;
                        }
                        else
                        {
                            MessageBox.Show("Cilt sayısı geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    insertCommand.Parameters.AddWithValue("@cilt", (object)ciltSayisi ?? DBNull.Value);

                    insertCommand.Parameters.AddWithValue("@dilBir", cb_dil1.Text);
                    insertCommand.Parameters.AddWithValue("@diliki", cb_dil2.Text);
                    insertCommand.Parameters.AddWithValue("@durum", cb_durum.Text);
                    insertCommand.Parameters.AddWithValue("@aramaGrubu", cb_aramaGrubu.Text);
                    insertCommand.Parameters.AddWithValue("@saglama", cb_saglama.Text);
                    insertCommand.Parameters.AddWithValue("@kitabıKayitEden", txt_kitabiKayitEden.Text);
                    insertCommand.Parameters.AddWithValue("@notlar", txt_notlar.Text);

                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("Kitap Kaydı Yapıldı.");

                    // Form kontrollerini temizle
                    ClearTextBoxes();
                    ClearRichTextBoxes();
                    ClearComboBoxes();
                }
            }

        }


        private bool ValidateFields()
        {
            bool isValid = true;

            // Uyarı rengini belirle
            Color warningColor = Color.FromArgb(205, 92, 92);

            // Alanları kontrol et ve ilgili label'ı göster
            if (string.IsNullOrWhiteSpace(cb_kitapTur.Text))
            {
                lbl_altTurWarning.Visible = true;
                lbl_altTurWarning.ForeColor = Color.Red;
                lbl_altTurWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_altTurWarning.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(cb_aramaGrubu.Text))
            {
                lbl_aramaGrubuWarning.Visible = true;
                lbl_aramaGrubuWarning.ForeColor = Color.Red;
                lbl_aramaGrubuWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_aramaGrubuWarning.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_barkod.Text))
            {
                lbl_demirbasWarning.Visible = true;
                lbl_demirbasWarning.ForeColor = Color.Red;
                lbl_demirbasWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_demirbasWarning.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(cb_dil1.Text))
            {
                lbl_dil1Warning.Visible = true;
                lbl_dil1Warning.ForeColor = Color.Red;
                lbl_dil1Warning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_dil1Warning.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_eser.Text))
            {
                lbl_eserWarning.Visible = true;
                lbl_eserWarning.ForeColor = Color.Red;
                lbl_eserWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_eserWarning.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_fizikselNiteleme.Text))
            {
                lbl_fizikselNitelemeWarning.Visible = true;
                lbl_fizikselNitelemeWarning.ForeColor = Color.Red;
                lbl_fizikselNitelemeWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_fizikselNitelemeWarning.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_isbn.Text))
            {
                lbl_isbnWarning.Visible = true;
                lbl_isbnWarning.ForeColor = Color.Red;
                lbl_isbnWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_isbnWarning.Visible = false;
            }


            if (string.IsNullOrWhiteSpace(cb_saglama.Text))
            {
                lbl_saglamaWarning.Visible = true;
                lbl_saglamaWarning.ForeColor = Color.Red;
                lbl_saglamaWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_saglamaWarning.Visible = false;
            }


            if (string.IsNullOrWhiteSpace(txt_yazar.Text))
            {
                lbl_yazarWarning.Visible = true;
                lbl_yazarWarning.ForeColor = Color.Red;
                lbl_yazarWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_yazarWarning.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_yerNumarasi.Text))
            {
                lbl_yerNumarasiWarning.Visible = true;
                lbl_yerNumarasiWarning.ForeColor = Color.Red;
                lbl_yerNumarasiWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_yerNumarasiWarning.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_kopya.Text))
            {
                lbl_kopyaWarning.Visible = true;
                lbl_kopyaWarning.ForeColor = Color.Red;
                lbl_kopyaWarning.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_kopyaWarning.Visible = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void ClearTextBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
        }

        private void ClearRichTextBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is RichTextBox)
                {
                    ((RichTextBox)control).Clear();
                }
            }
        }

        private void ClearComboBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
            }
        }

        private void kitapEkleFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
