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
using System.Drawing.Text;

namespace yurt_otomasyon_projesi
{
    public partial class Oda_kayit : Form

    {
        StudentDbContext db = new StudentDbContext();
        public Oda_kayit()
        {
            InitializeComponent();
        }

        private void OdaListesiniGuncelle(object sender, EventArgs e)
        {
            // Eğer iki combobox'tan biri seçili değilse işlem yapma
            if (cmb_block.SelectedItem == null || cmb_kat.SelectedItem == null)
                return;

            string secilenBlok = cmb_block.SelectedItem.ToString();
            int secilenKat = Convert.ToInt32(cmb_kat.SelectedItem);

            // Oda listesini oluştur
            List<int> odaNumaralari = new List<int>();

            // Örnek: B blok, 2.kat -> 201'den 210'a kadar
            // Blok harfine göre başlangıç rakamı farklı olabilir (B=200, C=300 gibi)
            int katKatsayisi = 100; // 1.kat = 101, 2.kat = 201 gibi
            int baslangic = (secilenKat * katKatsayisi) + 1;
            int bitis = baslangic + 9; // 10 tane oda olsun (201-210)

            for (int oda = baslangic; oda <= bitis; oda++)
            {
                odaNumaralari.Add(oda);
            }

            // ComboBox'a yükle
            cmb_oda.DataSource = null;
            cmb_oda.DataSource = odaNumaralari;
            // int tipinde olduğu için DisplayMember/ValueMember gerekmez
        }
        private void Oda_kayit_Load(object sender, EventArgs e)
        {
            try
            {
                cmb_ogr.DataSource = db.students
                .OrderBy(s => s.student_name)
                .Select(s => new
                {
                    s.student_ıd,
                    FullName = s.student_name + " " + s.student_surname,

                })
                .ToList();
                cmb_ogr.DisplayMember = "FullName";
                cmb_ogr.ValueMember = "student_ıd";

                cmb_block.Items.Clear();
                cmb_block.Items.Add("A");
                cmb_block.Items.Add("B");
                cmb_block.SelectedIndex = 0;

                cmb_kat.Items.Clear();
                for (int i = 1; i <= 3; i++)
                {
                    cmb_kat.Items.Add(i.ToString());
                }

                cmb_block.SelectedIndexChanged += OdaListesiniGuncelle;
                cmb_kat.SelectedIndexChanged += OdaListesiniGuncelle;



                dateTimePicker1.Value = DateTime.Now;

                num_ucrt.Minimum = 1;
                num_ucrt.Maximum = 10000;
                num_ucrt.Value = 1000;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata={ex.Message}");
            }
        }


            private void cmb_block_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdalariYenile();
        }

        private void cmb_kat_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdalariYenile();
        }

        private void OdalariYenile()
        {
           
            try
            {
                if (cmb_block.SelectedItem != null && cmb_kat.SelectedItem != null)
                {
                    string block = cmb_block.SelectedItem.ToString();
                    int kat = Convert.ToInt32(cmb_kat.SelectedItem.ToString());  // cmb_mat DEĞİL, cmb_kat olacak

                    // Örnek: A blok 2. kat -> 201,202,203...210
                    // B blok 3. kat -> 301,302,303...310
                    int baslangicOdaNo = kat * 100 + 1;

                    // 1'den 10'a kadar oda numaraları oluştur
                    var odaListesi = Enumerable.Range(baslangicOdaNo, 10)
                        .Select(no => no.ToString())
                        .ToList();

                    cmb_oda.DataSource = odaListesi;
                    cmb_oda.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmb_oda.SelectedIndex = 0;
                }
                else
                {
                    cmb_oda.DataSource = null;
                    cmb_oda.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oda listesi oluşturulurken hata: {ex.Message}");
            }
        
        }










        private void btn_list_Click(object sender, EventArgs e)
        {
            try
            {
                var list = db.Registration
                .Include(r => r.student)
                .Include(r => r.Room)
                 .Include("room.Category")
                .Select(r => new

                {
                    r.registration_ıd,
                    ÖgrenciId = r.student_ıd,
                    ÖğrenciAdı = r.student.student_name,
                    ÖğrenciSoyismi = r.student.student_surname,
                    Blok = r.Room.Category != null ? r.Room.Category.category_block : "Belirtilmemiş",
                    OdaNumarası = r.Room.room_number,
                    KayıtTarihi = r.registration_date,
                    Ucret = r.registration_price,


                })
              .ToList();
                dataGridView1.DataSource = list;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                if (dataGridView1.Columns["Ucret"] != null)
                {
                    dataGridView1.Columns["Ucret"].DefaultCellStyle.Format = "C2";
                    dataGridView1.Columns["Ucret"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // ID kolonunu gizle
                if (dataGridView1.Columns["registration_ıd"] != null)
                {
                    dataGridView1.Columns["registration_ıd"].Visible = false;
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show($"Hata={ex.Message}");
            }

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOgrenciId = (int)cmb_ogr.SelectedValue;
                int selectedOdaId = (int)cmb_oda.SelectedValue;
                DateTime kayitTarihi = dateTimePicker1.Value;
                decimal ucret = num_ucrt .Value;


                var newRecord = new Registration
                {
                    student_ıd = selectedOgrenciId,
                    room_ıd = selectedOdaId,
                    registration_date = kayitTarihi,
                    registration_price = ucret
                };

                db.Registration.Add(newRecord);
                db.SaveChanges();

                MessageBox.Show("Kayıt başarıyla eklendi.");
                btn_list.PerformClick();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Hata={ex.Message}");
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sonuc = MessageBox.Show(
                "Silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    int selectId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["registration_ıd"].Value);
                    var recordToDelete = db.Registration.Find(selectId);

                    if (recordToDelete != null)
                    {
                        db.Registration.Remove(recordToDelete);
                        db.SaveChanges();

                        MessageBox.Show("Kayıt silindi!");

                        btn_list.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("Kayıt bulunamadı!");
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata={ex.Message}");
            }
        }
    }
}


               

