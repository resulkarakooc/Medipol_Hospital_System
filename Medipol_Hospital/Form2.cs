using Medipol_Hospital.Concrete;
using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Diagnostics;
using System.Net.Mail;
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
            maskedTextBox1.Mask = "00000000000";
            //maskedTextBox1.Mask = ">LLLLLLLLLLLLLLLLLLLLLLLLLLLLLL";
            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  //giriş sayfasına gitmek
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBox6.Text;
                MailAddress mailAddress = new MailAddress(email);


                if (maskedTextBox1 != null && textBox2 != null && textBox3 != null && textBox4 != null && textBox5 != null)  //boş mu diye kontrol ediliyor
                {
                    string hashpass = Sha256Converter.ComputeSha256Hash(textBox4.Text); /*Kullanıcı Güvenliği için  **Hashleme**/

                    if (comboBox1.SelectedIndex == 0) //hasta
                    {
                        Patinets patient = new Patinets()       //Hasta sınıfından nesne üret 
                        {                                      //ve bilgileri ata
                            Email = textBox6.Text,
                            nationalityNo = maskedTextBox1.Text,
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
                            nationalityNo = maskedTextBox1.Text,
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
                    MessageBox.Show("Tüm alanları olması gerektiği gibi doldurun lütfen \n   -Türkiye Cumhuriyeti Sağlık Bakanlığı Medipol Hastanesi ");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Girilen metin bir geçersiz eposta adresidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  //iletişim için hızlı e-posta
        {
            string email = "resul.krkoc@gmail.com";
            string subject = "İletişim";
            string body = "Merhaba sorunum şu şekilde; ";

            string mail = string.Format("mailto:{0}?subject={1}&body={2}", email, Uri.EscapeDataString(subject), Uri.EscapeDataString(body));
            // Varsayılan e-posta istemcisini aç
            Process.Start(mail);
        }
        private void button2_Click(object sender, EventArgs e) // çıkış
        {
            Application.Exit();
        }

       
    }

}
