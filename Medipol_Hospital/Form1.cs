using Medipol_Hospital.Concrete;
using MediSoft.Entities;
using System;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class Form1 : Form
    {
        Context c = new Context();
        LoginManager loginManager = new LoginManager();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Formun KeyPreview özelliğini true olarak ayarlıyoruz
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            panel1.Visible = false;   //şifremi unuttum panelini gizle
            Confirm(false);           //şifremi unuttum panelinde belli alanları kapa
            maskedTextBox1.Mask = "00000000000"; //Validation işlemi zorunlu 11 hane ve sayısal
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //yeni kullanıcı oluştur
        {
            Form2 form2 = new Form2();   
            form2.Show();     //kayıt sayfasına git
            this.Hide();      //mevcut sayfayı gizlee
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //şifremi unuttum
        {
            panel1.Visible = true;  //şifremi unuttum panelini aç
        }

        private void button1_Click(object sender, EventArgs e)  //giriş yap butonu
        {
            
            if (loginManager.Logins(maskedTextBox1.Text, textBox2.Text)) { this.Hide(); } //giriş bilgilerini gönder kontrol etmek için
            
        }
        int a;
        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();                         //nesne üret random sınıfından                
            int random = rnd.Next(100000, 1000000);           //6 haneli kod üret
             if (loginManager.Verification(textBox4.Text, random)) { Confirm(true); a = random; }   // bunları gönder doğrulama için
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == a.ToString()) //mail adresine gönderilen kodu doğru girdi mi?
            {
                panel1.Visible = false;        //şifremi unuttum panelini kapa
                Session.MailConfirm = true;     //Sessionda güven izni ver mail doğrulama ile içeri al
                NewPassword pass = new NewPassword();  //şifre yenileme için yeni form üret
                pass.ShowDialog(); //formu aç
            }
            else
            {
                MessageBox.Show("Onay Kodu Hatalı Tekrar Dene"); 
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  //şifremi hatrıladım!!
        {
            panel1.Visible = false; 
            Confirm(false);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.Handled = true; // Enter tuşunun formdaki diğer kontroller tarafından kullanılmasını engellemek için.
            }
        }

        private void button2_Click(object sender, EventArgs e) //kapat
        {
            Application.Exit();
        }
        private void Confirm(bool deger) //kod giriş alanı açma-kapama
        {
            textBox3.Visible = deger;
            button3.Visible = deger;
            label6.Visible = deger;
        }
    }
}
