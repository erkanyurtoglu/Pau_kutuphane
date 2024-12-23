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
    public partial class dergiEkleFrm : Form
    {
        public dergiEkleFrm()
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

        private void btn_dergiEkle_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Barkod numarasının var olup olmadığını kontrol et
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM TBLDERGILER WHERE barkodNo = @barkodNo", connection);
                    checkCommand.Parameters.AddWithValue("@barkodNo", txtBarkodNo.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bu barkod numarası zaten mevcut. Lütfen farklı bir barkod numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kullanıcıya yayını eklemek isteyip istemediğini sor
                    DialogResult result = MessageBox.Show($"Adı '{txtEser.Text}' ve sorumlu '{txtSorumlular.Text}' olan yayını eklemek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return; // Kullanıcı "Hayır" seçeneğine tıklarsa işlem iptal edilir
                    }

                    // Yayın ekleme işlemi
                    SqlCommand insertCommand = new SqlCommand(
                        "INSERT INTO TBLDERGILER (dergiAdi, sorumlular, barkodNo, issn, fizikselNiteleme, yayinYeri, yayinlayan, matbaa, kopya, aramaGrubu, " +
                        "notlar, kayitTarihi, yayinTarih, basimTarih, dergiTür, sure, dilBir, diliki, durum ) " +
                        "VALUES (@dergiAdi, @sorumlular, @barkodNo, @issn, @fizikselNiteleme, @yayinYeri, @yayinlayan, @matbaa, @kopya, @aramaGrubu, " +
                        "@notlar, @kayitTarihi, @yayinTarih, @basimTarih, @dergiTür, @sure, @dilBir, @diliki, @durum )", connection);

                    insertCommand.Parameters.AddWithValue("@kayitTarihi", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@yayinTarih", dtpYayinTarih.Value);
                    insertCommand.Parameters.AddWithValue("@basimTarih", dtpBasimTarih.Value);
                    insertCommand.Parameters.AddWithValue("@dergiTür", cbDergiTur.Text);
                    insertCommand.Parameters.AddWithValue("@sure", cbSure.Text);
                    insertCommand.Parameters.AddWithValue("@dilBir", cbDil1.Text);
                    insertCommand.Parameters.AddWithValue("@diliki", cbDil2.Text);
                    insertCommand.Parameters.AddWithValue("@barkodNo", txtBarkodNo.Text);
                    insertCommand.Parameters.AddWithValue("@kopya", int.Parse(txtKopya.Text));
                    insertCommand.Parameters.AddWithValue("@aramaGrubu", cbAramaGrubu.Text);
                    insertCommand.Parameters.AddWithValue("@sorumlular", txtSorumlular.Text);
                    insertCommand.Parameters.AddWithValue("@dergiAdi", txtEser.Text);
                    insertCommand.Parameters.AddWithValue("@notlar", richTextBox_Not.Text);
                    insertCommand.Parameters.AddWithValue("@yayinYeri", txtYayinYeri.Text);
                    insertCommand.Parameters.AddWithValue("@yayinlayan", txtYayinlayan.Text);
                    insertCommand.Parameters.AddWithValue("@matbaa", txtMatbaa.Text);
                    insertCommand.Parameters.AddWithValue("@issn", txtissn.Text);
                    insertCommand.Parameters.AddWithValue("@durum", cbDurum.Text);
                    insertCommand.Parameters.AddWithValue("@fizikselNiteleme", txtFizikselNiteleme.Text);

                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("Süreli Yayın Kaydı Yapıldı");

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
            if (string.IsNullOrWhiteSpace(dtpYayinTarih.Text))
            {
                lblYayinTarihi.Visible = true;
                lblYayinTarihi.ForeColor = Color.Red;
                lblYayinTarihi.Text = "*";
                isValid = false;
            }
            else
            {
                lblYayinTarihi.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(dtpBasimTarih.Text))
            {
                lblBasimTarihi.Visible = true;
                lblBasimTarihi.ForeColor = Color.Red;
                lblBasimTarihi.Text = "*";
                isValid = false;
            }
            else
            {
                lblBasimTarihi.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(cbDergiTur.Text))
            {
                lblAltTur.Visible = true;
                lblAltTur.ForeColor = Color.Red;
                lblAltTur.Text = "*";
                isValid = false;
            }
            else
            {
                lblAltTur.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(cbSure.Text))
            {
                lblSure.Visible = true;
                lblSure.ForeColor = Color.Red;
                lblSure.Text = "*";
                isValid = false;
            }
            else
            {
                lblSure.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(cbDil1.Text))
            {
                lblDil.Visible = true;
                lblDil.ForeColor = Color.Red;
                lblDil.Text = "*";
                isValid = false;
            }
            else
            {
                lblDil.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtBarkodNo.Text))
            {
                lblDemirbas.Visible = true;
                lblDemirbas.ForeColor = Color.Red;
                lblDemirbas.Text = "*";
                isValid = false;
            }
            else
            {
                lblDemirbas.Visible = false;
            }


            if (string.IsNullOrWhiteSpace(txtKopya.Text))
            {
                lblKopya.Visible = true;
                lblKopya.ForeColor = Color.Red;
                lblKopya.Text = "*";
                isValid = false;
            }
            else
            {
                lblKopya.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(cbAramaGrubu.Text))
            {
                lblAramaGrubu.Visible = true;
                lblAramaGrubu.ForeColor = Color.Red;
                lblAramaGrubu.Text = "*";
                isValid = false;
            }
            else
            {
                lblAramaGrubu.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtEser.Text))
            {
                lblEser.Visible = true;
                lblEser.ForeColor = Color.Red;
                lblEser.Text = "*";
                isValid = false;
            }
            else
            {
                lblEser.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtFizikselNiteleme.Text))
            {
                lblFizikselNiteleme.Visible = true;
                lblFizikselNiteleme.ForeColor = Color.Red;
                lblFizikselNiteleme.Text = "*";
                isValid = false;
            }
            else
            {
                lblFizikselNiteleme.Visible = false;
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
    }
}
