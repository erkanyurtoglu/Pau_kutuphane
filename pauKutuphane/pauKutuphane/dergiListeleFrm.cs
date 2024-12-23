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
    public partial class dergiListeleFrm : Form
    {
        public dergiListeleFrm()
        {
            InitializeComponent();
        }

        private SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True");
        private DataSet daset = new DataSet();
        private string connectionString = "Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True";

        private void btn_anasayfaDon_Click(object sender, EventArgs e)
        {
            adminAnaSayfa adminAnaSayfa = new adminAnaSayfa();
            adminAnaSayfa.Show();
            this.Hide();
            adminAnaSayfa.FormClosed += (s, args) => this.Close();
        }

        private void sureliYayinListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM TBLDERGILER", baglanti);
            daset.Tables.Clear(); // Önceki verileri temizle
            adtr.Fill(daset, "TBLDERGILER");
            dataGriddergi.DataSource = daset.Tables["TBLDERGILER"];
            baglanti.Close();
        }

        private void dergiListeleFrm_Load(object sender, EventArgs e)
        {
            sureliYayinListele();
        }

        private void btn_dergiGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbarkodNo.Text))
            {
                MessageBox.Show("Lütfen barkod numarasını giriniz.", "Eksik Alan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Buton tıklama işlemini iptal et
            }

            string barkod = txtbarkodNo.Text;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                // Kitabı seçme sorgusu
                SqlCommand komut = new SqlCommand("SELECT dergiAdi FROM TBLDERGILER WHERE barkodNo = @barkodNo", baglanti);
                komut.Parameters.AddWithValue("@barkodNo", barkod);

                SqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {
                    read.Close(); // Okuma işlemi tamamlandıktan sonra kapat

                    // Güncelleme işlemi
                    SqlCommand updateCommand = new SqlCommand("UPDATE TBLDERGILER SET dergiAdi = @dergiAdi, sorumlular = @sorumlular, yayinYeri = @yayinYeri, " +
                        "yayinlayan = @yayinlayan, matbaa = @matbaa, kopya = @kopya, fizikselNiteleme = @fizikselNiteleme WHERE barkodNo = @barkodNo", baglanti);

                    updateCommand.Parameters.AddWithValue("@dergiAdi", txteser.Text);
                    updateCommand.Parameters.AddWithValue("@sorumlular", txtsorumlular.Text);
                    updateCommand.Parameters.AddWithValue("@yayinlayan", txtyayinlayan.Text);
                    updateCommand.Parameters.AddWithValue("@yayinYeri", txtyayinyeri.Text);
                    updateCommand.Parameters.AddWithValue("@matbaa", txtmatbaa.Text);
                    updateCommand.Parameters.AddWithValue("@kopya", txtKopya.Text);
                    updateCommand.Parameters.AddWithValue("@FizikselNiteleme", txtfizikselNiteleme.Text);
                    updateCommand.Parameters.AddWithValue("@barkodNo", barkod);

                    updateCommand.ExecuteNonQuery();

                    daset.Tables["TBLDERGILER"].Clear();
                    sureliYayinListele();

                    MessageBox.Show("Güncelleme İşlemi Başarılı");
                    ClearTextBoxes();
                    ClearRichTextBoxes();
                    ClearComboBoxes();
                }
                else
                {
                    MessageBox.Show("Belirtilen barkod numarasıyla dergi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBoxes();
                }
            }
        }

        private void txtBarkodAra_TextChanged(object sender, EventArgs e)
        {
            DataView dv = daset.Tables["TBLDERGILER"].DefaultView;
            dv.RowFilter = string.Format("barkodNo LIKE '%{0}%'", txtBarkodAra.Text);
            dataGriddergi.DataSource = dv;
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

        private void txtbarkodNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbarkodNo.Text))
            {
                foreach (Control item in Controls)
                {
                    if (item is TextBox && item != txtbarkodNo)
                    {
                        item.Text = "";
                    }
                }
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM TBLDERGILER WHERE barkodNo = @barkodNo", baglanti);
                komut.Parameters.AddWithValue("@barkodNo", txtbarkodNo.Text);
                SqlDataReader read = komut.ExecuteReader();

                if (read.Read())
                {
                    txteser.Text = read["dergiAdi"].ToString();
                    txtsorumlular.Text = read["sorumlular"].ToString();
                    txtyayinlayan.Text = read["yayinlayan"].ToString();
                    txtyayinyeri.Text = read["yayinYeri"].ToString();
                    txtmatbaa.Text = read["matbaa"].ToString();
                    txtKopya.Text = read["kopya"].ToString();
                    txtfizikselNiteleme.Text = read["fizikselNiteleme"].ToString();
                }
                else
                {
                    foreach (Control item in Controls)
                    {
                        if (item is TextBox && item != txtbarkodNo)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }

        private void btn_dergiSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbarkodNo.Text))
            {
                MessageBox.Show("Lütfen barkod numarasını giriniz.", "Eksik Alan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Buton tıklama işlemini iptal et
            }

            string barkod= txtbarkodNo.Text;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("SELECT dergiAdi FROM TBLDERGILER WHERE barkodNo = @barkodNo", baglanti);
                komut.Parameters.AddWithValue("@barkodNo", barkod);

                SqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {
                    string kitapAdi = read["dergiAdi"].ToString();
                    read.Close();

                    DialogResult dialogResult = MessageBox.Show($"{kitapAdi} isimli dergiyi silmek istediğinizden emin misiniz?", "Süreli Yayın Silme", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string password = Microsoft.VisualBasic.Interaction.InputBox("Şifrenizi girin:", "Şifre Doğrulama", "");

                        if (password == "1234")
                        {
                            SqlCommand deleteCommand = new SqlCommand("DELETE FROM TBLDERGILER WHERE barkodNo = @barkodNo", baglanti);
                            deleteCommand.Parameters.AddWithValue("@barkodNo", barkod);
                            deleteCommand.ExecuteNonQuery();

                            MessageBox.Show("Silme İşlemi Başarılı");

                            daset.Tables["TBLDERGILER"].Clear();
                            sureliYayinListele();
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
                    MessageBox.Show("Belirtilen barkod numarasıyla dergi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBoxes();
                }
            }
        }



    }
}
