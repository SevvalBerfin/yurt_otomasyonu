using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.Entity;

namespace yurt_otomasyon_projesi
{
    public partial class Oda_kayit : Form
    {
        public Oda_kayit()
        {
            InitializeComponent();
        }

        StudentDbContext db=new StudentDbContext();
        private void Oda_kayit_Load(object sender, EventArgs e)
        {

        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            try
            {
                  var list = db.Registration
                  .Include(r => r.student)
                  .Include(r => r.Room.Category)
                  .Select(r => new

                  {
                     r.registration_ıd,
                     ÖğrenciAdı = r.student.student_name,
                     ÖğrenciSoyismi = r.student.student_surname,
                     OdaAdı = r.Room.Category.category_name,
                     KayıtTarihi = r.registration_date,
                     Ücret = r.registration_price,


                  })
                .ToList();
              dataGridView1.DataSource = list;
              dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Hata={ex.Message}");
            }
            
        }
    }
}
