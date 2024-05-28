using Medipol_Hospital.Concrete;
using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form2 : Form   //kayıt olma formu
    {

        Context c = new Context();                       //veri tabanı bağlantısı için Context sınıfından nesne üret
        LoginManager loginManager = new LoginManager();  //login sınıfından nesne üret
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  //giriş sayfasına gitmek
        {
            Form1 form1 = new Form1();   
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null && textBox3 != null && textBox4 != null && textBox5 != null)  //boş mu diye kontrol ediliyor
            {
                string hashpass = Sha256Converter.ComputeSha256Hash(textBox4.Text); /*Kullanıcı Güvenliği için  **Hashleme**/ 

                if (comboBox1.SelectedIndex == 0) //hasta
                {
                    Patinets patient = new Patinets()       //Hasta sınıfından nesne üret 
                    {                                      //ve bilgileri ata
                        Email = textBox6.Text,
                        nationalityNo = textBox1.Text,
                        Name = textBox2.Text,
                        Surname = textBox3.Text,
                        BirthYear = Convert.ToInt32(textBox5.Text),
                        registerDate = DateTime.Now,
                        Password = hashpass
                    };

                    if (loginManager.RegisterPatient(patient)) { this.Hide(); }  //bilgileri kayıt etmek için uygun mu diye gönder 
                }
                //Doktor Kayıt
                else if (comboBox1.SelectedIndex == 1) //doktor
                {
                    Doctors doctor = new Doctors()
                    {
                        nationalityNo = textBox1.Text,
                        Name = textBox2.Text,
                        Surname = textBox3.Text,
                        BirthYear = Convert.ToInt32(textBox5.Text),
                        Email = textBox6.Text,
                        Password = hashpass
                    };
                    if (loginManager.RegisterDoctor(doctor)) { this.Hide(); } 
                }
                else
                {
                    MessageBox.Show("Tüm Alanları Doldurun Lütfen");
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurun Lütfen");
            }
        }
        private void button2_Click(object sender, EventArgs e) // çıkış
        {
            Application.Exit();
        }
    }

}
