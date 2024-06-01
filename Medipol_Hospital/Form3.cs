using Medipol_Hospital.Concrete;
using System;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form3 : Form
    {
        PersonelManager personelManager = new PersonelManager(); //işlemler için personel sınıfıdan nesne üret
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView3.DataSource = personelManager.GetAllPat();  //verileri dataGride gönder
            VisibleFalse();  //groupboxları kapat
        }

        private void button1_Click(object sender, EventArgs e)  //hasta listesini getir
        {
            VisibleFalse();
            groupBox2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)      //doktorların listesi getir
        {
            VisibleFalse();
            groupBox4.Visible = true;
            dataGridView2.DataSource = personelManager.GetDoctorAll(); //doktorların verilerini tabloya ekle 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0) //seçili satır sayısı 0 dan fazla mı
            {
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index; //seçili indexi getir

                int doctorID = Convert.ToInt32(dataGridView2.Rows[selectedRowIndex].Cells["doctorID"].Value);  //o indexteki ID yi çek

                personelManager.RemoveDoctor(doctorID); //seçilen doktorun silme işlemi için Managera gönder

                dataGridView2.DataSource = personelManager.GetDoctorAll(); //yeni bilgileri getir
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuyu seçiniz.");
            }
        }

        private void button5_Click(object sender, EventArgs e)  //randevu sayfasını getir
        {
            VisibleFalse();
            groupBox6.Visible = true;
            dataGridView1.DataSource = personelManager.GetAllAppointment(); //managerdan gelen verileri datagridviewe ekle 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) //seçili satır var ise gir ifin içine
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index; //seçili satırın index nosu

                int randevuID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Randevu_ID"].Value); //seçili satırdaki randevu Id Al

                personelManager.RemoveAppointment(randevuID); //managerdaki rendevu silme methoduna postala

                dataGridView1.DataSource = personelManager.GetAllAppointment(); //değerleri yenile
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuyu seçiniz.");
            }
        }

        private void button7_Click(object sender, EventArgs e)  //çıkış yap 
        {
            Form1 form1 = new Form1(); 
            form1.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)  //kapat 
        {
            Application.Exit();
        }
        public void VisibleFalse()
        {
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox6.Visible = false;
        }

      
    }
}
