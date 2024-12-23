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
    public partial class emanetOnay : Form
    {
        public emanetOnay()
        {
            InitializeComponent();
        }

        private void btn_anasayfaDon_Click(object sender, EventArgs e)
        {
            adminAnaSayfa adminAnaSayfa = new adminAnaSayfa();
            adminAnaSayfa.Show();
            this.Hide();
            adminAnaSayfa.FormClosed += (s, args) => this.Close();
        }
    }
}
