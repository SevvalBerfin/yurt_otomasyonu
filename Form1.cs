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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StudentDbContext db = new StudentDbContext();

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            try
            {
                var students = db.students.ToList();
                dataGridView1.DataSource = students;

                dataGridView1.Columns["student_ıd"].HeaderText = "Öğrenci ID";
                dataGridView1.Columns["student_name"].HeaderText = "Öğrenci İsmi";
                dataGridView1.Columns["student_surname"].HeaderText = "Öğrenci Soyismi";
                dataGridView1.Columns["student_tc"].HeaderText = "Öğrenci TC";
                dataGridView1.Columns["student_email"].HeaderText = "E-posta";
                dataGridView1.Columns["student_phone"].HeaderText = "Telefon Numarası";


                dataGridView1.Columns["student_ıd"].Visible=false;

                dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
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
                if (txt_tc.Text.Length != 11)
                {
                    MessageBox.Show("TC Kimlik No 11 haneli olmalıdır!");
                    txt_tc.Focus();
                    return;
                }

                if (txt_telefon.Text.Length != 11)
                {
                    MessageBox.Show("Telefon numarası 11 haneli olmalıdır! 05xxxxxxxxx");
                    txt_telefon.Focus(); return;
                }


                bool exists = db.students.Any(s => s.student_tc == txt_tc.Text);

                if (exists)
                {
                    MessageBox.Show("Bu TC Kimlik No'ya sahip bir öğrenci zaten kayıtlı!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_tc.Focus();
                    txt_tc.SelectAll();
                    return;
                }






                student newstudent = new student()
                {

                    student_name = txt_isim.Text,
                    student_surname = txt_soyisim.Text,
                    student_tc = txt_tc.Text,
                    student_email= txt_mail.Text,
                    student_phone= txt_telefon.Text
                };
                db.students.Add(newstudent);
                db.SaveChanges();


                MessageBox.Show("Yeni Öğrenci Eklendi.");
                btn_list.PerformClick();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata={ex.Message}");
            }
        }
    }
}
