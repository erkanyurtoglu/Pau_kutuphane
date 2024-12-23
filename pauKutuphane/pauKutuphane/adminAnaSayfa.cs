using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pauKutuphane
{
    public partial class adminAnaSayfa : Form
    {
        public adminAnaSayfa()
        {
            InitializeComponent();
        }

        private void btn_cikisYap_Click(object sender, EventArgs e)
        {
            girisEkranFrm girisFormu = new girisEkranFrm();
            girisFormu.Show();
            this.Hide();
            girisFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_uyeEkle_Click(object sender, EventArgs e)
        {
            uyeEkleFrm uyeEkleFormu = new uyeEkleFrm();
            uyeEkleFormu.Show();
            this.Hide();
            uyeEkleFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_uyeListele_Click(object sender, EventArgs e)
        {
            uyeListeleFrm uyeListeleFormu = new uyeListeleFrm();
            uyeListeleFormu.Show();
            this.Hide();
            uyeListeleFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_kitapEkle_Click(object sender, EventArgs e)
        {
            kitapEkleFrm kitapEkleFormu = new kitapEkleFrm();
            kitapEkleFormu.Show();
            this.Hide();
            kitapEkleFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_kitapListele_Click(object sender, EventArgs e)
        {
            kitapListeleFrm kitapListeleFormu = new kitapListeleFrm();
            kitapListeleFormu.Show();
            this.Hide();
            kitapListeleFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_dergiEkle_Click(object sender, EventArgs e)
        {
            dergiEkleFrm dergiEkleFormu = new dergiEkleFrm();
            dergiEkleFormu.Show();
            this.Hide();
            dergiEkleFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_dergiListele_Click(object sender, EventArgs e)
        {
            dergiListeleFrm dergiListeleFormu = new dergiListeleFrm();
            dergiListeleFormu.Show();
            this.Hide();
            dergiListeleFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_rezervasyonOnay_Click(object sender, EventArgs e)
        {
            emanetOnay emanetOnayFormu = new emanetOnay();
            emanetOnayFormu.Show();
            this.Hide();
            emanetOnayFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_emanetVer_Click(object sender, EventArgs e)
        {
            emanetKitapVerme emanetKitapVermeFormu = new emanetKitapVerme();
            emanetKitapVermeFormu.Show();
            this.Hide();
            emanetKitapVermeFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_emanetListele_Click(object sender, EventArgs e)
        {
            emanetKitapListele emanetKitapListeleFormu = new emanetKitapListele();
            emanetKitapListeleFormu.Show();
            this.Hide();
            emanetKitapListeleFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_emanetiade_Click(object sender, EventArgs e)
        {
            emanetKitapİade emanetKitapİadeFormu = new emanetKitapİade();
            emanetKitapİadeFormu.Show();
            this.Hide();
            emanetKitapİadeFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_sirala_Click(object sender, EventArgs e)
        {
            siralamaFrm siralamaFormu = new siralamaFrm();
            siralamaFormu.Show();
            this.Hide();
            siralamaFormu.FormClosed += (s, args) => this.Close();
        }

        private void btn_grafik_Click(object sender, EventArgs e)
        {
            grafikFrm grafikFormu = new grafikFrm();
            grafikFormu.Show();
            this.Hide();
            grafikFormu.FormClosed += (s, args) => this.Close();
        }
    }
}
