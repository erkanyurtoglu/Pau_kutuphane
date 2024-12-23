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
    public partial class siralamaFrm : Form
    {
        public siralamaFrm()
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

        private void siralamaFrm_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLUYELER order by okunanKitap desc", baglanti);
            adtr.Fill(daset, "TBLUYELER");
            dataGridView1.DataSource = daset.Tables["TBLUYELER"];
            baglanti.Close();
            lbl_enCokOkuyanUye.Text = "";
            lbl_enAzOkuyanUye.Text = "";
            lbl_enCokOkuyanUye.Text = daset.Tables["TBLUYELER"].Rows[0]["uyeAdSoyad"].ToString() + "=";
            lbl_enCokOkuyanUye.Text += daset.Tables["TBLUYELER"].Rows[0]["okunanKitap"].ToString();
            lbl_enAzOkuyanUye.Text = daset.Tables["TBLUYELER"].Rows[dataGridView1.Rows.Count - 2]["uyeAdSoyad"].ToString() + "=";
            lbl_enAzOkuyanUye.Text += daset.Tables["TBLUYELER"].Rows[dataGridView1.Rows.Count - 2]["okunanKitap"].ToString();
        }
    }
}
