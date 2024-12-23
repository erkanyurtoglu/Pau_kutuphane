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
    public partial class emanetKitapListele : Form
    {
        public emanetKitapListele()
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

        private void emanetKitapListele_Load(object sender, EventArgs e)
        {
            emanetListele();
            cb_filtrele.SelectedIndex = 0;
        }

        private void emanetListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM TBLEMANETKITAP", baglanti);
            adtr.Fill(daset, "TBLEMANETKITAP");
            dataGridView1.DataSource = daset.Tables["TBLEMANETKITAP"];
            baglanti.Close();
        }

        private void cb_filtrele_SelectedIndexChanged(object sender, EventArgs e)
        {
            daset.Tables["TBLEMANETKITAP"].Clear();
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

            if (cb_filtrele.SelectedIndex == 0)
            {
                emanetListele();
            }
            else if (cb_filtrele.SelectedIndex == 1)
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(
                    $"SELECT * FROM TBLEMANETKITAP WHERE iadeTarihi = '{todayDate}'",
                    baglanti
                );
                adtr.Fill(daset, "TBLEMANETKITAP");
                dataGridView1.DataSource = daset.Tables["TBLEMANETKITAP"];
                baglanti.Close();
            }
            else if (cb_filtrele.SelectedIndex == 2)
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(
                    $"SELECT * FROM TBLEMANETKITAP WHERE '{todayDate}' > iadeTarihi",
                    baglanti
                );
                adtr.Fill(daset, "TBLEMANETKITAP");
                dataGridView1.DataSource = daset.Tables["TBLEMANETKITAP"];
                baglanti.Close();
            }
            else if (cb_filtrele.SelectedIndex == 3)
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(
                    $"SELECT * FROM TBLEMANETKITAP WHERE '{todayDate}' < iadeTarihi",
                    baglanti
                );
                adtr.Fill(daset, "TBLEMANETKITAP");
                dataGridView1.DataSource = daset.Tables["emanetKitaplar"];
                baglanti.Close();
            }
        }

        private void btnUzatma_Click(object sender, EventArgs e)
        {
            // Kullanıcının TC numarasını ve seçilen kitabın barkod numarasını al
            string tcNumarasi = "";
            string barkodNo = "";

            // Datagridview'den seçilen satırı kontrol et
            if (dataGridView1.SelectedRows.Count > 0)
            {
                tcNumarasi = dataGridView1.SelectedRows[0].Cells["tcNumarasi"].Value.ToString();
                barkodNo = dataGridView1.SelectedRows[0].Cells["barkodNo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen bir kayıt seçin.");
                return;
            }

            DateTime currentDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(baglanti.ConnectionString))
            {
                connection.Open();
                string query = "SELECT iadeTarihi, hasExtended FROM TBLEMANETKITAP WHERE tcNumarasi = @tcNumarasi AND barkodNo = @barkodNo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tcNumarasi", tcNumarasi);
                    command.Parameters.AddWithValue("@barkodNo", barkodNo);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime iadeTarihi = DateTime.Parse(reader["iadeTarihi"].ToString());
                            bool hasExtended = Convert.ToBoolean(reader["hasExtended"]);

                            if (currentDate > iadeTarihi && !hasExtended)
                            {
                                reader.Close();

                                string updateQuery = "UPDATE TBLEMANETKITAP SET iadeTarihi = @NewReturnDate, hasExtended = 1 WHERE tcNumarasi = @tcNumarasi AND barkodNo = @barkodNo";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@NewReturnDate", iadeTarihi.AddDays(15).ToString("yyyy-MM-dd"));
                                    updateCommand.Parameters.AddWithValue("@tcNumarasi", tcNumarasi);
                                    updateCommand.Parameters.AddWithValue("@barkodNo", barkodNo);
                                    updateCommand.ExecuteNonQuery();
                                }

                                MessageBox.Show("İade tarihi 15 gün uzatıldı.");
                            }
                            else
                            {
                                MessageBox.Show("İade tarihi uzatılamaz. Ya tarih geçmemiş ya da zaten uzatma yapılmış.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen kullanıcı ve kitap için emanet kaydı bulunamadı.");
                        }
                    }
                }
            }
        }

        private void btnHepsiniUzat_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(baglanti.ConnectionString))
            {
                connection.Open();
                string query = "SELECT tcNumarasi, barkodNo, iadeTarihi, hasExtended FROM TBLEMANETKITAP";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime iadeTarihi = DateTime.Parse(reader["iadeTarihi"].ToString());
                            bool hasExtended = Convert.ToBoolean(reader["hasExtended"]);
                            string tcNumarasi = reader["tcNumarasi"].ToString();
                            string barkodNo = reader["barkodNo"].ToString();

                            if (currentDate > iadeTarihi && !hasExtended)
                            {
                                reader.Close();

                                string updateQuery = "UPDATE TBLEMANETKITAP SET iadeTarihi = @NewReturnDate, hasExtended = 1 WHERE tcNumarasi = @tcNumarasi AND barkodNo = @barkodNo";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@NewReturnDate", iadeTarihi.AddDays(15).ToString("yyyy-MM-dd"));
                                    updateCommand.Parameters.AddWithValue("@tcNumarasi", tcNumarasi);
                                    updateCommand.Parameters.AddWithValue("@barkodNo", barkodNo);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }

            // Listeyi güncelle
            emanetListele();
            MessageBox.Show("Tüm kitapların iade tarihlerinin süresi 15 gün uzatıldı.");
        }

        private void txtTcİleListele_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["TBLEMANETKITAP"].Clear();
            using (SqlConnection baglanti = new SqlConnection("Data Source=EXCALIBUR\\SQLEXPRESS;Initial Catalog=kutuphaneOtomasyon;Integrated Security=True"))
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM TBLEMANETKITAP WHERE tcNumarasi LIKE @tcNumarasi", baglanti);
                adtr.SelectCommand.Parameters.AddWithValue("@tcNumarasi", txtTcİleListele.Text + "%");
                adtr.Fill(daset, "TBLEMANETKITAP");
                dataGridView1.DataSource = daset.Tables["TBLEMANETKITAP"];
            }
        }

        private void txtYazarİleListele_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["TBLEMANETKITAP"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLEMANETKITAP where yazarAdi like '%" + txtYazarİleListele.Text + "%'", baglanti);
            adtr.Fill(daset, "TBLEMANETKITAP");
            baglanti.Close();
            if (txtYazarİleListele.Text == "")
            {
                daset.Tables["TBLEMANETKITAP"].Clear();
                emanetListele();
            }
        }

        private void txtEserİleListele_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["TBLEMANETKITAP"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLEMANETKITAP where kitapAdi like '%" + txtEserİleListele.Text + "%'", baglanti);
            adtr.Fill(daset, "TBLEMANETKITAP");
            baglanti.Close();
            if (txtEserİleListele.Text == "")
            {
                daset.Tables["TBLEMANETKITAP"].Clear();
                emanetListele();
            }
        }
    }
}
