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
    public partial class emanetKitapİade : Form
    {
        public emanetKitapİade()
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

        private void emanetKitapİade_Load(object sender, EventArgs e)
        {
            emanetListele();
        }

        private void emanetListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLEMANETKITAP", baglanti);
            adtr.Fill(daset, "TBLEMANETKITAP");
            dataGridView1.DataSource = daset.Tables["TBLEMANETKITAP"];
            baglanti.Close();
        }

        private void txt_tcAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["TBLEMANETKITAP"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLEMANETKITAP where tcNumarasi like '%" + txt_tcAra.Text + "%'", baglanti);
            adtr.Fill(daset, "TBLEMANETKITAP");
            baglanti.Close();
            if (txt_tcAra.Text == "")
            {
                daset.Tables["TBLEMANETKITAP"].Clear();
                emanetListele();
            }
        }

        private void txt_barkodNoAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["TBLEMANETKITAP"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLEMANETKITAP where barkodNo like '%" + txt_barkodNoAra.Text + "%'", baglanti);
            adtr.Fill(daset, "TBLEMANETKITAP");
            baglanti.Close();
            if (txt_barkodNoAra.Text == "")
            {
                daset.Tables["TBLEMANETKITAP"].Clear();
                emanetListele();
            }
        }

        private void btn_teslimAl_Click(object sender, EventArgs e)
        {
            // Eğer DataGridView'de hiç satır yoksa
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Teslim edilecek kitap yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Eğer DataGridView'de kitap var ama seçili değilse
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen teslim edilecek kitabı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçili kitap varsa teslim işlemleri
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from TBLEMANETKITAP where tcNumarasi = @tcNumarasi and barkodNo = @barkodNo", baglanti);
            komut.Parameters.AddWithValue("@tcNumarasi", dataGridView1.CurrentRow.Cells["tcNumarasi"].Value.ToString());
            komut.Parameters.AddWithValue("@barkodNo", dataGridView1.CurrentRow.Cells["barkodNo"].Value.ToString());
            komut.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("update TBLKITAPLAR set kopya=kopya+'" + dataGridView1.CurrentRow.Cells["kitapSayisi"].Value.ToString() + "' where barkodNo=@barkodNo", baglanti);
            komut2.Parameters.AddWithValue("@barkodNo", dataGridView1.CurrentRow.Cells["barkodNo"].Value.ToString());
            komut2.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kitaplar İade Edildi.");
            daset.Tables["TBLEMANETKITAP"].Clear();
            emanetListele();
        }
    }
}
