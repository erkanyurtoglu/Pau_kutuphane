using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace pauKutuphane
{
    public partial class uyeEkleFrm : Form
    {
        public uyeEkleFrm()
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

        private void btn_UyeEkle_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM TBLUYELER WHERE uyeTcKimlik= @uyeTcKimlik", connection);
                    checkCommand.Parameters.AddWithValue("@uyeTcKimlik", txt_uyeTcKimlik.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bu TC kimlik numarasına sahip bir üye zaten mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlCommand insertCommand = new SqlCommand(
                            "INSERT INTO TBLUYELER (uyeAdSoyad, uyeTcKimlik, uyeAdres, uyeTelefon, uyeEmail, uyeOkulNumarasi, " +
                            "uyeFakulteAdi, uyeBolumAdi, okunanKitap, uyeNot ) " +
                            "VALUES (@uyeAdSoyad, @uyeTcKimlik, @uyeAdres, @uyeTelefon, @uyeEmail, @uyeOkulNumarasi," +
                            "@uyeFakulteAdi, @uyeBolumAdi, @okunanKitap, @uyeNot )",
                            connection);

                        insertCommand.Parameters.AddWithValue("@uyeAdSoyad", txt_uyeAdSoyad.Text);
                        insertCommand.Parameters.AddWithValue("@uyeTcKimlik", txt_uyeTcKimlik.Text);
                        insertCommand.Parameters.AddWithValue("@uyeTelefon", txt_uyeTelefon.Text);
                        insertCommand.Parameters.AddWithValue("@uyeEmail", txt_uyeEmail.Text);
                        insertCommand.Parameters.AddWithValue("@uyeAdres", txt_uyeAdres.Text);
                        insertCommand.Parameters.AddWithValue("@uyeOkulNumarasi", txt_okulNo.Text);
                        insertCommand.Parameters.AddWithValue("@uyeFakulteAdi", txt_uyeFakulteAdi.Text);
                        insertCommand.Parameters.AddWithValue("@uyeBolumAdi", txt_bolumAdi.Text); 
                        insertCommand.Parameters.AddWithValue("@okunanKitap", 0);
                        insertCommand.Parameters.AddWithValue("@uyeNot", richTextBox_uyeNot.Text);

                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Üye Kaydı Yapıldı");

                        ClearTextBoxes();
                        ClearRichTextBoxes();
                        ClearComboBoxes();
                    }
                }
            }
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            // Uyarı rengini belirle
            Color warningColor = Color.FromArgb(205, 92, 92);

            // Alanları kontrol et ve ilgili label'ı göster
            if (string.IsNullOrWhiteSpace(txt_uyeAdSoyad.Text))
            {
                lbl_uyeAdSoyad.Visible = true;
                lbl_uyeAdSoyad.ForeColor = Color.Red;
                lbl_uyeAdSoyad.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_uyeAdSoyad.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_uyeTcKimlik.Text))
            {
                lbl_uyeTcKimlik.Visible = true;
                lbl_uyeTcKimlik.ForeColor = Color.Red;
                lbl_uyeTcKimlik.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_uyeTcKimlik.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_uyeTelefon.Text))
            {
                lbl_uyeTelefon.Visible = true;
                lbl_uyeTelefon.ForeColor = Color.Red;
                lbl_uyeTelefon.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_uyeTelefon.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_uyeEmail.Text))
            {
                lbl_uyeEmail.Visible = true;
                lbl_uyeEmail.ForeColor = Color.Red;
                lbl_uyeEmail.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_uyeEmail.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_uyeAdres.Text))
            {
                lbl_uyeAdres.Visible = true;
                lbl_uyeAdres.ForeColor = Color.Red;
                lbl_uyeAdres.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_uyeAdres.Visible = false;
            }


            if (string.IsNullOrWhiteSpace(txt_okulNo.Text))
            {
                lbl_calistigiBirim.Visible = true;
                lbl_calistigiBirim.ForeColor = Color.Red;
                lbl_calistigiBirim.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_calistigiBirim.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_uyeFakulteAdi.Text))
            {
                lbl_unvan.Visible = true;
                lbl_unvan.ForeColor = Color.Red;
                lbl_unvan.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_unvan.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_bolumAdi.Text))
            {
                lbl_isTelefon.Visible = true;
                lbl_isTelefon.ForeColor = Color.Red;
                lbl_isTelefon.Text = "*";
                isValid = false;
            }
            else
            {
                lbl_isTelefon.Visible = false;
            }


            if (!isValid)
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }


        private void ClearTextBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox && control != txt_okunanKitap)
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
