using Medipol_Hospital.Cryptography;
using MediSoft.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    public partial class NewPassword : Form
    {
        public NewPassword()
        {
            InitializeComponent();
        }
        private void NewPassword_Load(object sender, EventArgs e)
        {
            Confirm();
        }

        private void Confirm()
        {
            if (Session.MailConfirm) { textBox1.Visible = false; label2.Visible = false; } else { }
        }
        Context c = new Context();
        private void button1_Click(object sender, EventArgs e)
        {
            if (Session.WhoIsLoggedIn == 1)
            {

                if (Sha256Converter.ComputeSha256Hash(textBox1.Text) == Session.Password || Session.MailConfirm)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        string deger = Sha256Converter.ComputeSha256Hash(textBox3.Text);
                        var sonuc = c.Doctors.FirstOrDefault(x => x.doctorID == Session.sessionId);
                        sonuc.Password = deger;
                        c.SaveChanges();
                        Session.Password = deger;
                        MessageBox.Show("Şifreniz Değiştirildi");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Yeni Şifreleriniz Eşleşmiyor");
                        textBox3.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Mevcut Şifreniz yanlış");
                    textBox1.Text = "";

                }
            }
            else if (Session.WhoIsLoggedIn == 0)
            {
                if (Sha256Converter.ComputeSha256Hash(textBox1.Text) == Session.Password || Session.MailConfirm)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        string deger = Sha256Converter.ComputeSha256Hash(textBox3.Text);
                        var sonuc = c.Patches.FirstOrDefault(x => x.pID == Session.sessionId);
                        sonuc.Password = deger;
                        c.SaveChanges();
                        Session.Password = deger;
                        MessageBox.Show("Şifreniz Değiştirildi");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Yeni Şifreleriniz Eşleşmiyor");
                        textBox3.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Mevcut Şifreniz yanlış");
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Hata Ana Sayfaya Yönlendiriliyorsunuz ");
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }

        }


    }
}
