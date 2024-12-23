using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pauKutuphane
{
    public partial class uyeListeleFrm : Form
    {
        public uyeListeleFrm()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True";
        private DataSet daset = new DataSet();

        private void btn_anasayfaDon_Click(object sender, EventArgs e)
        {
            adminAnaSayfa adminAnaSayfa = new adminAnaSayfa();
            adminAnaSayfa.Show();
            this.Hide();
            adminAnaSayfa.FormClosed += (s, args) => this.Close();
        }

        private void uyeListeleFrm_Load(object sender, EventArgs e)
        {
            uyeListele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txt_kullanıcıAra.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            }
        }

        private void txt_kullanıcıAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["TBLUYELER"]?.Clear();
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                // SQL sorgusu
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM TBLUYELER WHERE uyeTcKimlik LIKE @uyeTcKimlik", baglanti);

                // Parametreyi tanımla
                adtr.SelectCommand.Parameters.Add("@uyeTcKimlik", SqlDbType.NVarChar).Value = txt_kullanıcıAra.Text + "%";

                // Veriyi al
                adtr.Fill(daset, "TBLUYELER");
                dataGridView1.DataSource = daset.Tables["TBLUYELER"];
            }
        }

        private void btn_uyeSil_Click(object sender, EventArgs e)
        {
            // Eğer txt_Tc boşsa, silme yapma
            if (string.IsNullOrWhiteSpace(txt_Tc.Text))
            {
                MessageBox.Show("TC kimlik numarasını giriniz.", "Eksik Alan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Buton tıklama işlemini iptal et
            }

            string tc = txt_Tc.Text;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                // Üyeyi seçme sorgusu
                SqlCommand komut = new SqlCommand("SELECT uyeAdSoyad FROM TBLUYELER WHERE uyeTcKimlik = @uyeTcKimlik", baglanti);
                komut.Parameters.AddWithValue("@uyeTcKimlik", tc);

                SqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {
                    string uyeAdi = read["uyeAdSoyad"].ToString();
                    read.Close(); // Okuma işlemi tamamlandıktan sonra kapat

                    // Silme onay penceresi
                    DialogResult dialogResult = MessageBox.Show($"{uyeAdi} isimli üyeyi silmek istediğinizden emin misiniz?", "Üye Silme", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Şifre doğrulama penceresi
                        string password = Microsoft.VisualBasic.Interaction.InputBox("Şifrenizi girin:", "Şifre Doğrulama", "");

                        // Şifre kontrolü
                        if (password == "1234")
                        {
                            // Silme işlemi
                            SqlCommand deleteCommand = new SqlCommand("DELETE FROM TBLUYELER WHERE uyeTcKimlik = @uyeTcKimlik", baglanti);
                            deleteCommand.Parameters.AddWithValue("@uyeTcKimlik", tc);
                            deleteCommand.ExecuteNonQuery();

                            MessageBox.Show("Silme İşlemi Başarılı");

                            // Verileri güncelle
                            daset.Tables["TBLUYELER"].Clear();
                            uyeListele();
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
                    MessageBox.Show("Belirtilen TC kimlik numarasıyla üye bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBoxes();
                }
            }
        }

        private void uyeListele()
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM TBLUYELER", baglanti);
                adtr.Fill(daset, "TBLUYELER");
                dataGridView1.DataSource = daset.Tables["TBLUYELER"];
            }
        }

        private void btn_uyeGuncelle_Click(object sender, EventArgs e)
        {
            // Eğer txt_Tc boşsa, güncelleme yapma
            if (string.IsNullOrWhiteSpace(txt_Tc.Text))
            {
                MessageBox.Show("TC kimlik numarasını giriniz.", "Eksik Alan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Buton tıklama işlemini iptal et
            }

            string tc = txt_Tc.Text;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                // Üyeyi seçme sorgusu
                SqlCommand selectCommand = new SqlCommand("SELECT uyeAdSoyad FROM TBLUYELER WHERE uyeTcKimlik = @uyeTcKimlik", baglanti);
                selectCommand.Parameters.AddWithValue("@uyeTcKimlik", tc);

                SqlDataReader read = selectCommand.ExecuteReader();
                if (read.Read())
                {
                    read.Close(); // Okuma işlemi tamamlandıktan sonra kapat

                    // Güncelleme sorgusu
                    SqlCommand updateCommand = new SqlCommand(
                        "UPDATE TBLUYELER SET uyeAdSoyad = @uyeAdSoyad, uyeTelefon = @uyeTelefon, uyeEmail = @uyeEmail, " +
                        "uyeAdres = @uyeAdres, uyeOkulNumarasi = @uyeOkulNumarasi, uyeNot = @uyeNot " +
                        "WHERE uyeTcKimlik = @uyeTcKimlik",
                        baglanti);

                    // Parametreleri ekle
                    updateCommand.Parameters.AddWithValue("@uyeAdSoyad", txt_uyeAdSoyad.Text);
                    updateCommand.Parameters.AddWithValue("@uyeTelefon", txt_uyeTelefon.Text);
                    updateCommand.Parameters.AddWithValue("@uyeEmail", txt_uyeEmail.Text);
                    updateCommand.Parameters.AddWithValue("@uyeAdres", txt_uyeAdres.Text);
                    updateCommand.Parameters.AddWithValue("@uyeOkulNumarasi", txt_okulNumarasi.Text);
                    updateCommand.Parameters.AddWithValue("@uyeFakulteAdi", txt_uyeFakulteAdi.Text);
                    updateCommand.Parameters.AddWithValue("@uyeNot", string.IsNullOrWhiteSpace(txt_uyeNot.Text) ? (object)DBNull.Value : txt_uyeNot.Text);
                    updateCommand.Parameters.AddWithValue("@uyeTcKimlik", tc);

                    // Sorguyu çalıştır
                    updateCommand.ExecuteNonQuery();

                    // Kullanıcıya bildirim
                    MessageBox.Show("Güncelleme İşlemi Başarılı");
                    daset.Tables["TBLUYELER"].Clear();
                    uyeListele();
                    ClearTextBoxes();
                    ClearRichTextBoxes();
                    ClearComboBoxes();
                }
                else
                {
                    MessageBox.Show("Belirtilen TC kimlik numarasıyla üye bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBoxes();
                }
            }
        }

        private void txt_Tc_TextChanged(object sender, EventArgs e)
        {
            if (txt_Tc.Text.Length == 11)
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM TBLUYELER WHERE uyeTcKimlik = @uyeTcKimlik", baglanti);
                    komut.Parameters.Add("@uyeTcKimlik", SqlDbType.NVarChar).Value = txt_Tc.Text;

                    SqlDataReader read = komut.ExecuteReader();
                    if (read.Read())
                    {
                        txt_uyeAdSoyad.Text = read["uyeAdSoyad"].ToString();
                        txt_uyeTelefon.Text = read["uyeTelefon"].ToString();
                        txt_uyeEmail.Text = read["uyeEmail"].ToString();
                        txt_uyeAdres.Text = read["uyeAdres"].ToString();
                        txt_okulNumarasi.Text = read["uyeOkulNumarasi"].ToString();
                        txt_uyeFakulteAdi.Text = read["uyeFakulteAdi"].ToString();
                        txt_uyeNot.Text = read["uyeNot"].ToString();
                    }
                    else
                    {
                        ClearTextBoxes();
                        ClearRichTextBoxes();
                        ClearComboBoxes();
                    }
                }
            }
            else if (txt_Tc.Text.Length == 0)
            {
                ClearTextBoxes();
                ClearRichTextBoxes();
                ClearComboBoxes();
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
