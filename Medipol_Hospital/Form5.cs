using Medipol_Hospital.Concrete;
using MediSoft.Entities;
using System;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form5 : Form
    {
        DoctorManager doctorManager = new DoctorManager();    //doktor manager nesnesi üret
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            VisibleFalse();
            label3.Text = Session.UserName;                                        //Doktor ismini ekrana ver
            dataGridView2.DataSource = doctorManager.GetMyPat(Session.sessionId); //doktorun hastalarını getir
        }
        private void button1_Click(object sender, EventArgs e) //giriş yapan doktora randevusu olan hastalara getir 
        {
            VisibleFalse();
            groupBox2.Visible = true;
            dataGridView1.DataSource = doctorManager.GetMyPat(Session.sessionId); //gelen listeyi ata
        }
        private void button3_Click(object sender, EventArgs e)
        {
            VisibleFalse();
            groupBox1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)  //birini seçtin mi
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index; //seçili indexi al
                int HastaID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value); // o indexteki kişin Id sini al
                string konu = textBox1.Text;  //yazıları çek
                string mesaj = textBox4.Text;
                doctorManager.SendMail(HastaID, konu, mesaj); //mail gönder
            }
            else
            {
                MessageBox.Show("Lütfen Hasta seçiniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)  //hasta muayene sonrası reçete hazırlama sayfası
        {
            if (dataGridView2.SelectedRows.Count > 0)  //birini seçtin mi
            {
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index; //seçili indexi al
                int HastaID = Convert.ToInt32(dataGridView2.Rows[selectedRowIndex].Cells["ID"].Value); // o indexteki kişin Id sini al
                string ilaç = textBox2.Text;  //yazıları çek
                string tani = comboBox1.Text;
                
                string aciklama = textBox3.Text;

                doctorManager.PrescriptionsCreate(HastaID, ilaç, tani, aciklama); //managerdaki reçete oluşturucuya postala
            }
            else
            {
                MessageBox.Show("Lütfen Hasta seçiniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  MailService.MailService.SendEmail("resul.coder@gmail.com"); //mail onay kodu çalışır vaziyette
        }

        private void button6_Click(object sender, EventArgs e) //şifre yenileme ekranı
        {
            NewPassword pass = new NewPassword();
            pass.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e) // oturumu kapat
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e) //kapat
        {
            Application.Exit();
        }

        private void VisibleFalse()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

      
    }
}
