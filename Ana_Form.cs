using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yurt_otomasyon_projesi
{
    public partial class Ana_Form : Form
    {
        public Ana_Form()
        {
            InitializeComponent();
        }

        private void btn_ogr_Click(object sender, EventArgs e)
        {
            Form1 ogrenciForm = new Form1();
            ogrenciForm.Show();
            this.Hide();
        }

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            Oda_kayit odaForm = new Oda_kayit();
            odaForm.Show();
            this.Hide();
        }
    }
}
